namespace RutrackerManager.Viewer
{
    partial class RutrackerViewForm
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
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.dgForums = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgForums)).BeginInit();
            this.SuspendLayout();
            // 
            // dgForums
            // 
            this.dgForums.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgForums.Location = new System.Drawing.Point(134, 111);
            this.dgForums.Name = "dgForums";
            this.dgForums.Size = new System.Drawing.Size(1227, 565);
            this.dgForums.TabIndex = 0;
            // 
            // RutrackerViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1507, 797);
            this.Controls.Add(this.dgForums);
            this.Name = "RutrackerViewForm";
            this.Text = "RutrackerViewForm";
            this.Load += new System.EventHandler(this.RutrackerViewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgForums)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridView dgForums;
    }
}