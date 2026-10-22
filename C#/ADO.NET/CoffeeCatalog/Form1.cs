using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsADO
{
    public partial class Form1 : Form
    {
        private MenuStrip menu = new MenuStrip();
        readonly string connectionString = ConfigurationManager.ConnectionStrings["database"].ConnectionString;
        readonly DataSet dataSet = new DataSet();
        private SqlDataAdapter da;
        private bool isConnected = false;
        public Form1()
        {
            InitializeComponent();
            da = new SqlDataAdapter("SELECT * FROM Info", connectionString);
            var fileItem = menu.Items.Add("&Файл") as ToolStripMenuItem;
            var exitItem = fileItem.DropDownItems.Add("Выход") as ToolStripMenuItem;
            exitItem.ShowShortcutKeys = true;
            exitItem.ShortcutKeys = Keys.Control | Keys.X;
            exitItem.Click += (s, e) => this.Close();
            var sqlItem = menu.Items.Add("&База данных") as ToolStripMenuItem;
            var connItem = sqlItem.DropDownItems.Add("Подключится") as ToolStripMenuItem;
            connItem.Click += ConnectClick;
            var discnItem = sqlItem.DropDownItems.Add("Отключится") as ToolStripMenuItem;
            discnItem.Click += DisconnectClick;
            Controls.Add(menu);
            dataGridView.ShowCellToolTips = true;
            dataGridView.PreviewKeyDown += DataGridView_PreviewKeyDown;
        }

        private void DataGridView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                dataGridView.Rows.RemoveAt(dataGridView.SelectedCells[0].RowIndex);
            }
        }

        private void DataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dataGridView[2, dataGridView.Rows.Count - 1].ToolTipText = "Арабика / Робуст / Бленд";
        }

        private void DisconnectClick(object sender, EventArgs e)
        {
            dataGridView.DataSource = null;
            dataSet.Clear();
            dataGridView.Update();
            dataGridView.RowsAdded -= DataGridView_RowsAdded;
            listBox1.Items.Clear();
        }

        private void ConnectClick(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sql = new SqlConnection(connectionString))
                {
                    if (sql.State != ConnectionState.Closed || sql.State != ConnectionState.Broken)
                    {
                        MessageBox.Show("Подключение установлено", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        da.Fill(dataSet);
                        isConnected = true;
                        dataGridView.DataSource = dataSet.Tables[0];
                        dataGridView.Columns.RemoveAt(0);
                        for (int i = 0; i < dataGridView.Rows.Count; i++)
                        {
                            dataGridView[2, i].ToolTipText = "Арабика / Робуст / Бленд";
                        }
                        dataGridView.Update();
                        dataGridView.RowsAdded += DataGridView_RowsAdded;
                    }
                    else MessageBox.Show("Не удалось подключится к базе", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }catch(Exception msg) { MessageBox.Show(msg.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); } // Если строка подключения введен неверно
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isConnected)
                using (SqlConnection sql = new SqlConnection(connectionString))
                {
                    SqlCommandBuilder bd = new SqlCommandBuilder(da);
                    try
                    {
                        da.Update(dataSet);
                        dataGridView.DataSource = dataSet.Tables[0];
                    }
                    catch (Exception msg) { MessageBox.Show(msg.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning); };
                }
            else MessageBox.Show("Нет подключения к БД", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (isConnected)
                using (SqlConnection sql = new SqlConnection(connectionString))
                {
                    if (listBox1.Items.Count != 0)
                        listBox1.Items.Clear();
                    sql.Open();
                    SqlCommand cmd = new SqlCommand("Select * from Info", sql);
                    SqlDataReader reader = cmd.ExecuteReader();
                    listBox1.Items.Add($"{reader.GetName(1)}\t{reader.GetName(2)}\t{reader.GetName(3)}\t{reader.GetName(4)}\t{reader.GetName(5)}\t\t{reader.GetName(6)}");
                    listBox1.Items.Add("");
                    while(reader.Read())
                    {
                        listBox1.Items.Add($"{reader.GetString(1)}\t{reader.GetString(2)}\t{reader.GetString(3)}\t{reader.GetString(4)}\t{reader.GetInt32(5)}\t{reader.GetDecimal(6)}");
                    }
                }
            else MessageBox.Show("Нет подключения к БД", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (isConnected)
                using (SqlConnection sql = new SqlConnection(connectionString))
                {
                    if (listBox1.Items.Count != 0)
                        listBox1.Items.Clear();
                    sql.Open();
                    SqlCommand cmd = new SqlCommand("Select * from Info", sql);
                    SqlDataReader reader = cmd.ExecuteReader();
                    listBox1.Items.Add($"{reader.GetName(1)}");
                    listBox1.Items.Add("");
                    while (reader.Read())
                    {
                        listBox1.Items.Add($"{reader.GetString(1)}");
                    }
                }
            else MessageBox.Show("Нет подключения к БД", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (isConnected)
                using (SqlConnection sql = new SqlConnection(connectionString))
                {
                    if (listBox1.Items.Count != 0)
                        listBox1.Items.Clear();
                    sql.Open();
                    SqlCommand cmd = new SqlCommand("select * from Info where [Вид кофе] = \'Арабика\'", sql);
                    SqlDataReader reader = cmd.ExecuteReader();
                    listBox1.Items.Add($"{reader.GetName(1)}\t{reader.GetName(2)}\t{reader.GetName(3)}\t{reader.GetName(4)}\t{reader.GetName(5)}\t\t{reader.GetName(6)}");
                    listBox1.Items.Add("");
                    while (reader.Read())
                    {
                        listBox1.Items.Add($"{reader.GetString(1)}\t{reader.GetString(2)}\t{reader.GetString(3)}\t{reader.GetString(4)}\t{reader.GetInt32(5)}\t{reader.GetDecimal(6)}");
                    }
                }
            else MessageBox.Show("Нет подключения к БД", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (isConnected)
                using (SqlConnection sql = new SqlConnection(connectionString))
                {
                    if (listBox1.Items.Count != 0)
                        listBox1.Items.Clear();
                    sql.Open();
                    SqlCommand cmd = new SqlCommand("select * from Info where [Вид кофе] = \'Робуст\'", sql);
                    SqlDataReader reader = cmd.ExecuteReader();
                    listBox1.Items.Add($"{reader.GetName(1)}\t{reader.GetName(2)}\t{reader.GetName(3)}\t{reader.GetName(4)}\t{reader.GetName(5)}\t\t{reader.GetName(6)}");
                    listBox1.Items.Add("");
                    while (reader.Read())
                    {
                        listBox1.Items.Add($"{reader.GetString(1)}\t{reader.GetString(2)}\t{reader.GetString(3)}\t{reader.GetString(4)}\t{reader.GetInt32(5)}\t{reader.GetDecimal(6)}");
                    }
                }
            else MessageBox.Show("Нет подключения к БД", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (isConnected)
                using (SqlConnection sql = new SqlConnection(connectionString))
                {
                    if (listBox1.Items.Count != 0)
                        listBox1.Items.Clear();
                    sql.Open();
                    SqlCommand cmd = new SqlCommand("select * from Info where [Вид кофе] = \'Бленд\'", sql);
                    SqlDataReader reader = cmd.ExecuteReader();
                    listBox1.Items.Add($"{reader.GetName(1)}\t{reader.GetName(2)}\t{reader.GetName(3)}\t{reader.GetName(4)}\t{reader.GetName(5)}\t\t{reader.GetName(6)}");
                    listBox1.Items.Add("");
                    while (reader.Read())
                    {
                        listBox1.Items.Add($"{reader.GetString(1)}\t{reader.GetString(2)}\t{reader.GetString(3)}\t{reader.GetString(4)}\t{reader.GetInt32(5)}\t{reader.GetDecimal(6)}");
                    }
                }
            else MessageBox.Show("Нет подключения к БД", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (isConnected)
                using (SqlConnection sql = new SqlConnection(connectionString))
                {
                    if (listBox1.Items.Count != 0)
                        listBox1.Items.Clear();
                    sql.Open();
                    SqlCommand cmd = new SqlCommand("select * from Info where [Количество грамм] < 200", sql);
                    SqlDataReader reader = cmd.ExecuteReader();
                    listBox1.Items.Add($"{reader.GetName(1)}\t{reader.GetName(2)}\t{reader.GetName(3)}\t{reader.GetName(4)}\t{reader.GetName(5)}\t\t{reader.GetName(6)}");
                    listBox1.Items.Add("");
                    while (reader.Read())
                    {
                        listBox1.Items.Add($"{reader.GetString(1)}\t{reader.GetString(2)}\t{reader.GetString(3)}\t{reader.GetString(4)}\t{reader.GetInt32(5)}\t{reader.GetDecimal(6)}");
                    }
                }
            else MessageBox.Show("Нет подключения к БД", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (isConnected)
                using (SqlConnection sql = new SqlConnection(connectionString))
                {
                    if (listBox1.Items.Count != 0)
                        listBox1.Items.Clear();
                    sql.Open();
                    SqlCommand cmd = new SqlCommand("select min(Себестоимость) as [Min] from Info", sql);
                    SqlDataReader reader = cmd.ExecuteReader();
                    listBox1.Items.Add($"{reader.GetName(0)}");
                    listBox1.Items.Add("");
                    while (reader.Read())
                    {
                        listBox1.Items.Add($"{reader.GetDecimal(0)}");
                    }
                }
            else MessageBox.Show("Нет подключения к БД", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (isConnected)
                using (SqlConnection sql = new SqlConnection(connectionString))
                {
                    if (listBox1.Items.Count != 0)
                        listBox1.Items.Clear();
                    sql.Open();
                    SqlCommand cmd = new SqlCommand("select max(Себестоимость) as [Max] from Info", sql);
                    SqlDataReader reader = cmd.ExecuteReader();
                    listBox1.Items.Add($"{reader.GetName(0)}");
                    listBox1.Items.Add("");
                    while (reader.Read())
                    {
                        listBox1.Items.Add($"{reader.GetDecimal(0)}");
                    }
                }
            else MessageBox.Show("Нет подключения к БД", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (isConnected)
                using (SqlConnection sql = new SqlConnection(connectionString))
                {
                    if (listBox1.Items.Count != 0)
                        listBox1.Items.Clear();
                    sql.Open();
                    SqlCommand cmd = new SqlCommand("select avg(Себестоимость) as [Avg] from Info", sql);
                    SqlDataReader reader = cmd.ExecuteReader();
                    listBox1.Items.Add($"{reader.GetName(0)}");
                    listBox1.Items.Add("");
                    while (reader.Read())
                    {
                        listBox1.Items.Add($"{reader.GetDecimal(0)}");
                    }
                }
            else MessageBox.Show("Нет подключения к БД", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (isConnected)
                using (SqlConnection sql = new SqlConnection(connectionString))
                {
                    if (listBox1.Items.Count != 0)
                        listBox1.Items.Clear();
                    sql.Open();
                    SqlCommand cmd = new SqlCommand("select count(*) as [Сортов с min себестоимостью] from Info where Себестоимость = (select min(Себестоимость) from Info)", sql);
                    SqlDataReader reader = cmd.ExecuteReader();
                    listBox1.Items.Add($"{reader.GetName(0)}");
                    listBox1.Items.Add("");
                    while (reader.Read())
                    {
                        listBox1.Items.Add($"{reader.GetInt32(0)}");
                    }
                }
            else MessageBox.Show("Нет подключения к БД", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (isConnected)
                using (SqlConnection sql = new SqlConnection(connectionString))
                {
                    if (listBox1.Items.Count != 0)
                        listBox1.Items.Clear();
                    sql.Open();
                    SqlCommand cmd = new SqlCommand("select count(*) as [Сортов с max себестоимостью] from Info where Себестоимость = (select max(Себестоимость) from Info)", sql);
                    SqlDataReader reader = cmd.ExecuteReader();
                    listBox1.Items.Add($"{reader.GetName(0)}");
                    listBox1.Items.Add("");
                    while (reader.Read())
                    {
                        listBox1.Items.Add($"{reader.GetInt32(0)}");
                    }
                }
            else MessageBox.Show("Нет подключения к БД", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (isConnected)
                using (SqlConnection sql = new SqlConnection(connectionString))
                {
                    if (listBox1.Items.Count != 0)
                        listBox1.Items.Clear();
                    sql.Open();
                    SqlCommand cmd = new SqlCommand("select (select count(*) from Info where [Вид кофе] = 'Арабика') as Арабика, (select count(*) from Info where [Вид кофе] = 'Робуст') as Робуст, (select count(*) from Info where [Вид кофе] = 'Бленд') as Бленд", sql);
                    SqlDataReader reader = cmd.ExecuteReader();
                    listBox1.Items.Add($"{reader.GetName(0)}\t{reader.GetName(1)}\t{reader.GetName(2)}");
                    listBox1.Items.Add("");
                    while (reader.Read())
                    {
                        listBox1.Items.Add($"{reader.GetInt32(0)}\t{reader.GetInt32(1)}\t{reader.GetInt32(2)}");
                    }
                }
            else MessageBox.Show("Нет подключения к БД", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
