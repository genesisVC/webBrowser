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
        


        public TabPagesControl()
        {
            InitializeComponent();
            // Load the user's home page.
            webBrowser1.Navigate("Http://google.com");
            webBrowser1.ScriptErrorsSuppressed = true;
          
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

            if (backPages.Count() != 0)
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
            
            if (forwardPages.Count() != 0) 
            {
                webBrowser.Navigate(forwardPages.Pop());
                
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

       
       
      
    }
}
