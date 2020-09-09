using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowser.UI
{
    public partial class GV_Browser : Form
    {
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
           /* string title = "TabPage " + (tabs.tabControl1.TabCount + 1).ToString();
            TabPage myTabPage = new TabPage(title);*/
         
        }
    }
}
