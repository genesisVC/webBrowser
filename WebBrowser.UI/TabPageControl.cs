using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Drawing.Text;

namespace WebBrowser.UI
{
    public partial class TabPagesControl : UserControl
    {
        Stack<string> backPages = new Stack<string>();
        Stack<string> forwardPages = new Stack<string>();
        String currentUrl="";
        String previousUrl="";
        private System.Windows.Forms.WebBrowser webBrowser =
            new System.Windows.Forms.WebBrowser();
        private TabControl tabControlX;
        GV_Browser newTab;


        public TabPagesControl()
        {
            InitializeComponent();
            // Load the user's home page.
            webBrowser1.Navigate("Http://google.com");
            webBrowser1.ScriptErrorsSuppressed = true;
            //webBrowser.ScriptErrorsSuppressed = true;
            backPages.Clear();
            forwardPages.Clear();
            
            
            
        }



        private void toolStripTextBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void backButton_Click(object sender, EventArgs e)
        {

            webBrowser = tabControl1.SelectedTab.Controls[0] as
                System.Windows.Forms.WebBrowser;
            currentUrl = webBrowser.Url.ToString();
            forwardPages.Push(currentUrl);
            /*if (backPages.Count() == 0)
            {
                webBrowser.Navigate("Http://google.com");
            }*/
            if (webBrowser.CanGoBack)
            {
                webBrowser.Navigate(backPages.Pop());
            }
           
        }

        private void forwardButton_Click(object sender, EventArgs e)
        {
            // webBrowser1.GoForward();
            webBrowser = tabControl1.SelectedTab.Controls[0] as
                System.Windows.Forms.WebBrowser;

            currentUrl = webBrowser.Url.ToString();
            backPages.Push(currentUrl);
            /*if (forwardPages.Count() == 0) 
            {
                webBrowser.Navigate("Http://google.com");
            }*/
            if (forwardPages.Count() != 0) 
            {
                webBrowser.Navigate(forwardPages.Pop());
                addressBar.Text = f
            }

        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            webBrowser = tabControl1.SelectedTab.Controls[0] as
                System.Windows.Forms.WebBrowser;
            webBrowser.Refresh();
        }

        private void addressBar_Click(object sender, EventArgs e)
        {
           
        }
        public void addressBar_KeyDown(object sender, KeyEventArgs e)
        {
            
            webBrowser = tabControl1.SelectedTab.Controls[0] as
                System.Windows.Forms.WebBrowser;
            if (e.KeyCode == Keys.Enter)
            {
                currentUrl = webBrowser.Url.ToString();
                previousUrl = currentUrl;
                if (previousUrl != "")
                {
                    backPages.Push(previousUrl);
                }


                webBrowser.Navigate(addressBar.Text);
               


            }
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            webBrowser = tabControl1.SelectedTab.Controls[0] as
                System.Windows.Forms.WebBrowser;
            currentUrl = webBrowser.Url.ToString();
            previousUrl = currentUrl;
            if (previousUrl != "")
            {
                backPages.Push(previousUrl);
            }
            

            webBrowser.Navigate(addressBar.Text);


        }

        public void addTab()
        {
            /*TabControl dynamicTabControl = new TabControl();
            Controls.Add(dynamicTabControl);*/
           /* string title = "TabPage " + (tabControl1.TabCount + 1).ToString();

            TabPage myTabPage = new TabPage(title);
            tabControl1.TabPages.Add(myTabPage);*/
        }
        public void webBrowswer_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            addressBar.Text = webBrowser.Url.ToString();
        }
       public void createBrowser()
        {
            //addressBar_KeyDown(object sender, KeyEventArgs e);

           /* // Delete This
            GV_Browser newTab = new GV_Browser();
            webBrowser = new System.Windows.Forms.WebBrowser();
            tabControlX = new TabControl();
            webBrowser.ScriptErrorsSuppressed = true;
            webBrowser.Location = new Point(0, 0);
            webBrowser.Dock = DockStyle.Fill;
            webBrowser.Visible = true;
            //webBrowser.DocumentCompleted += webBrowser_DocumentCompleted;
            webBrowser.Navigate("http://bing.com");

            tabControlX.Anchor = AnchorStyles.Top & AnchorStyles.Bottom & AnchorStyles.Right & AnchorStyles.Left;
            tabControlX.TabPages.Add("New Tab");
            tabControlX.SelectTab(0);
            tabControlX.SelectedTab.Controls.Add(webBrowser);
            tabControlX.Size = new Size(500, 300);
            tabControlX.Location = new Point(0, 100);
            
            newTab.tabPagesControl1.Controls.Add(webBrowser);
            //tabPage1.Controls.Add(webBrowser);
            //tabPagesControl1.tabControl1.TabPages.Add(myTabPage); */
        }
    }
}
