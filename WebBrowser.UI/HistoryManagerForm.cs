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
    public partial class HistoryManagerForm : Form
    {
        List<string> listCollection = new List<string>();
        List<HistoryItem> deleteItems = new List<HistoryItem>();
        public HistoryManagerForm()
        {
            InitializeComponent();
            listCollection.Clear();
        }

        private void HistoryManager_Load(object sender, EventArgs e)
        {
            var items = HistoryManager.GetItems();
            
           
                foreach (var item in items)
                {

                    HistoryManagerList.Items.Add(string.Format("[{0}]--{1}-({2})", item.Date, item.Title, item.URL));
                    listCollection.Add(string.Format("[{0}]--{1}-({2})", item.Date, item.Title, item.URL));
                    
                }
            }

        private void historySearchButton_Click(object sender, EventArgs e)
        {
            HistoryManagerList.Items.Clear();
            //int i = 0;
            foreach(string str in listCollection)
            {
                if (str.Contains(historySearch.Text))
                {
                   
                    HistoryManagerList.Items.Add(str);
                }

                
            }
            //handle not found error.
            try
            {
                HistoryManagerList.SetSelected(0, true);
            }
            catch
            {
                MessageBox.Show("Item is not in list.");
            }
      

        }

        private void historySearch_TextChanged(object sender, EventArgs e)
        {
           /* if (string.IsNullOrEmpty(historySearch.Text) == false)
            {
                HistoryManagerList.Items.Clear();
                foreach(string str in listCollection)
                {
                    if (str.Contains(historySearch.Text))
                    {
                        HistoryManagerList.Items.Add(str);
                    }
                }
            }*/
        }

        private void deleteHistoryElement_Click(object sender, EventArgs e)
        {
            var items = HistoryManager.GetItems();
            var selected = HistoryManagerList.SelectedItem;
            foreach (var item in items)
            {
                string str1 =(string.Format("[{0}]--{1}-({2})", item.Date, item.Title, item.URL));
                if (selected != null && selected.Equals(str1))
                {

                   HistoryManager.DeleteItem(item);
                   int index = listCollection.IndexOf(str1);
                    listCollection.RemoveAt(index);
                    HistoryManagerList.Items.Remove(selected);
                    
                    
                }
               
            }

            if (selected == null)
            {
                MessageBox.Show("Please select item to delete");
            }

            



        }

        private void ClearHistoryContentButton_Click(object sender, EventArgs e)
        {
            var items = HistoryManager.GetItems();
            //int i = 0;
            int count = HistoryManagerList.Items.Count;
            foreach (var item in items)
            {
                    HistoryManager.DeleteItem(item);
                    HistoryManagerList.Items.RemoveAt(0);
                    listCollection.Clear();
                
            }
        }
    }
}
