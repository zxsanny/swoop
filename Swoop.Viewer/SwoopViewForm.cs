using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using log4net;
using Swoop.Common;
using Swoop.Common.Extensions;
using Swoop.Common.Models;
using Swoop.Common.Repositories;
using mshtml;

namespace Swoop.Viewer
{
    public partial class SwoopViewForm : Form
    {
        private bool dataGridProgramChanged = true;
        private readonly IEnumerable<ITrackerGrabber> grabbers;
        private readonly ITrackerRepository trackerRepository;
        private readonly ISeedsRepository seedsRepository;
        private readonly ILog logger;
        private bool grabbersWorks;

        private readonly Dictionary<SortOrder, SortOrder> sortTransitions = new Dictionary<SortOrder, SortOrder>
        {
            { SortOrder.None, SortOrder.Ascending },
            { SortOrder.Ascending, SortOrder.Descending },
            { SortOrder.Descending, SortOrder.None }
        };
        private readonly Dictionary<SortOrder, ListSortDirection?> sortProjection = new Dictionary<SortOrder, ListSortDirection?>
        {
            {SortOrder.None, null},
            {SortOrder.Ascending, ListSortDirection.Ascending},
            {SortOrder.Descending, ListSortDirection.Descending}
        };
        private SortInfo sortInfo;

        public SwoopViewForm(IEnumerable<ITrackerGrabber> grabbers, ITrackerRepository trackerRepository, ISeedsRepository seedsRepository, ILog logger)
        {
            this.grabbers = grabbers.ToList();
            this.trackerRepository = trackerRepository;
            this.seedsRepository = seedsRepository;
            this.logger = logger;
            InitializeComponent();

            foreach (var grabber in this.grabbers)
                trackerRepository.Save(grabber.TrackerInfo);
        }

        private void SwoopViewForm_Load(object sender, EventArgs e)
        {
            Text = "Swoop v." + Assembly.GetExecutingAssembly().GetName().Version;
            Console.SetOut(new TextBoxWriter(tbConsole));
            dgCheckpoints.CellValueChanged += dgCheckpoints_CellValueChanged;
            RefreshStatus();
            
            RefreshCategories();

            sortInfo = new SortInfo(ListSortDirection.Ascending, "Created");
            RefreshSeeds();
            dgSeeds.Columns[0].HeaderCell.SortGlyphDirection = SortOrder.Ascending;

            var autograb = bool.Parse(ConfigurationManager.AppSettings.GetValue("autograb", "false"));
            if (autograb)
            {
                grabbersWorks = true;
                continueGrabToolStripMenuItem.Text = "Stop!";
                tsProgress.Visible = true;
                SwitchGrabbers(true);
            }
        }

        
        private void continueGrabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var menuItem = (sender as ToolStripMenuItem);
            grabbersWorks = !grabbersWorks;
            SwitchGrabbers(grabbersWorks);
            
            if (grabbersWorks)
            {
                menuItem.Text = "Stop!";
                tsProgress.Visible = true;   
            }
            else
            {
                menuItem.Text = "Continue grab!";
                tsProgress.Visible = false;
            }
        }

        void SwitchGrabbers(bool shouldWork)
        {
            if (shouldWork)
            {
                ThreadPool.QueueUserWorkItem(a =>
                {
                    while (grabbersWorks)
                    {
                        this.InvokeEx(x => { x.RefreshStatus(); });
                        Thread.Sleep(TimeSpan.FromSeconds(20));
                    }
                });

                foreach (var grabber in grabbers)
                {
                    var gr = grabber;
                    ThreadPool.QueueUserWorkItem(x => gr.ContinueGrab());
                }
            }
            else
            {
                foreach (var grabber in grabbers)
                {
                    var gr = grabber;
                    gr.StopGrab();
                }
            }
        }

