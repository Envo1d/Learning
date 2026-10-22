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
    public partial class AddDialog : Form
    {
        public AddDialog()
        {
            InitializeComponent();
        }
        public AddDialog(string connection)
        {
            InitializeComponent();
            txtBox.Text = connection;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtBox.Text != null || txtBox.Text != "")
            {
                try
                {
                    SqlConnection sqlConnection = new SqlConnection(txtBox.Text);
                    sqlConnection.Open();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                    (this.Owner as MainForm).sqlConnection = txtBox.Text;
                    DialogResult = DialogResult.OK;
                }
                catch (Exception msg)
                {
                    MessageBox.Show(msg.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
