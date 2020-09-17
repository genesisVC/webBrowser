using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowser.UI
{
    public partial class GV_Browser : Form
    {
        TabPage myTabPage;
        private System.Windows.Forms.WebBrowser webBrowser;
        int i = 1;
        
       
        public GV_Browser()
        {
            InitializeComponent();
            

        }

       
        
        private void exitWebBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Developer: Genesis Villalvazo\n" 
                            + "Student ID: gdv0001\n"
                             + "Date Created: 9/2020");
        }

      

        private void newTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPagesControl tabs = new TabPagesControl();

           
            //string title = "New Tab" + (tabs.tabControl1.TabCount + 1).ToString();
            string title = "New Tab" + (tabs.tabControl1.TabCount + i++).ToString();

            myTabPage = new TabPage(title);

            webBrowser = new System.Windows.Forms.WebBrowser();
              
            tabPagesControl1.tabControl1.TabPages.Add(myTabPage);
            tabPagesControl1.tabControl1.SelectedTab = myTabPage;

            webBrowser.Parent = myTabPage;
            
            webBrowser.Dock = DockStyle.Fill;
            
            webBrowser.Navigate("www.google.com");

            webBrowser.ScriptErrorsSuppressed = true;
        }

        
        private void closeCurrentTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabPagesControl1.tabControl1.TabPages.Remove(tabPagesControl1.tabControl1.SelectedTab);
        }

        private void manageHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var itemsForm = new HistoryManagerForm();
            itemsForm.ShowDialog();
        }

        private void manageBookmarksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var itemsForm = new BookmarkManagerForm();
            itemsForm.ShowDialog();
        }
    }
}
