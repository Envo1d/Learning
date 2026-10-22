using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListViewItem;

namespace Exam
{
    public partial class Form1 : Form
    {
        private MenuStrip menu = new MenuStrip();
        private string filePath;
        private SaveLoad saveLoad = new SaveLoad();
        public DateTime dateTimeF;
        public Information Information { get; set; } = null;
        public Form1()
        {
            InitializeComponent();

            var fileItem = menu.Items.Add("&File") as ToolStripMenuItem;
            var newItem = fileItem.DropDownItems.Add("New") as ToolStripMenuItem;
            var openItem = fileItem.DropDownItems.Add("Open") as ToolStripMenuItem;
            var saveItem = fileItem.DropDownItems.Add("Save") as ToolStripMenuItem;
            var saveAsItem = fileItem.DropDownItems.Add("Save as..") as ToolStripMenuItem;

            newItem.Click += (s, e) => { listView.Items.Clear(); filePath = ""; };
            
            openItem.ShowShortcutKeys = true;
            openItem.ShortcutKeys = Keys.Control | Keys.O;
            openItem.Click += OpenFile;

            saveItem.ShowShortcutKeys = true;
            saveItem.ShortcutKeys = Keys.Control | Keys.S;
            saveItem.Click += SaveClick;

            saveAsItem.Click += SaveAsClick;

            fileItem.DropDownItems.Add(new ToolStripSeparator());
            var exitItem = fileItem.DropDownItems.Add("Exit") as ToolStripMenuItem;
           
            exitItem.ShowShortcutKeys = true;
            exitItem.ShortcutKeys = Keys.Alt | Keys.F4;
            exitItem.Click += (s, e) => Close();

            var taskItem = menu.Items.Add("&Task") as ToolStripMenuItem;
            var newTaskItem = taskItem.DropDownItems.Add("New") as ToolStripMenuItem;
            newTaskItem.ShowShortcutKeys = true;
            newTaskItem.ShortcutKeys = Keys.Control | Keys.N;
            newTaskItem.Click += NewTaskClick;
            var findItem = taskItem.DropDownItems.Add("Find") as ToolStripMenuItem;
            findItem.Click += (s, e) =>
            {
                Find findForm = new Find();
                findForm.FindWordClicked += Find_FindWordClicked;
                findForm.Show();
            };
            var sortItem = taskItem.DropDownItems.Add("Tasks by") as ToolStripMenuItem;
            var dayItem = sortItem.DropDownItems.Add("Day") as ToolStripMenuItem;
            var weekItem = sortItem.DropDownItems.Add("Week") as ToolStripMenuItem;
            var monthItem = sortItem.DropDownItems.Add("Month") as ToolStripMenuItem;
            dayItem.Click += DayItem_Click;
            weekItem.Click += WeekItem_Click;
            monthItem.Click += MonthItem_Click;

            listView.PreviewKeyDown += ListView_PreviewKeyDown;
            Controls.Add(menu);

            listView.View = View.Details;
            listView.Columns.Add("Name");
            listView.Columns.Add("Date");
            listView.Columns.Add("Time");
            listView.Columns.Add("Priority");
            listView.Columns.Add("Tags");
            listView.Columns.Add("Comment");
            listView.Columns.Add("File");
        }

