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
        public HistoryManagerForm()
        {
            InitializeComponent();
            listCollection.Clear();
        }

        private void HistoryManager_Load(object sender, EventArgs e)
        {
            var items = HistoryManager.GetItems();
            //HistoryManagerList.Items.Clear();
           
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
            HistoryManagerList.SetSelected(0, true);
            /*for (int i = HistoryManagerList.Items.Count-1; i >= 0; i--)
            {
                if (HistoryManagerList.Items[i].ToString().ToLower().Contains(historySearch.Text.ToLower()))
                {
                    HistoryManagerList.SetSelected(i, true);
                }
            }*/

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
    }
}
