using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebBrowser.Data.BookmarkDataSetTableAdapters;

namespace WebBrowser.Logic
{
    public class BookmarkManager
    {
        private static int count;
        public static void AddItem(BookmarkItem item)
        {
            var adapter = new BookmarkTableAdapter();
            var rows = adapter.GetData();
            //Ensure no duplicate entries are added to table.
            if (rows.Count != 0)
            {
                count = 0;
                foreach (var row in rows)
                {
                    if (row.Title.Equals(item.Title))
                    {
                        count++;
                        
                    }
                } 
                if (count == 0)
                {
                adapter.Insert(item.URL, item.Title);
            
                } 
            }

           
            else
            {
                adapter.Insert(item.URL, item.Title);
            }
        }

        public static List<BookmarkItem> GetItems()
        {
            var adapter = new BookmarkTableAdapter();
            var results = new List<BookmarkItem>();
            try
            {
                var rows = adapter.GetData();

            foreach (var row in rows)
            {
                var item = new BookmarkItem();
                item.URL = row.URL;
                item.Title = row.Title;
                

                results.Add(item);
            }
                return results;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return null;
            
            
        }

        public static void deleteItem(BookmarkItem item)
        {
            var adapter = new BookmarkTableAdapter();
            adapter.DeleteQuery(item.URL,item.Title);
        }
    }
}
