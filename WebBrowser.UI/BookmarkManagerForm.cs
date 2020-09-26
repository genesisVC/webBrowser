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

        List<string> BookmarkCollection = new List<string>();
        public BookmarkManagerForm()
        {
            InitializeComponent();
        }

        private void BookmarkManagerForm_Load(object sender, EventArgs e)
        {
            var items = BookmarkManager.GetItems();
            


            foreach (var item in items)
            {
                BookmarkManagerList.Items.Add(string.Format("{0}-({1})", item.Title, item.URL));
                BookmarkCollection.Add(string.Format("{0}-({1})", item.Title, item.URL));
            }

           
        }

        private void bookmarkSearchButton_Click(object sender, EventArgs e)
        {
            BookmarkManagerList.Items.Clear();
            foreach(string str in BookmarkCollection)
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
                if (selected != null && selected.Equals(str1))
                {
                    BookmarkManager.deleteItem(item);
                    int index = BookmarkCollection.IndexOf(str1);
                    BookmarkCollection.RemoveAt(index);
                    BookmarkManagerList.Items.Remove(selected);

                }
            }
            if (selected == null)
            {
                MessageBox.Show("Please select item to delete");
            }
        }
    }   
}
