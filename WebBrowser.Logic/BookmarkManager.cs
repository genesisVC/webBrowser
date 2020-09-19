using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
            if (rows.Count != 0)
            {
                count = 0;
                foreach (var row in rows)
                {
                    if (row.Title.Equals(item.Title))
                    {
                        count++;
                        //adapter.Insert(item.URL, item.Title);
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
    }
}
