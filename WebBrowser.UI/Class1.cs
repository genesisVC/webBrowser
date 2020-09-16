using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser.UI
{
    class Class1
    {

        public string url { get; set; }
        public String Title { get; set; }

        public DateTime Date { get; set; }
        public string URL { get; set; }
        public string Title { get; set; }

        public static void AddItem(HistoryItem item)
        {
            var adapter = new HistoryTableAdapter();
            adapter.Insert(item.url, item.Title, item.Date);
        }

        public static List<HistoryItem> GetItems()
        {
            var adapter = new HistoryTableAdapter();
            var results = new List<HistoryItem>();
            var rows = adapter.GetData();

            foreach (var row in rows)
            {
                var item = new HistoryItem();
                item.url = row.url;
                item.Title = row.Title;
                item.Date = row.Date;

                results.Add(item);
            }
            return results;
        }
    }
}
