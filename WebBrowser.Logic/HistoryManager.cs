using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebBrowser.Data;
using WebBrowser.Data.HistoryDataSetTableAdapters;

namespace WebBrowser.Logic
{
    public class HistoryManager
    {
        public static void AddItem(HistoryItem item)
        {
            var adapter = new HistoryTableAdapter();
            try
            {
                adapter.Insert(item.URL, item.Title, item.Date);
            }
            catch
            {
                MessageBox.Show("Please rebuild before running to" +
                    " not get this error. Something about running |DataDirectory|" +
                    " reference keeps making this occur every now and then.");
                Application.Exit(); 
            }
        }

        public static List<HistoryItem> GetItems()
        {
            var adapter = new HistoryTableAdapter();
            var results = new List<HistoryItem>();

            try
            {
                var rows = adapter.GetData();

                foreach (var row in rows)
                {
                    var item = new HistoryItem();
                    item.URL = row.URL;
                    item.Title = row.Title;
                    item.Date = row.Date;

                    results.Add(item);
                }
                return results;



            }
            catch
            {
                MessageBox.Show("Please rebuild before running to" +
                    " not get this error. Something about running |DataDirectory|" +
                    " reference keeps making this occur every now and then.");
                Application.Exit();
            }

            return null;
        }

        public static void DeleteItem(HistoryItem item)
        {
            //HistoryDataSet.HistoryDataTable dataTable = new HistoryDataSet.HistoryDataTable();
            var adapter = new HistoryTableAdapter();
            adapter.DeleteQuery(item.URL,item.Title,item.Date);
           //adapter.Update(dataTable);
        }
        public static void ClearItems(HistoryItem item)
        {
            var adapter = new HistoryTableAdapter();
            
        }
    }
}
