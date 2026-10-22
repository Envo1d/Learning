using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam
{
    public partial class Sorted_Tasks : Form
    {
        public Sorted_Tasks(List<ListViewItem> items)
        {
            InitializeComponent();
            listView1.View = View.Details;
            listView1.View = View.Details;
            listView1.Columns.Add("Name");
            listView1.Columns.Add("Date");
            listView1.Columns.Add("Time");
            listView1.Columns.Add("Priority");
            listView1.Columns.Add("Tags");
            listView1.Columns.Add("Comment");
            listView1.Columns.Add("File");
            for (int i = 0; i < items.Count; i++)
            {
                var itm = listView1.Items.Add(items[i].Text);
                itm.SubItems.Add(items[i].SubItems[1]);
                itm.SubItems.Add(items[i].SubItems[2]);
                itm.SubItems.Add(items[i].SubItems[3]);
                itm.SubItems.Add(items[i].SubItems[4]);
                itm.SubItems.Add(items[i].SubItems[5]);
                itm.SubItems.Add(items[i].SubItems[6]);
            }
            foreach (ColumnHeader column in listView1.Columns)
            {
                if (column.Text == "Name")
                    continue;
                column.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
        }
    }
}
