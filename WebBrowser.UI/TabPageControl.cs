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

namespace WebBrowser.UI
{
    public partial class TabPagesControl : UserControl
    {
        Stack<string> backPages = new Stack<string>();
        Stack<string> forwardPages = new Stack<string>();
        String currentUrl="";
        String previousUrl="";
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

            //webBrowser1.GoBack();
            currentUrl = webBrowser1.Url.ToString();
            forwardPages.Push(currentUrl);
            if (backPages.Count() == 0)
            {
                webBrowser1.Navigate("Http://google.com");
            }
            else
            {
              webBrowser1.Navigate (backPages.Pop());
            }
            
        }

        private void forwardButton_Click(object sender, EventArgs e)
        {
            // webBrowser1.GoForward();
            currentUrl = webBrowser1.Url.ToString();
            backPages.Push(currentUrl);
            if (forwardPages.Count() == 0) 
            {
                webBrowser1.Navigate("Http://google.com");
            }
            else
            {
                webBrowser1.Navigate(forwardPages.Pop());
            }

        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void addressBar_Click(object sender, EventArgs e)
        {
           
        }
        private void addressBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                currentUrl = webBrowser1.Url.ToString();
                previousUrl = currentUrl;
                if (previousUrl != "")
                {
                    backPages.Push(previousUrl);
                }

                webBrowser1.Navigate(addressBar.Text);
                
            }
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            previousUrl = currentUrl;
            webBrowser1.Navigate(addressBar.Text);
            currentUrl = webBrowser1.Url.ToString();
            
          /*  backPages.Push("www.google.com");
            forwardPages.Push(currentUrl);*/
        }

        /**private void exitWebBrowserToolStripMenuItem_Click(object sender, EventArgs e)
         {
             //this.Close();
         }*/

        /* private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
         {
             MessageBox.Show("Developer: Genesis Villalvazo\n"
                             + "Student ID: gdv0001\n"
                              + "Date Created: 9/2020");
         }*/
    }
}
