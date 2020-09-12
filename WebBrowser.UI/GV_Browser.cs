using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private TabControl tabControlX;
        
       
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

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
           /* int height = Screen.PrimaryScreen.Bounds.Height;
            int width = Screen.PrimaryScreen.Bounds.Width;*/
           // this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void newTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPagesControl tabs = new TabPagesControl();
            //tabs.addTab();

            string title = "TabPage " + (tabs.tabControl1.TabCount + 1).ToString();

            myTabPage = new TabPage(title);

            webBrowser = new System.Windows.Forms.WebBrowser();
              //webBrowser.DocumentCompleted += tabs.webBrowswer_DocumentCompleted;
            tabPagesControl1.tabControl1.TabPages.Add(myTabPage);
            tabPagesControl1.tabControl1.SelectedTab = myTabPage;

          
            tabs.webBrowser1.Parent = myTabPage;
            tabs.webBrowser1.Dock = DockStyle.Fill;
            
            webBrowser.Navigate("www.google.com");


            /* webBrowser = new System.Windows.Forms.WebBrowser();
             tabControlX = new TabControl();
             webBrowser.ScriptErrorsSuppressed = true;
             webBrowser.Location = new Point(0, 0);
             webBrowser.Dock = DockStyle.Fill;
             webBrowser.Visible = true;
             webBrowser.DocumentCompleted += tabs.webBrowswer_DocumentCompleted;

             tabControlX.Anchor = AnchorStyles.Top & AnchorStyles.Bottom & AnchorStyles.Right & AnchorStyles.Left;
             tabControlX.TabPages.Add("New Tab");
             tabControlX.SelectTab(0);
             tabControlX.SelectedTab.Controls.Add(webBrowser);
             tabControlX.Size = new Size(500, 300);
             tabControlX.Location = new Point(0, 100);

             tabPagesControl1.Controls.Add(webBrowser);*/

            /*//tabs.webBrowser1.Parent = myTabPage;
            tabs.webBrowser1.Dock = DockStyle.Fill;
            tabs.webBrowser1.Navigate("www.google.com");*/


            //tabs.webBrowser1.Focus(myTabPage);
            // tabs.tabControl1.Select(myTabPage);
            // tabs.createBrowser();




        }

        private void closeCurrentTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabPagesControl1.tabControl1.TabPages.Remove(tabPagesControl1.tabControl1.SelectedTab);
        }

        
    }
}
