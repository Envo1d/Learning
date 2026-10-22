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

namespace WindowsForms5
{
    public partial class LoadDialog : Form
    {
        public LoadDialog(string connection)
        {
            InitializeComponent();
            using(SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spGetTab", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                var reader = cmd.ExecuteReader();
                txtBox.Text = $"{reader.GetName(0)}\t{reader.GetName(1)}\t{reader.GetName(2)}\t{reader.GetName(3)}\t{reader.GetName(4)}";
                while (reader.Read())
                {
                    string tmp = $"{reader.GetInt32(0)}";
                    tmp += $"\t{reader.GetString(1)}";
                    tmp += $"\t{reader.GetString(2)}";
                    tmp += $"\t{reader.GetString(3)}";
                    tmp += $"\t{reader.GetBoolean(4)}";
                    lstBox.Items.Add(tmp);
                }
            }
        }

        private void lstBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                int idx = lstBox.SelectedItem.ToString().IndexOf("\t");
                string tmp = "";
                for (int i = 0; i < idx; i++)
                {
                    tmp += lstBox.SelectedItem.ToString()[i];
                }
                (this.Owner as MainForm).index = Convert.ToInt32(tmp);
                DialogResult = DialogResult.OK;
            }
        }
    }
}
