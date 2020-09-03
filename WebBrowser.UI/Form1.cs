﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Load the user's home page.
            webBrowser1.GoHome();
            
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }
        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                webBrowser1.Navigate(toolStripTextBox1.Text);
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(toolStripTextBox1.Text);
        }

        private void toolStripTextBox1_Click_1(object sender, EventArgs e)
        {

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
    }
}
