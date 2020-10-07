﻿using System;
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
        private Stack<string> backPages = new Stack<string>();
        private Stack<string> forwardPages = new Stack<string>();
        private String currentUrl="";
        private String previousUrl="";
        private String title = "";
        private String source = "";
        private System.Windows.Forms.WebBrowser webBrowser =
            new System.Windows.Forms.WebBrowser();
        string body;
        


        public TabPagesControl()
        {
            InitializeComponent();
            // Load the user's home page.
            webBrowser1.Navigate("Http://google.com");
            webBrowser1.ScriptErrorsSuppressed = true;
           // webBrowser.ProgressChanged += new WebBrowserProgressChangedEventHandler(webBrowser_ProgressChange);
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
                webBrowser.ProgressChanged += new WebBrowserProgressChangedEventHandler(webBrowser_ProgressChange);
                webBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser_DocumentCompleted);
                webBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser_DocumentCompleted2);
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
                webBrowser.ProgressChanged += new WebBrowserProgressChangedEventHandler(webBrowser_ProgressChange);
                webBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser_DocumentCompleted);
                webBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser_DocumentCompleted2);
            }

        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            webBrowser = tabControl1.SelectedTab.Controls[0] as
                System.Windows.Forms.WebBrowser;
            webBrowser.Refresh();
            webBrowser.ProgressChanged += new WebBrowserProgressChangedEventHandler(webBrowser_ProgressChange);
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
                
               webBrowser.ProgressChanged += new WebBrowserProgressChangedEventHandler(webBrowser_ProgressChange);
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

            webBrowser.ProgressChanged += new WebBrowserProgressChangedEventHandler(webBrowser_ProgressChange);

            webBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser_DocumentCompleted);
           

        }

        private void bookmarkBtn_Click(object sender, EventArgs e)
        {
            webBrowser = tabControl1.SelectedTab.Controls[0] as
                System.Windows.Forms.WebBrowser;
            WebClient x = new WebClient();
            //currentUrl = webBrowser.Url.ToString();
            
                source = x.DownloadString(webBrowser.Url);
           
            string title = Regex.Match(source, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>",
            RegexOptions.IgnoreCase).Groups["Title"].Value;

            var item = new BookmarkItem();
            item.Title = title;
            item.URL = webBrowser.Url.ToString();
            BookmarkManager.AddItem(item);


        }
        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webBrowser = tabControl1.SelectedTab.Controls[0] as
                System.Windows.Forms.WebBrowser;
            /*if (webBrowser.ReadyState != WebBrowserReadyState.Complete)
                return;*/
            if (e.Url.AbsolutePath != (sender as System.Windows.Forms.WebBrowser).Url.AbsolutePath)
                return;
            if (body == webBrowser.Document.Body.InnerHtml) return;
             body = webBrowser.Document.Body.InnerHtml;
            WebClient x = new WebClient();
            try
            {
                source = x.DownloadString(webBrowser.Url);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Please enter valid URL.");
                MessageBox.Show(ex.ToString());
                
            }
            title = Regex.Match(source, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>",
            RegexOptions.IgnoreCase).Groups["Title"].Value;

            var item = new HistoryItem();
            item.Date = DateTime.Now;
            item.Title = title;
            item.URL = webBrowser.Url.ToString();
            //MessageBox.Show(item.Title);
            HistoryManager.AddItem(item);
            webBrowser.StatusTextChanged += webBrowser_StatusTextChanged;


        }
        private void webBrowser_DocumentCompleted2(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

                addressBar.Text = webBrowser.Url.ToString();
            
        }

        private void webBrowser_ProgressChange(Object sender, WebBrowserProgressChangedEventArgs e)
        {
            

            ProgressBar1.Maximum =  (int)e.MaximumProgress;
            
            try
            {
                if ((e.CurrentProgress > 0))
                {
                    ProgressBar1.Value = (int)e.CurrentProgress;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

     
        }
        private void webBrowser_StatusTextChanged(object sender, EventArgs e)
        {
            LoadingLabel1.Text = webBrowser.StatusText;

        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            webBrowser = tabControl1.SelectedTab.Controls[0] as
               System.Windows.Forms.WebBrowser;
            webBrowser.Navigate("www.google.com");
        }

        public void printButton_Click(object sender, EventArgs e)
        {
            webBrowser = tabControl1.SelectedTab.Controls[0] as
               System.Windows.Forms.WebBrowser;
            PrintDialog printDialog = new PrintDialog();

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                webBrowser.Print();
            }
        
            
           
        }
    }
}