        void dgCheckpoints_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridProgramChanged)
                return;
            var grid = sender as DataGridView;
            if (grid == null)
                return;
            
            trackerRepository.SaveCheckPoint(grid.Rows[e.RowIndex].DataBoundItem as TrackerInfo);
        }

        private void dgSeeds_SelectionChanged(object sender, EventArgs e)
        {
            var grid = sender as DataGridView;
            if (grid == null)
                return;
            var rows = grid.SelectedRows;
            if (rows.Count == 0)
                return;

            var seed = rows[0].DataBoundItem as SeedDecorator;
            if (seed == null)
                return;

            webSeed.DocumentText = seed.model.Description;
            tbSeed.Text = seed.Title;
            btDownload.Tag = seed.MagnetLink;
        }
        private void dgSeeds_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var grid = (sender as DataGridView);
            if (grid == null || grid.RowCount == 0)
                return;
            var linkColumn = grid.Columns["Link"];
            if (linkColumn != null)
                grid.Columns.Remove("Link");
            var magnetColumn = grid.Columns["Magnet"];
            if (magnetColumn != null)
                grid.Columns.Remove("Magnet");
            
            grid.Columns.Add(new DataGridViewLinkColumn
            {
                Name = "Link",
                UseColumnTextForLinkValue = true
            });
            grid.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Magnet",
                UseColumnTextForButtonValue = true
            });
            GridWeight<SeedDecorator>.Fill(grid)
                .SetWidth(x => x.Created, 37)
                .SetWidth(x => x.SizeMb, 35)
                .SetWidth("Link", 14)
                .SetWidth("Magnet", 25);

            var linkIndex = grid.ColumnCount - 2;
            var magnetIndex = grid.ColumnCount - 1;
            foreach (DataGridViewRow r in grid.Rows)
            {
                var seed = r.DataBoundItem as SeedDecorator;
                if (seed == null)
                    continue;

                r.Cells[linkIndex] = new DataGridViewLinkCell
                {
                    Value = "Link",
                    Tag = seed.Url
                };

                    
                r.Cells[magnetIndex] = new DataGridViewButtonCell
                {
                    Value = "Download",
                    Tag = seed.MagnetLink
                };
            }
            foreach (DataGridViewColumn column in grid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Programmatic;
            }

        }
        private void dgSeeds_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (sender as DataGridView);
            if (grid == null || e.RowIndex < 0)
                return;
            
            if (e.ColumnIndex > grid.Columns.Count - 3)
                Process.Start((string) grid[e.ColumnIndex, e.RowIndex].Tag);
        }

        private void dgSeeds_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var index = e.ColumnIndex;
            if (index >= dgSeeds.ColumnCount - 2)
                return;
            var column = dgSeeds.Columns[index];
            if (column == null)
                return;

            var userSortDirection = sortTransitions[column.HeaderCell.SortGlyphDirection];
            sortInfo = new SortInfo(sortProjection[userSortDirection], column.DataPropertyName);

            RefreshSeeds();
            for (int i = 0; i < dgSeeds.ColumnCount; i++)
            {
                var sortDirection = (i == index) ? userSortDirection : SortOrder.None;
                dgSeeds.Columns[i].HeaderCell.SortGlyphDirection = sortDirection;
            }
        }

        private void tbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            var tb = sender as TextBox;
            if (tb == null)
                return;

            if (e.KeyCode == Keys.Enter)
            {
                this.InvokeEx(x => x.RefreshSeeds());
                logger.Info("searched " + tb.Text);
            }
        }

        private void logToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            var logItem =  sender as ToolStripMenuItem;
            if (logItem == null)
                return;
            scMain.Panel2Collapsed = !logItem.Checked;
        }
        
        private void tbCategoryFilter_TextChanged(object sender, EventArgs e)
        {
            ActionExtensions.ThrottleAction(() =>
            {
                this.InvokeEx(x => x.RefreshCategories());
                Thread.Sleep(100);
                this.InvokeEx(x => x.RefreshSeeds());
            });
        }
        
        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            var tb = sender as TextBox;
            if (tb == null)
                return;

            if ((e.KeyCode == Keys.Back) && e.Control)
            {
                e.SuppressKeyPress = true;
                int selStart = tb.SelectionStart;
                while (selStart > 0 && tb.Text.Substring(selStart - 1, 1) == " ")
                {
                    selStart--;
                }
                int prevSpacePos = -1;
                if (selStart != 0)
                {
                    prevSpacePos = tb.Text.LastIndexOf(' ', selStart - 1);
                }
                tb.Select(prevSpacePos + 1, tb.SelectionStart - prevSpacePos - 1);
                tb.SelectedText = "";
            }
        }


        private void RefreshStatus()
        {
            dataGridProgramChanged = true;
            dgCheckpoints.DataSource = trackerRepository.GetAll();
            dataGridProgramChanged = false;
            var seedCounts = seedsRepository.GetCounts();

            tssSeedsCount.Text = "Total seeds: " + string.Join(",", seedCounts.Select(x => x.TrackerName + ": " + x.Count));
        }

        private void RefreshSeeds()
        {
            var selectedRow = dgSeeds.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();
            var rowIndex = 0;
            if (selectedRow != null)
                rowIndex = selectedRow.Index;

            var categories = new List<string>();
            if (lbCategories.SelectedItems.Count != lbCategories.Items.Count || !string.IsNullOrEmpty(tbCategoryFilter.Text))
                categories = lbCategories.SelectedItems.Cast<object>().Select(x => lbCategories.GetItemText(x)).ToList();
            
            dgSeeds.DataSource = seedsRepository.Find(tbSearch.Text, categories, sortInfo)
                .Select(x => new SeedDecorator(x, trackerRepository.GetTrackerInfo(x.TrackerName))).ToList();

            if (dgSeeds.RowCount > 0)
                dgSeeds.Rows[Math.Min(dgSeeds.RowCount - 1, rowIndex)].Selected = true;
        }

        private void RefreshCategories()
        {
            lbCategories.DataSource = seedsRepository.GetCategories(tbCategoryFilter.Text);

            for (int i = 0; i < lbCategories.Items.Count; i++)
                lbCategories.SetSelected(i, true);
        }

        private void lbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActionExtensions.ThrottleAction(() =>
            {
                this.InvokeEx(x => x.RefreshSeeds());
            });
        }

        private void btDownload_Click(object sender, EventArgs e)
        {
            var bt = sender as Button;
            if (bt == null)
                return;
            var magnet = bt.Tag;
            if (string.IsNullOrEmpty(magnet.ToString()))
                return;

            Process.Start(magnet.ToString());
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            this.InvokeEx(x => x.RefreshSeeds());
            logger.Info("searched " + tbSearch.Text);
        }

        private void WebBrowser_MouseEnter(object sender, EventArgs e)
        {
            webSeed.Focus();
        }

        private void webSeed_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
//            webSeed.Document.AttachEventHandler("onmouseover",
//                (o, args) =>
//                {
//                    webSeed.Focus();
//                });
//            doc.onmouseover += new mshtml.HTMLDocumentEvents2_onmouseoverEventHandler(doc_onmouseover);
        }

        
    }
}
