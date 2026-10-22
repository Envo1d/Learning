using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms5
{
    public partial class AddNewMenuDialog : Form
    {
        public AddNewMenuDialog()
        {
            InitializeComponent();

            btnOk.Click += OkClick;
        }

        private void OkClick(object sender, EventArgs e)
        {
            if ((txtAction.Text != null || txtAction.Text != "") && (txtGroup.Text != null || txtGroup.Text != "") && (txtName.Text != null || txtName.Text != "") && (btnNo.Checked || btnYes.Checked))
            {
                (this.Owner as MainForm).group = txtGroup.Text;
                (this.Owner as MainForm).name = txtName.Text;
                if (chBox.Checked)
                    (this.Owner as MainForm).action = txtAction.Text;
                else
                    (this.Owner as MainForm).action = cmbBox.SelectedItem.ToString();
                (this.Owner as MainForm).check = btnYes.Checked ? true : false;
                DialogResult = DialogResult.OK;
            }
        }

        private void chBox_CheckedChanged(object sender, EventArgs e)
        {
            if (chBox.Checked)
                cmbBox.Visible = false;
            else
                cmbBox.Visible = true;
        }
    }
}
