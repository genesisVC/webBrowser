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
using WebBrowser.Logic;
using System.Net;
using System.Security.Policy;
using System.Text.RegularExpressions;

namespace WebBrowser.UI
{
    public partial class TabPagesControl : UserControl
    {
        Stack<string> backPages = new Stack<string>();
        Stack<string> forwardPages = new Stack<string>();
        String currentUrl="";
        String previousUrl="";
        String title;
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
                webBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser_DocumentCompleted);
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
                webBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser_DocumentCompleted);

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
                webBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser_DocumentCompleted);


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
            
            webBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser_DocumentCompleted);
            

            
            
        }

        private void bookmarkBtn_Click(object sender, EventArgs e)
        {
            string source;
            WebClient x = new WebClient();
            if (webBrowser.Url != null)
            {
                source = x.DownloadString(webBrowser.Url);
            }
            else
            {
                source = x.DownloadString("www.google.com");
            }
            string title = Regex.Match(source, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>",
            RegexOptions.IgnoreCase).Groups["Title"].Value;

            var item = new BookmarkItem();
            item.Title = title;
            item.URL = webBrowser.Url.ToString();
            BookmarkManager.AddItem(item);


        }
        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
                
            WebClient x = new WebClient();
            string source = x.DownloadString(webBrowser.Url);
          
            title = Regex.Match(source, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>",
            RegexOptions.IgnoreCase).Groups["Title"].Value;

            var item = new HistoryItem();
            item.Date = DateTime.Now;
            item.Title = title;
            item.URL = webBrowser.Url.ToString();
            //MessageBox.Show(item.Title);
            HistoryManager.AddItem(item);

            

        }
    }
}