        private void MonthItem_Click(object sender, EventArgs e)
        {
            Select_Date dlg = new Select_Date();
            dlg.Owner = this;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                List<ListViewItem> items = new List<ListViewItem>();
                foreach (ListViewItem itm in listView.Items)
                {
                    if (Convert.ToDateTime(itm.SubItems[1].Text).Month == dateTimeF.Month)
                        items.Add(itm);
                }
                if (items.Count != 0)
                {
                    Sorted_Tasks sorted = new Sorted_Tasks(items);
                    sorted.Show();
                }
                else MessageBox.Show("No values", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void WeekItem_Click(object sender, EventArgs e)
        {
            Select_Date dlg = new Select_Date();
            dlg.Owner = this;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                DateTime tmp = dateTimeF;
                List<DateTime> week = new List<DateTime>();
                week.Add(dateTimeF);
                while (dateTimeF.DayOfWeek <= DayOfWeek.Sunday)
                {
                    dateTimeF = dateTimeF.Subtract(new TimeSpan(1, 0, 0, 0));
                    week.Add(dateTimeF);
                }
                dateTimeF = tmp;
                while (dateTimeF.DayOfWeek != DayOfWeek.Monday)
                {
                    dateTimeF = dateTimeF.AddDays(1);
                    week.Add(dateTimeF);
                }
                List<ListViewItem> items = new List<ListViewItem>();
                foreach (ListViewItem itm in listView.Items)
                {
                    foreach(var day in week)
                    {
                        if (itm.SubItems[1].Text == day.ToShortDateString())
                            items.Add(itm);
                    }
                }
                Sorted_Tasks sorted = new Sorted_Tasks(items);
                sorted.Show();
            }
        }
        private void DayItem_Click(object sender, EventArgs e)
        {
            Select_Date dlg = new Select_Date();
            dlg.Owner = this;
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                List<ListViewItem> items = new List<ListViewItem>();
                foreach(ListViewItem itm in listView.Items)
                {
                    if (itm.SubItems[1].Text == dateTimeF.Date.ToShortDateString())
                        items.Add(itm);
                }
                Sorted_Tasks sorted = new Sorted_Tasks(items);
                sorted.Show();
            }
        }
        private void ListView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
           if(e.KeyCode == Keys.Delete)
            {
                listView.Items.Remove(listView.SelectedItems[0]);
                saveLoad.Clear();
                if(listView.Items.Count != 0)
                foreach (ListViewItem task in listView.Items)
                {
                    Information tmp = new Information { Name = task.Text };
                    if (task.SubItems[1].Text != "" && task.SubItems[2].Text != "")
                    {
                        tmp.DateTime = Convert.ToDateTime(task.SubItems[1].Text + " " + task.SubItems[2].Text);
                    }
                    else tmp.DateTime = DateTime.MinValue;
                    if (task.SubItems[3].Text != "")
                    {
                        tmp.Priority = (Priority)Enum.Parse(typeof(Priority), task.SubItems[3].Text);
                    }
                    if (task.SubItems[4].Text != "")
                    {
                        tmp.Tags = task.SubItems[4].Text;
                    }
                    else tmp.Tags = "";
                    if (task.SubItems[5].Text != "")
                    {
                        tmp.Comment = task.SubItems[5].Text;
                    }
                    else tmp.Comment = "";
                    if (task.SubItems[6].Text != "")
                    {
                        tmp.PathToFile = task.SubItems[6].Text;
                    }
                    else tmp.PathToFile = "";
                    saveLoad.info.tasks.Add(tmp);
                }
            }
        }
        private void Find_FindWordClicked(object sender, string e)
        {
            foreach(ListViewItem itm in listView.Items)
            {
                if(itm.Text == e)
                {
                    itm.Selected = true;
                    break;
                }
                else
                {
                    foreach(ListViewSubItem item in itm.SubItems)
                    {
                        if(item.Text == e)
                        {
                            itm.Selected = true;
                            break;
                        }
                    }
                }
            }
            Focus();
        }
        private void OpenFile(object sender ,EventArgs e)
        {
            var openFile = new OpenFileDialog();
            openFile.Filter = "Xml files (*.xml)|*.xml";
            openFile.InitialDirectory = "C:\\";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                filePath = openFile.FileName;
                saveLoad.Load(openFile.OpenFile());
                if (saveLoad.info.tasks.Count != 0)
                {
                    foreach (var info in saveLoad.info.tasks)
                    {
                        var itm = listView.Items.Add(info.Name);
                        if (info.DateTime != DateTime.MinValue)
                        {
                            itm.SubItems.Add(info.DateTime.Date.ToShortDateString());
                            itm.SubItems.Add(info.DateTime.ToShortTimeString());
                        }
                        else
                        {
                            itm.SubItems.Add("");
                            itm.SubItems.Add("");
                        }
                        itm.SubItems.Add(Enum.GetName(typeof(Priority), info.Priority));
                        if (info.Tags != "")
                            itm.SubItems.Add(info.Tags);
                        else
                            itm.SubItems.Add("");
                        if (info.Comment != "")
                            itm.SubItems.Add(info.Comment);
                        else
                            itm.SubItems.Add("");
                        if (info.PathToFile != "")
                            itm.SubItems.Add(info.PathToFile);
                        else
                            itm.SubItems.Add("");
                    }
                    saveLoad.Clear();
                }
            }
            openFile.Dispose();
            foreach (ColumnHeader column in listView.Columns)
            {
                if (column.Text == "Name")
                    continue;
                column.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
        }
        private void SaveClick(object sender, EventArgs e)
        {
            saveLoad.Clear();
            foreach (ListViewItem task in listView.Items)
            {
                Information tmp = new Information { Name = task.Text };
                if (task.SubItems[1].Text != "" && task.SubItems[2].Text != "")
                {
                    tmp.DateTime = Convert.ToDateTime(task.SubItems[1].Text + " " + task.SubItems[2].Text);
                }
                else tmp.DateTime = DateTime.MinValue;
                if (task.SubItems[3].Text != "")
                {
                    tmp.Priority = (Priority)Enum.Parse(typeof(Priority), task.SubItems[3].Text);
                }
                if (task.SubItems[4].Text != "")
                {
                    tmp.Tags = task.SubItems[4].Text;
                }
                else tmp.Tags = "";
                if (task.SubItems[5].Text != "")
                {
                    tmp.Comment = task.SubItems[5].Text;
                }
                else tmp.Comment = "";
                if (task.SubItems[6].Text != "")
                {
                    tmp.PathToFile = task.SubItems[6].Text;
                }
                else tmp.PathToFile = "";
                saveLoad.info.tasks.Add(tmp);
            }
            saveLoad.Save(filePath);
        }
        private void SaveAsClick(object sender, EventArgs e)
        {
            if (listView.Items.Count != 0)
            {
                saveLoad.Clear();
                foreach (ListViewItem task in listView.Items)
                {
                    Information tmp = new Information { Name = task.Text };
                    if (task.SubItems[1].Text != "" && task.SubItems[2].Text != "")
                    {
                        tmp.DateTime = Convert.ToDateTime(task.SubItems[1].Text + " " + task.SubItems[2].Text);
                    }
                    else tmp.DateTime = DateTime.MinValue;
                    if(task.SubItems[3].Text != "")
                    {
                        tmp.Priority = (Priority)Enum.Parse(typeof(Priority), task.SubItems[3].Text);
                    }
                    if (task.SubItems[4].Text != "")
                    {
                        tmp.Tags = task.SubItems[4].Text;
                    }
                    else tmp.Tags = "";
                    if (task.SubItems[5].Text != "")
                    {
                        tmp.Comment = task.SubItems[5].Text;
                    }
                    else tmp.Comment = "";
                    if (task.SubItems[6].Text != "")
                    {
                        tmp.PathToFile = task.SubItems[6].Text;
                    }
                    else tmp.PathToFile = "";
                    saveLoad.info.tasks.Add(tmp);
                }
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Xml files (*.xml)|*.xml";
                saveFileDialog.InitialDirectory = "C:\\";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    saveLoad.Save(saveFileDialog.OpenFile());
                }
                saveFileDialog.Dispose();
            }
            else MessageBox.Show("List is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void NewTaskClick(object sender, EventArgs e)
        {
            var newTask = new NewTask();
            newTask.Owner = this;
            if(newTask.ShowDialog() == DialogResult.OK)
            {
                var itm = listView.Items.Add(Information.Name);
                if (Information.DateTime != DateTime.MinValue)
                {
                    itm.SubItems.Add(Information.DateTime.Date.ToShortDateString());
                    itm.SubItems.Add(Information.DateTime.ToShortTimeString());
                }
                else
                {
                    itm.SubItems.Add("");
                    itm.SubItems.Add("");
                }
                itm.SubItems.Add(Enum.GetName(typeof(Priority), Information.Priority));
                if (Information.Tags != "")
                    itm.SubItems.Add(Information.Tags);
                else
                    itm.SubItems.Add("");
                if (Information.Comment != "")
                    itm.SubItems.Add(Information.Comment);
                else
                    itm.SubItems.Add("");
                if (Information.PathToFile != "")
                    itm.SubItems.Add(Information.PathToFile);
                else
                    itm.SubItems.Add("");
            }
            foreach (ColumnHeader column in listView.Columns)
            {
                if (column.Text == "Name")
                    continue;
                column.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
            newTask.Dispose();
        }
    }
}
