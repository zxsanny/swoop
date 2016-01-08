namespace Swoop.Viewer
{
    partial class SwoopViewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SwoopViewForm));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tbConsole = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.swoopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.continueGrabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgCheckpoints = new System.Windows.Forms.DataGridView();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.scSeedsDescription = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btSearch = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.scCategories = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lbCategories = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbCategoryFilter = new System.Windows.Forms.TextBox();
            this.dgSeeds = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbSeed = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btDownload = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssSeedsCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.webSeed = new System.Windows.Forms.WebBrowser();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCheckpoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scSeedsDescription)).BeginInit();
            this.scSeedsDescription.Panel1.SuspendLayout();
            this.scSeedsDescription.Panel2.SuspendLayout();
            this.scSeedsDescription.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scCategories)).BeginInit();
            this.scCategories.Panel1.SuspendLayout();
            this.scCategories.Panel2.SuspendLayout();
            this.scCategories.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSeeds)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbConsole
            // 
            this.tbConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbConsole.Location = new System.Drawing.Point(379, 3);
            this.tbConsole.Multiline = true;
            this.tbConsole.Name = "tbConsole";
            this.tbConsole.Size = new System.Drawing.Size(981, 42);
            this.tbConsole.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.swoopToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1363, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // swoopToolStripMenuItem
            // 
            this.swoopToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.continueGrabToolStripMenuItem});
            this.swoopToolStripMenuItem.Name = "swoopToolStripMenuItem";
            this.swoopToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.swoopToolStripMenuItem.Text = "Grabber";
            // 
            // continueGrabToolStripMenuItem
            // 
            this.continueGrabToolStripMenuItem.Name = "continueGrabToolStripMenuItem";
            this.continueGrabToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.continueGrabToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.continueGrabToolStripMenuItem.Text = "Continue Grab";
            this.continueGrabToolStripMenuItem.Click += new System.EventHandler(this.continueGrabToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // logToolStripMenuItem
            // 
            this.logToolStripMenuItem.Checked = true;
            this.logToolStripMenuItem.CheckOnClick = true;
            this.logToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.logToolStripMenuItem.Name = "logToolStripMenuItem";
            this.logToolStripMenuItem.Size = new System.Drawing.Size(91, 22);
            this.logToolStripMenuItem.Text = "Log";
            this.logToolStripMenuItem.CheckedChanged += new System.EventHandler(this.logToolStripMenuItem_CheckedChanged);
            // 
            // dgCheckpoints
            // 
            this.dgCheckpoints.AllowUserToResizeColumns = false;
            this.dgCheckpoints.AllowUserToResizeRows = false;
            this.dgCheckpoints.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgCheckpoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCheckpoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgCheckpoints.Location = new System.Drawing.Point(3, 3);
            this.dgCheckpoints.Name = "dgCheckpoints";
            this.dgCheckpoints.RowHeadersVisible = false;
            this.dgCheckpoints.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgCheckpoints.Size = new System.Drawing.Size(370, 42);
            this.dgCheckpoints.TabIndex = 3;
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(0, 24);
            this.scMain.Name = "scMain";
            this.scMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.scSeedsDescription);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.scMain.Size = new System.Drawing.Size(1363, 766);
            this.scMain.SplitterDistance = 694;
            this.scMain.TabIndex = 4;
            // 
            // scSeedsDescription
            // 
            this.scSeedsDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scSeedsDescription.Location = new System.Drawing.Point(0, 0);
            this.scSeedsDescription.Name = "scSeedsDescription";
            // 
            // scSeedsDescription.Panel1
            // 
            this.scSeedsDescription.Panel1.Controls.Add(this.tableLayoutPanel3);
            this.scSeedsDescription.Panel1MinSize = 650;
            // 
            // scSeedsDescription.Panel2
            // 
            this.scSeedsDescription.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.scSeedsDescription.Size = new System.Drawing.Size(1363, 694);
            this.scSeedsDescription.SplitterDistance = 746;
            this.scSeedsDescription.TabIndex = 3;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.scCategories, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(746, 694);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel5.Controls.Add(this.btSearch, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.tbSearch, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(746, 32);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // btSearch
            // 
            this.btSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btSearch.Location = new System.Drawing.Point(649, 3);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(94, 26);
            this.btSearch.TabIndex = 1;
            this.btSearch.Text = "Search";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbSearch.Location = new System.Drawing.Point(3, 3);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(640, 26);
            this.tbSearch.TabIndex = 0;
            this.tbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_KeyDown);
            this.tbSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbSearch_KeyUp);
            // 
            // scCategories
            // 
            this.scCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scCategories.Location = new System.Drawing.Point(3, 35);
            this.scCategories.Name = "scCategories";
            this.scCategories.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scCategories.Panel1
            // 
            this.scCategories.Panel1.Controls.Add(this.groupBox1);
            // 
            // scCategories.Panel2
            // 
            this.scCategories.Panel2.Controls.Add(this.dgSeeds);
            this.scCategories.Size = new System.Drawing.Size(740, 656);
            this.scCategories.SplitterDistance = 129;
            this.scCategories.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(740, 129);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Categories";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 136F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.lbCategories, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.tbCategoryFilter, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(734, 110);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // lbCategories
            // 
            this.tableLayoutPanel4.SetColumnSpan(this.lbCategories, 2);
            this.lbCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCategories.FormattingEnabled = true;
            this.lbCategories.Location = new System.Drawing.Point(3, 35);
            this.lbCategories.Name = "lbCategories";
            this.lbCategories.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbCategories.Size = new System.Drawing.Size(728, 72);
            this.lbCategories.TabIndex = 2;
            this.lbCategories.SelectedIndexChanged += new System.EventHandler(this.lbCategories_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(88, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 6, 0, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Filter:";
            // 
            // tbCategoryFilter
            // 
            this.tbCategoryFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCategoryFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbCategoryFilter.Location = new System.Drawing.Point(139, 3);
            this.tbCategoryFilter.Name = "tbCategoryFilter";
            this.tbCategoryFilter.Size = new System.Drawing.Size(592, 26);
            this.tbCategoryFilter.TabIndex = 3;
            this.tbCategoryFilter.TextChanged += new System.EventHandler(this.tbCategoryFilter_TextChanged);
            this.tbCategoryFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_KeyDown);
            // 
            // dgSeeds
            // 
            this.dgSeeds.AllowUserToAddRows = false;
            this.dgSeeds.AllowUserToDeleteRows = false;
            this.dgSeeds.AllowUserToResizeRows = false;
            this.dgSeeds.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgSeeds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSeeds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgSeeds.Location = new System.Drawing.Point(0, 0);
            this.dgSeeds.MultiSelect = false;
            this.dgSeeds.Name = "dgSeeds";
            this.dgSeeds.RowHeadersVisible = false;
            this.dgSeeds.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgSeeds.Size = new System.Drawing.Size(740, 523);
            this.dgSeeds.TabIndex = 1;
            this.dgSeeds.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSeeds_CellContentClick);
            this.dgSeeds.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgSeeds_ColumnHeaderMouseClick);
            this.dgSeeds.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgSeeds_DataBindingComplete);
            this.dgSeeds.SelectionChanged += new System.EventHandler(this.dgSeeds_SelectionChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.webSeed, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbSeed, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(613, 694);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.MouseEnter += new System.EventHandler(this.WebBrowser_MouseEnter);
            // 
            // tbSeed
            // 
            this.tbSeed.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tbSeed.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSeed.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbSeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbSeed.Location = new System.Drawing.Point(3, 3);
            this.tbSeed.Multiline = true;
            this.tbSeed.Name = "tbSeed";
            this.tbSeed.ReadOnly = true;
            this.tbSeed.Size = new System.Drawing.Size(607, 69);
            this.tbSeed.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btDownload);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 75);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(593, 24);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // btDownload
            // 
            this.btDownload.BackColor = System.Drawing.SystemColors.Control;
            this.btDownload.Location = new System.Drawing.Point(479, 0);
            this.btDownload.Margin = new System.Windows.Forms.Padding(0);
            this.btDownload.Name = "btDownload";
            this.btDownload.Size = new System.Drawing.Size(114, 23);
            this.btDownload.TabIndex = 3;
            this.btDownload.Text = "Download";
            this.btDownload.UseVisualStyleBackColor = false;
            this.btDownload.Click += new System.EventHandler(this.btDownload_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.63578F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.36422F));
            this.tableLayoutPanel2.Controls.Add(this.dgCheckpoints, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tbConsole, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1363, 68);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssSeedsCount,
            this.tsProgress});
            this.statusStrip1.Location = new System.Drawing.Point(0, 768);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1363, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssSeedsCount
            // 
            this.tssSeedsCount.Name = "tssSeedsCount";
            this.tssSeedsCount.Size = new System.Drawing.Size(109, 17);
            this.tssSeedsCount.Text = "toolStripStatusLabel1";
            // 
            // tsProgress
            // 
            this.tsProgress.MarqueeAnimationSpeed = 200;
            this.tsProgress.Name = "tsProgress";
            this.tsProgress.Size = new System.Drawing.Size(400, 16);
            this.tsProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.tsProgress.Visible = false;
            // 
            // webSeed
            // 
            this.webSeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webSeed.Location = new System.Drawing.Point(3, 102);
            this.webSeed.MinimumSize = new System.Drawing.Size(20, 20);
            this.webSeed.Name = "webSeed";
            this.webSeed.Size = new System.Drawing.Size(607, 589);
            this.webSeed.TabIndex = 5;
            this.webSeed.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webSeed_DocumentCompleted);
            // 
            // SwoopViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1363, 790);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.scMain);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1100, 800);
            this.Name = "SwoopViewForm";
            this.Text = "Swoop";
            this.Load += new System.EventHandler(this.SwoopViewForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCheckpoints)).EndInit();
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.scSeedsDescription.Panel1.ResumeLayout(false);
            this.scSeedsDescription.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scSeedsDescription)).EndInit();
            this.scSeedsDescription.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.scCategories.Panel1.ResumeLayout(false);
            this.scCategories.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scCategories)).EndInit();
            this.scCategories.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSeeds)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox tbConsole;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem swoopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem continueGrabToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgCheckpoints;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox tbSeed;
        private System.Windows.Forms.SplitContainer scSeedsDescription;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssSeedsCount;
        private System.Windows.Forms.ToolStripProgressBar tsProgress;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btDownload;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.SplitContainer scCategories;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.ListBox lbCategories;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCategoryFilter;
        private System.Windows.Forms.DataGridView dgSeeds;
        private System.Windows.Forms.WebBrowser webSeed;
    }
}