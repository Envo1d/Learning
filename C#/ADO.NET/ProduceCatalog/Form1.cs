using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace WindowsFormsADO2
{
    public partial class Form1 : Form
    {
        public string color;
        public int calorieF;
        public int calorieS;
        DbConnection conn = null;
        DbProviderFactory fct = null;
        DbDataAdapter adapter = null;
        DataSet set = new DataSet();
        string providerName = "";
        bool isConnected = false;
        bool isFilled = false;
        public Form1()
        {
            InitializeComponent();

            DataTable tbl = DbProviderFactories.GetFactoryClasses();
            dtGrid.DataSource = tbl;
            cmbDB.Items.Clear();
            foreach (DataRow dr in tbl.Rows)
            {
                cmbDB.Items.Add(dr["InvariantName"]);
            }
            MenuStrip menu = new MenuStrip();
            var fileItem = menu.Items.Add("&File") as ToolStripMenuItem;
            var exitItem = fileItem.DropDownItems.Add("Exit") as ToolStripMenuItem;
            exitItem.ShowShortcutKeys = true;
            exitItem.ShortcutKeys = Keys.Alt | Keys.F4;
            exitItem.Click += (s, e) => Close();
            Controls.Add(menu);
        }
        private void btnConn_Click(object sender, EventArgs e)
        {
            if (cmbDB.SelectedIndex != -1)
                using (conn = fct.CreateConnection())
                {
                    conn.ConnectionString = textBox1.Text;
                    conn.Open();
                    if (conn.State != ConnectionState.Open)
                        MessageBox.Show("Error", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        MessageBox.Show("Connected", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        isConnected = true;
                    }
                }
        }
        private void cmbDB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDB.SelectedIndex != -1)
            {
                fct = DbProviderFactories.GetFactory(cmbDB.SelectedItem.ToString());
                conn = fct.CreateConnection();
                providerName = GetConnectionStringByProvider(cmbDB.SelectedItem.ToString());
                textBox1.Text = providerName;
            }
        }
        private string GetConnectionStringByProvider(string providerName)
        {
            string returnValue = null;
            ConnectionStringSettingsCollection settings = ConfigurationManager.ConnectionStrings;
            if (settings != null)
            {
                foreach (ConnectionStringSettings cs in settings)
                {
                    if (cs.ProviderName == providerName)
                    {
                        returnValue = cs.ConnectionString;
                        break;
                    }
                }
            }
            return returnValue;
        }
        private void btnAll_Click(object sender, EventArgs e)
        {
            if (isConnected)
                using (conn = fct.CreateConnection())
                {
                    set.Tables.Clear();
                    dtGrid.AllowUserToAddRows = true;
                    dtGrid.AllowUserToDeleteRows = true;
                    conn.ConnectionString = textBox1.Text;
                    adapter = fct.CreateDataAdapter();
                    adapter.SelectCommand = conn.CreateCommand();
                    adapter.SelectCommand.CommandText = "Select * from Info";
                    adapter.Fill(set);
                    dtGrid.DataSource = null;
                    dtGrid.DataSource = set.Tables[0];
                    dtGrid.Columns.RemoveAt(0);
                    isFilled = true;
                }
        }

        private void btnUpd_Click(object sender, EventArgs e)
        {
            if (isConnected && isFilled)
                using (conn = fct.CreateConnection())
                {
                    conn.ConnectionString = textBox1.Text;
                    adapter = fct.CreateDataAdapter();
                    adapter.SelectCommand = conn.CreateCommand();
                    adapter.SelectCommand.CommandText = "Select * from Info";
                    DbCommandBuilder bd = fct.CreateCommandBuilder();
                    bd.DataAdapter = adapter;
                    adapter.InsertCommand = bd.GetInsertCommand();
                    adapter.UpdateCommand = bd.GetUpdateCommand();
                    adapter.DeleteCommand = bd.GetDeleteCommand();
                    try
                    {
                        adapter.Update(set);
                    }
                    catch (Exception msg) { MessageBox.Show(msg.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning); };
                }
        }
        private void btnDsc_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                dtGrid.DataSource = null;
                set.Clear();
                textBox1.Text = "";
                isConnected = false;
                isFilled = false;
                cmbDB.SelectedIndex = -1;
                DataTable tbl = DbProviderFactories.GetFactoryClasses();
                dtGrid.DataSource = tbl;
            }
        }

        private void btnNames_Click(object sender, EventArgs e)
        {
            if (isConnected)
                using (conn = fct.CreateConnection())
                {
                    set.Tables.Clear();
                    dtGrid.AllowUserToAddRows = false;
                    dtGrid.AllowUserToDeleteRows = false;
                    conn.ConnectionString = textBox1.Text;
                    adapter = fct.CreateDataAdapter();
                    adapter.SelectCommand = conn.CreateCommand();
                    adapter.SelectCommand.CommandText = "select Name, Type from Info";
                    adapter.Fill(set);
                    dtGrid.DataSource = null;
                    dtGrid.DataSource = set.Tables[0];
                }
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            if (isConnected)
                using (conn = fct.CreateConnection())
                {
                    set.Tables.Clear();
                    dtGrid.AllowUserToAddRows = false;
                    dtGrid.AllowUserToDeleteRows = false;
                    conn.ConnectionString = textBox1.Text;
                    adapter = fct.CreateDataAdapter();
                    adapter.SelectCommand = conn.CreateCommand();
                    adapter.SelectCommand.CommandText = "select max(Calorie) as [Max Calorie] from Info";
                    adapter.Fill(set);
                    dtGrid.DataSource = null;
                    dtGrid.DataSource = set.Tables[0];
                }
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            if (isConnected)
                using (conn = fct.CreateConnection())
                {
                    set.Tables.Clear();
                    dtGrid.AllowUserToAddRows = false;
                    dtGrid.AllowUserToDeleteRows = false;
                    conn.ConnectionString = textBox1.Text;
                    adapter = fct.CreateDataAdapter();
                    adapter.SelectCommand = conn.CreateCommand();
                    adapter.SelectCommand.CommandText = "select min(Calorie) as [Min Calorie] from Info";
                    adapter.Fill(set);
                    dtGrid.DataSource = null;
                    dtGrid.DataSource = set.Tables[0];
                }
        }

        private void btnAvg_Click(object sender, EventArgs e)
        {
            if (isConnected)
                using (conn = fct.CreateConnection())
                {
                    set.Tables.Clear();
                    dtGrid.AllowUserToAddRows = false;
                    dtGrid.AllowUserToDeleteRows = false;
                    conn.ConnectionString = textBox1.Text;
                    adapter = fct.CreateDataAdapter();
                    adapter.SelectCommand = conn.CreateCommand();
                    adapter.SelectCommand.CommandText = "select avg(Calorie) as [Avg Calorie] from Info";
                    adapter.Fill(set);
                    dtGrid.DataSource = null;
                    dtGrid.DataSource = set.Tables[0];
                }
        }

        private void btnVCount_Click(object sender, EventArgs e)
        {
            if (isConnected)
                using (conn = fct.CreateConnection())
                {
                    set.Tables.Clear();
                    dtGrid.AllowUserToAddRows = false;
                    dtGrid.AllowUserToDeleteRows = false;
                    conn.ConnectionString = textBox1.Text;
                    adapter = fct.CreateDataAdapter();
                    adapter.SelectCommand = conn.CreateCommand();
                    adapter.SelectCommand.CommandText = "select count(*) as [Vegetables Count] from Info where Type = 'Vegetable'";
                    adapter.Fill(set);
                    dtGrid.DataSource = null;
                    dtGrid.DataSource = set.Tables[0];
                }
        }

        private void btnFCount_Click(object sender, EventArgs e)
        {
            if (isConnected)
                using (conn = fct.CreateConnection())
                {
                    set.Tables.Clear();
                    dtGrid.AllowUserToAddRows = false;
                    dtGrid.AllowUserToDeleteRows = false;
                    conn.ConnectionString = textBox1.Text;
                    adapter = fct.CreateDataAdapter();
                    adapter.SelectCommand = conn.CreateCommand();
                    adapter.SelectCommand.CommandText = "select count(*) as [Fruits Count] from Info where Type = 'Fruit'";
                    adapter.Fill(set);
                    dtGrid.DataSource = null;
                    dtGrid.DataSource = set.Tables[0];
                }
        }

        private void btnCCount_Click(object sender, EventArgs e)
        {
            if (isConnected)
                using (conn = fct.CreateConnection())
                {
                    set.Tables.Clear();
                    dtGrid.AllowUserToAddRows = false;
                    dtGrid.AllowUserToDeleteRows = false;
                    conn.ConnectionString = textBox1.Text;
                    adapter = fct.CreateDataAdapter();
                    adapter.SelectCommand = conn.CreateCommand();
                    adapter.SelectCommand.CommandText = "select distinct Color, count(Color) as Count from Info group by Color";
                    adapter.Fill(set);
                    dtGrid.DataSource = null;
                    dtGrid.DataSource = set.Tables[0];
                }
        }

        private void btnShColor_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                Dialog dg = new Dialog("Color");
                dg.Owner = this;
                if (dg.ShowDialog() == DialogResult.OK)
                    using (conn = fct.CreateConnection())
                    {
                        set.Tables.Clear();
                        dtGrid.AllowUserToAddRows = false;
                        dtGrid.AllowUserToDeleteRows = false;
                        conn.ConnectionString = textBox1.Text;
                        adapter = fct.CreateDataAdapter();
                        adapter.SelectCommand = conn.CreateCommand();
                        adapter.SelectCommand.CommandText = $"select distinct Color, count(Color) as Count from Info where Color = '{color}' Group by Color";
                        adapter.Fill(set);
                        dtGrid.DataSource = null;
                        dtGrid.DataSource = set.Tables[0];
                    }
            }
        }

        private void btnClLower_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                Dialog dg = new Dialog("Calorie");
                dg.Owner = this;
                if (dg.ShowDialog() == DialogResult.OK)
                    using (conn = fct.CreateConnection())
                    {
                        set.Tables.Clear();
                        dtGrid.AllowUserToAddRows = false;
                        dtGrid.AllowUserToDeleteRows = false;
                        conn.ConnectionString = textBox1.Text;
                        adapter = fct.CreateDataAdapter();
                        adapter.SelectCommand = conn.CreateCommand();
                        adapter.SelectCommand.CommandText = $"select * from Info where Calorie < {calorieF}";
                        adapter.Fill(set);
                        dtGrid.DataSource = null;
                        dtGrid.Columns.RemoveAt(0);
                        dtGrid.DataSource = set.Tables[0];
                    }
            }
        }

        private void btnClUpper_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                Dialog dg = new Dialog("Calorie");
                dg.Owner = this;
                if (dg.ShowDialog() == DialogResult.OK)
                    using (conn = fct.CreateConnection())
                    {
                        set.Tables.Clear();
                        dtGrid.AllowUserToAddRows = false;
                        dtGrid.AllowUserToDeleteRows = false;
                        conn.ConnectionString = textBox1.Text;
                        adapter = fct.CreateDataAdapter();
                        adapter.SelectCommand = conn.CreateCommand();
                        adapter.SelectCommand.CommandText = $"select * from Info where Calorie > {calorieF}";
                        adapter.Fill(set);
                        dtGrid.DataSource = null;
                        dtGrid.Columns.RemoveAt(0);
                        dtGrid.DataSource = set.Tables[0];
                    }
            }
        }

        private void btnClRange_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                Dialog dg = new Dialog("Calorie");
                dg.Owner = this;
                if (dg.ShowDialog() == DialogResult.OK)
                    using (conn = fct.CreateConnection())
                    {
                        set.Tables.Clear();
                        dtGrid.AllowUserToAddRows = false;
                        dtGrid.AllowUserToDeleteRows = false;
                        conn.ConnectionString = textBox1.Text;
                        adapter = fct.CreateDataAdapter();
                        adapter.SelectCommand = conn.CreateCommand();
                        if(calorieS<calorieF)
                        {
                            int tmp = calorieF;
                            calorieF = calorieS;
                            calorieS = tmp;
                        }
                        adapter.SelectCommand.CommandText = $"select * from Info where Calorie < {calorieS} and Calorie > {calorieF}";
                        adapter.Fill(set);
                        dtGrid.DataSource = null;
                        dtGrid.Columns.RemoveAt(0);
                        dtGrid.DataSource = set.Tables[0];
                    }
            }
        }

        private void btnColors_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                using (conn = fct.CreateConnection())
                {
                    set.Tables.Clear();
                    dtGrid.AllowUserToAddRows = false;
                    dtGrid.AllowUserToDeleteRows = false;
                    conn.ConnectionString = textBox1.Text;
                    adapter = fct.CreateDataAdapter();
                    adapter.SelectCommand = conn.CreateCommand();
                    adapter.SelectCommand.CommandText = $"select * from Info where Color = 'Red' or Color = 'Yellow'";
                    adapter.Fill(set);
                    dtGrid.DataSource = null;
                    dtGrid.DataSource = set.Tables[0];
                    dtGrid.Columns.RemoveAt(0);
                }
            }
        }
    }
}
