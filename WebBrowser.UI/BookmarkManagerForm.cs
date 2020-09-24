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

        List<string> listCollection = new List<string>();
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
                listCollection.Add(string.Format("{0}-({1})", item.Title, item.URL));
            }

           
        }

        private void bookmarkSearchButton_Click(object sender, EventArgs e)
        {
            BookmarkManagerList.Items.Clear();
            foreach(string str in listCollection)
            {
                if (str.Contains(bookmarkSearch.Text))
                {
                    BookmarkManagerList.Items.Add(str);
                }
            }
            try
            {
                BookmarkManagerList.SetSelected(0, true);

            }
            catch
            {
                MessageBox.Show("item is not in bookmarks");
            }
        }

        private void deleteBookmarkButton_Click(object sender, EventArgs e)
        {
            var items = BookmarkManager.GetItems();
            var selected = BookmarkManagerList.SelectedItem;
            foreach (var item in items)
            {
                string str1 = (string.Format("{0}-({1})", item.Title, item.URL));
                if (selected.Equals(str1))
                {
                    BookmarkManager.deleteItem(item);
                    BookmarkManagerList.Items.Remove(selected);
                }
            }
        }
    }   
}
