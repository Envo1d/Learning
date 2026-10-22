using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace WindowsForms5
{
    public partial class MainForm : Form
    {
        //Data Source=localhost;User ID=db_user;Password=CHANGE_ME;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Initial Catalog=MenuBase
        public string sqlConnection;
        private MenuStrip menu = new MenuStrip();
        private ToolStripMenuItem sqlServer;
        public string group;
        public string name;
        public string action;
        public bool check;
        private bool isStart = true;
        private bool isMenuLoaded = false;
        private int curIndexOfMenu = 0;
        public int index;

        public MainForm()
        {
            InitializeComponent();
            sqlServer = menu.Items.Add("&SQL Server") as ToolStripMenuItem;
            var connectString = sqlServer.DropDownItems.Add("Connection") as ToolStripMenuItem;
            connectString.Click += ConnectionClick;
            Controls.Add(menu);
        }
        private void ConnectionClick(object sender, EventArgs e)
        {
            AddDialog addDialog;
            if (sqlConnection == null)
            {
                addDialog = new AddDialog();
            }
            else
                addDialog = new AddDialog(sqlConnection);

            addDialog.Owner = this;
            if (addDialog.ShowDialog() == DialogResult.OK)
            {
                if (isStart)
                {
                    ToolStripMenuItem addNewMenu = new ToolStripMenuItem("Add new menu");
                    addNewMenu.ShortcutKeys = Keys.Control | Keys.A;
                    addNewMenu.ShowShortcutKeys = true;
                    addNewMenu.Click += AddClick;
                    sqlServer.DropDownItems.Insert(0, addNewMenu);

                    ToolStripMenuItem loadMenu = new ToolStripMenuItem("Load menu");
                    loadMenu.ShortcutKeys = Keys.Control | Keys.L;
                    loadMenu.ShowShortcutKeys = true;
                    loadMenu.Click += LoadClick;
                    sqlServer.DropDownItems.Insert(1, loadMenu);
                    isStart = false;
                }
            }
        }
        private void AddClick(object sender, EventArgs e)
        {
            AddNewMenuDialog addNewMenu = new AddNewMenuDialog();
            addNewMenu.Owner = this;
            DialogResult res = addNewMenu.ShowDialog();

            string sqlExpression = "spAddMenu";

            if (res == DialogResult.OK)
                using (SqlConnection conn = new SqlConnection(sqlConnection))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlExpression, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter groupParam = new SqlParameter
                    {
                        ParameterName = "@group",
                        Value = group
                    };
                    cmd.Parameters.Add(groupParam);
                    SqlParameter nameParam = new SqlParameter
                    {
                        ParameterName = "@name",
                        Value = name
                    };
                    cmd.Parameters.Add(nameParam);
                    SqlParameter actionParam = new SqlParameter
                    {
                        ParameterName = "@action",
                        Value = action
                    };
                    cmd.Parameters.Add(actionParam);
                    SqlParameter checkParam = new SqlParameter
                    {
                        ParameterName = "@checkable",
                        Value = Convert.ToByte(check)
                    };
                    cmd.Parameters.Add(checkParam);
                    cmd.ExecuteScalar();
                }
        }
        private void LoadClick(object sender, EventArgs e)
        {
            LoadDialog loadDialog = new LoadDialog(sqlConnection);
            loadDialog.Owner = this;
            DialogResult res = loadDialog.ShowDialog();
            if (res == DialogResult.OK)
                LoadMenu(index);
        }
        private void LoadMenu(int idx)
        {
            using (SqlConnection conn = new SqlConnection(sqlConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spGetById", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = idx
                };
                cmd.Parameters.Add(idParam);
                var reader = cmd.ExecuteReader();
                reader.Read();
                group = reader.GetString(1);
                name = reader.GetString(2);
                action = reader.GetString(3);
                check = reader.GetBoolean(4);
                ToolStripMenuItem item = new ToolStripMenuItem($"{name}");
                SetEvent(ref item);
                if (check == true)
                    item.CheckOnClick = true;
                bool isCreated = false;
                foreach(var itm in menu.Items)
                {
                    if (itm.ToString().Contains(group))
                        isCreated = true;
                }
                if (!isCreated)
                {
                    ToolStripMenuItem menuItem = new ToolStripMenuItem($"&{group}");
                    menu.Items.Insert(curIndexOfMenu, menuItem);
                    menuItem.DropDownItems.Add(item);
                }
                else
                {
                    foreach (var itm in menu.Items)
                    {
                        if (itm.ToString().Contains(group))
                        {
                            (itm as ToolStripMenuItem).DropDownItems.Add(item);
                            break;
                        }
                    }
                }
                if(!isMenuLoaded)
                {
                    curIndexOfMenu++;
                    isMenuLoaded = true;
                }
            }
        }
        private void SetEvent(ref ToolStripMenuItem item)
        {
            if (action == "Open File")
            { item.Click += OpenFile; item.ShortcutKeys = Keys.Control | Keys.O; item.ShowShortcutKeys = true; }
            else if (action == "Save File")
            { item.Click += SaveFile; item.ShortcutKeys = Keys.Control | Keys.S; item.ShowShortcutKeys = true; }
            else if (action == "Exit")
            { item.Click += Exit; item.ShortcutKeys = Keys.Control | Keys.X; item.ShowShortcutKeys = true; }
        }
        private void OpenFile(object sender, EventArgs  e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files(*.txt) | *.txt";
            openFileDialog.ShowDialog();
            using (StreamReader stream = new StreamReader(openFileDialog.OpenFile()))
            {
                txtBox.Text = stream.ReadToEnd();
            }
            openFileDialog.Dispose();
        }
        private void SaveFile(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files(*.txt) | *.txt";
            saveFileDialog.ShowDialog();
            using(StreamWriter stream = new StreamWriter(saveFileDialog.OpenFile()))
            {
                stream.Write(txtBox.Text);
            }
            saveFileDialog.Dispose();
        }
        private void Exit(object sender ,EventArgs e)
        {
            this.Close();
        }
    }
}