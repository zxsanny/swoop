namespace uHelper
{
    partial class MainForm
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
            this.dgViewTopics = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zxTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbOut = new System.Windows.Forms.TextBox();
            this.testGetCookiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bDownloadFiles = new System.Windows.Forms.Button();
            this.lbForums = new System.Windows.Forms.ListBox();
            this.bAddForum = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewTopics)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgViewTopics
            // 
            this.dgViewTopics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgViewTopics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgViewTopics.Location = new System.Drawing.Point(280, 3);
            this.dgViewTopics.Name = "dgViewTopics";
            this.tableLayoutPanel1.SetRowSpan(this.dgViewTopics, 2);
            this.dgViewTopics.Size = new System.Drawing.Size(1130, 788);
            this.dgViewTopics.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.zxTestToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1413, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // zxTestToolStripMenuItem
            // 
            this.zxTestToolStripMenuItem.Name = "zxTestToolStripMenuItem";
            this.zxTestToolStripMenuItem.Size = new System.Drawing.Size(12, 20);
            // 
            // tbOut
            // 
            this.tbOut.Location = new System.Drawing.Point(280, 797);
            this.tbOut.Multiline = true;
            this.tbOut.Name = "tbOut";
            this.tbOut.Size = new System.Drawing.Size(556, 24);
            this.tbOut.TabIndex = 2;
            // 
            // testGetCookiesToolStripMenuItem
            // 
            this.testGetCookiesToolStripMenuItem.Name = "testGetCookiesToolStripMenuItem";
            this.testGetCookiesToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // bDownloadFiles
            // 
            this.bDownloadFiles.Location = new System.Drawing.Point(1291, 28);
            this.bDownloadFiles.Name = "bDownloadFiles";
            this.bDownloadFiles.Size = new System.Drawing.Size(110, 23);
            this.bDownloadFiles.TabIndex = 4;
            this.bDownloadFiles.Text = "Download files";
            this.bDownloadFiles.UseVisualStyleBackColor = true;
            this.bDownloadFiles.Click += new System.EventHandler(this.bDownloadFiles_Click);
            // 
            // lbForums
            // 
            this.lbForums.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbForums.FormattingEnabled = true;
            this.lbForums.Location = new System.Drawing.Point(3, 34);
            this.lbForums.Name = "lbForums";
            this.lbForums.Size = new System.Drawing.Size(271, 757);
            this.lbForums.TabIndex = 5;
            this.lbForums.SelectedIndexChanged += new System.EventHandler(this.lbForums_SelectedIndexChanged);
            // 
            // bAddForum
            // 
            this.bAddForum.Location = new System.Drawing.Point(3, 3);
            this.bAddForum.Name = "bAddForum";
            this.bAddForum.Size = new System.Drawing.Size(85, 25);
            this.bAddForum.TabIndex = 6;
            this.bAddForum.Text = "Add currentForum";
            this.bAddForum.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 277F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.bAddForum, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbForums, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgViewTopics, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbOut, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1413, 824);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1413, 848);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.bDownloadFiles);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "uHelper";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgViewTopics)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgViewTopics;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TextBox tbOut;
        private System.Windows.Forms.ToolStripMenuItem zxTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testGetCookiesToolStripMenuItem;
        private System.Windows.Forms.Button bDownloadFiles;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ListBox lbForums;
        private System.Windows.Forms.Button bAddForum;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}