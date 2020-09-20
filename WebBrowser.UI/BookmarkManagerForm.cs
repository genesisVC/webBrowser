using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebBrowser.Logic;

namespace WebBrowser.UI
{
    public partial class BookmarkManagerForm : Form
    {
        public BookmarkManagerForm()
        {
            InitializeComponent();
        }

        private void BookmarkManagerForm_Load(object sender, EventArgs e)
        {
            var items = BookmarkManager.GetItems();
            //var items2 = BookmarkManager.GetItems();
            //BookmarkManagerList.Items.Clear();


            foreach (var item in items)
            {
                BookmarkManagerList.Items.Add(string.Format("{0}-({1})", item.Title, item.URL));
            }

           
        }

    }   
}
