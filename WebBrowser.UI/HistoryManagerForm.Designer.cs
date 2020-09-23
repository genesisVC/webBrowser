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
            this.historySearch = new System.Windows.Forms.TextBox();
            this.historySearchButton = new System.Windows.Forms.Button();
            this.deleteHistoryElement = new System.Windows.Forms.Button();
            this.ClearHistoryContentButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HistoryManagerList
            // 
            this.HistoryManagerList.Dock = System.Windows.Forms.DockStyle.Right;
            this.HistoryManagerList.FormattingEnabled = true;
            this.HistoryManagerList.Location = new System.Drawing.Point(262, 0);
            this.HistoryManagerList.Name = "HistoryManagerList";
            this.HistoryManagerList.Size = new System.Drawing.Size(800, 583);
            this.HistoryManagerList.TabIndex = 0;
            // 
            // historySearch
            // 
            this.historySearch.Location = new System.Drawing.Point(34, 35);
            this.historySearch.Name = "historySearch";
            this.historySearch.Size = new System.Drawing.Size(182, 20);
            this.historySearch.TabIndex = 1;
            this.historySearch.TextChanged += new System.EventHandler(this.historySearch_TextChanged);
            // 
            // historySearchButton
            // 
            this.historySearchButton.Location = new System.Drawing.Point(78, 62);
            this.historySearchButton.Name = "historySearchButton";
            this.historySearchButton.Size = new System.Drawing.Size(93, 23);
            this.historySearchButton.TabIndex = 2;
            this.historySearchButton.Text = "Search History";
            this.historySearchButton.UseVisualStyleBackColor = true;
            this.historySearchButton.Click += new System.EventHandler(this.historySearchButton_Click);
            // 
            // deleteHistoryElement
            // 
            this.deleteHistoryElement.Location = new System.Drawing.Point(63, 142);
            this.deleteHistoryElement.Name = "deleteHistoryElement";
            this.deleteHistoryElement.Size = new System.Drawing.Size(126, 27);
            this.deleteHistoryElement.TabIndex = 3;
            this.deleteHistoryElement.Text = "Delete";
            this.deleteHistoryElement.UseVisualStyleBackColor = true;
            // 
            // ClearHistoryContentButton
            // 
            this.ClearHistoryContentButton.Location = new System.Drawing.Point(63, 203);
            this.ClearHistoryContentButton.Name = "ClearHistoryContentButton";
            this.ClearHistoryContentButton.Size = new System.Drawing.Size(126, 23);
            this.ClearHistoryContentButton.TabIndex = 4;
            this.ClearHistoryContentButton.Text = "Clear Content";
            this.ClearHistoryContentButton.UseVisualStyleBackColor = true;
            // 
            // HistoryManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 583);
            this.Controls.Add(this.ClearHistoryContentButton);
            this.Controls.Add(this.deleteHistoryElement);
            this.Controls.Add(this.historySearchButton);
            this.Controls.Add(this.historySearch);
            this.Controls.Add(this.HistoryManagerList);
            this.Name = "HistoryManagerForm";
            this.Text = "HistoryManager";
            this.Load += new System.EventHandler(this.HistoryManager_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox HistoryManagerList;
        private System.Windows.Forms.TextBox historySearch;
        private System.Windows.Forms.Button historySearchButton;
        private System.Windows.Forms.Button deleteHistoryElement;
        private System.Windows.Forms.Button ClearHistoryContentButton;
    }
}