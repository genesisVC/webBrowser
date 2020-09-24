namespace WebBrowser.UI
{
    partial class BookmarkManagerForm
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
            this.BookmarkManagerList = new System.Windows.Forms.ListBox();
            this.bookmarkSearch = new System.Windows.Forms.TextBox();
            this.bookmarkSearchButton = new System.Windows.Forms.Button();
            this.deleteBookmarkButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BookmarkManagerList
            // 
            this.BookmarkManagerList.Dock = System.Windows.Forms.DockStyle.Right;
            this.BookmarkManagerList.FormattingEnabled = true;
            this.BookmarkManagerList.Location = new System.Drawing.Point(155, 0);
            this.BookmarkManagerList.Name = "BookmarkManagerList";
            this.BookmarkManagerList.Size = new System.Drawing.Size(645, 450);
            this.BookmarkManagerList.TabIndex = 0;
            // 
            // bookmarkSearch
            // 
            this.bookmarkSearch.Location = new System.Drawing.Point(12, 41);
            this.bookmarkSearch.Name = "bookmarkSearch";
            this.bookmarkSearch.Size = new System.Drawing.Size(110, 20);
            this.bookmarkSearch.TabIndex = 1;
            // 
            // bookmarkSearchButton
            // 
            this.bookmarkSearchButton.Location = new System.Drawing.Point(12, 67);
            this.bookmarkSearchButton.Name = "bookmarkSearchButton";
            this.bookmarkSearchButton.Size = new System.Drawing.Size(110, 33);
            this.bookmarkSearchButton.TabIndex = 2;
            this.bookmarkSearchButton.Text = "Search Bookmark";
            this.bookmarkSearchButton.UseVisualStyleBackColor = true;
            this.bookmarkSearchButton.Click += new System.EventHandler(this.bookmarkSearchButton_Click);
            // 
            // deleteBookmarkButton
            // 
            this.deleteBookmarkButton.Location = new System.Drawing.Point(25, 135);
            this.deleteBookmarkButton.Name = "deleteBookmarkButton";
            this.deleteBookmarkButton.Size = new System.Drawing.Size(75, 23);
            this.deleteBookmarkButton.TabIndex = 3;
            this.deleteBookmarkButton.Text = "Delete Bookmark";
            this.deleteBookmarkButton.UseVisualStyleBackColor = true;
            this.deleteBookmarkButton.Click += new System.EventHandler(this.deleteBookmarkButton_Click);
            // 
            // BookmarkManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.deleteBookmarkButton);
            this.Controls.Add(this.bookmarkSearchButton);
            this.Controls.Add(this.bookmarkSearch);
            this.Controls.Add(this.BookmarkManagerList);
            this.Name = "BookmarkManagerForm";
            this.Text = "BookmarkManager";
            this.Load += new System.EventHandler(this.BookmarkManagerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox BookmarkManagerList;
        private System.Windows.Forms.TextBox bookmarkSearch;
        private System.Windows.Forms.Button bookmarkSearchButton;
        private System.Windows.Forms.Button deleteBookmarkButton;
    }
}