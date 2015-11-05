using System;
using System.Reflection;
using System.Windows.Forms;
using RutrackerManager.Api;

namespace RutrackerManager.Viewer
{
    public partial class RutrackerViewForm : Form
    {
        private readonly RutrackerInfoProvider TrackerInfo;

        public RutrackerViewForm(RutrackerInfoProvider trackerInfo)
        {
            InitializeComponent();
            TrackerInfo = trackerInfo;
        }

        private void RutrackerViewForm_Load(object sender, EventArgs e)
        {
            Text = "Rutracker Manager v." + Assembly.GetExecutingAssembly().GetName().Version;
            TrackerInfo.ContinueCollect();
        }
    }
}
