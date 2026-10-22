using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms6
{
    public partial class RenameDialog : Form
    {
        public RenameDialog()
        {
            InitializeComponent();
        }
        public RenameDialog(string name)
        {
            InitializeComponent();
            txtBox.Text = name;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(txtBox.Text != null || txtBox.Text != "")
            {
                (this.Owner as MainForm).renamed = txtBox.Text;
                DialogResult = DialogResult.OK;
            }
        }
    }
}
