namespace WebBrowser.UI
{
    partial class HistoryManagerForm
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
            this.HistoryManagerList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // HistoryManagerList
            // 
            this.HistoryManagerList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HistoryManagerList.FormattingEnabled = true;
            this.HistoryManagerList.Location = new System.Drawing.Point(0, 0);
            this.HistoryManagerList.Name = "HistoryManagerList";
            this.HistoryManagerList.Size = new System.Drawing.Size(800, 450);
            this.HistoryManagerList.TabIndex = 0;
            // 
            // HistoryManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.HistoryManagerList);
            this.Name = "HistoryManagerForm";
            this.Text = "HistoryManager";
            this.Load += new System.EventHandler(this.HistoryManager_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox HistoryManagerList;
    }
}