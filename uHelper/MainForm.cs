using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using TorrentParser.Entities;
using uHelper.webAPI;
using uHelper.webAPI.Domains;
using uHelper.Extensions;

namespace uHelper
{
    public partial class MainForm : Form
    {
        public string Path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\uTorrent";
        private ForumInfo CurrentForum;
        private readonly ITrackerInfoProvider TrackerInfo;

        public MainForm(ITrackerInfoProvider trackerInfo)
        {
            InitializeComponent();
            TrackerInfo = trackerInfo;

            //TODO: For Testing purposes only, remove this code
            lbForums.DataSource = new[]
            {
                "http://rutracker.org/currentForum/viewforum.php?f=2282"
            };
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            Text = "uHelper v." + Assembly.GetExecutingAssembly().GetName().Version;
            var di = new DirectoryInfo(Path);
            var file = di.GetFiles("*.torrent").OrderByDescending(x => x.Length).ToList()[2];
                
            var bObject = new FileStream(file.FullName, FileMode.Open).CreateBObject();
            var s = bObject.Print();
            tbOut.Text = s;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bDownloadFiles_Click(object sender, EventArgs e)
        {

            foreach (var topic in CurrentForum.Topics.Where(x => x.TorrentLink != null))
            {
                string filename;
                var stream = TrackerInfo.GetTorrentFile(topic.TorrentLink, out filename);
                stream.ToFile("D:\\Downloads\\" + filename);
                Thread.Sleep(6000);
            }
           
        }

        private void lbForums_SelectedIndexChanged(object sender, EventArgs e)
        {
            var forumUrl = lbForums.SelectedItem.ToString();
            CurrentForum = TrackerInfo.GetForumInfo(forumUrl);
            dgViewTopics.DataSource = CurrentForum.Topics;
        }
    }
}
