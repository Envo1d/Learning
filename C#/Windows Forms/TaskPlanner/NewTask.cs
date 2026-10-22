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
    public partial class NewTask : Form
    {
        public NewTask()
        {
            InitializeComponent();
            dateTime.Enabled = false;
            cmbPriority.Enabled = false;
            cmbPriority.SelectedIndex = 0;
            txtTags.Enabled = false;
            txtComment.Enabled = false;
            txtFile.Enabled = false;
            btnOpenFile.Enabled = false;
        }

        private void btnCncl_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(txtName.Text != "")
            {
                Information info = new Information { Name = txtName.Text};
                if (chDateTime.Checked && dateTime.Value != DateTime.MinValue)
                    info.DateTime = dateTime.Value;
                if(chPrior.Checked)
                    info.Priority = (Priority)cmbPriority.SelectedIndex;
                if (chTags.Checked && txtTags.Text != "")
                    info.Tags = txtTags.Text;
                if (chCmmnt.Checked && txtComment.Text != "")
                    info.Comment = txtComment.Text;
                if (chFile.Checked && txtFile.Text != "")
                    info.PathToFile = txtFile.Text;
                (this.Owner as Form1).Information = info;
                DialogResult = DialogResult.OK;
            }
        }

        private void btnDateTime_CheckedChanged(object sender, EventArgs e)
        {
            dateTime.Enabled = !dateTime.Enabled;
        }

        private void chPrior_CheckedChanged(object sender, EventArgs e)
        {
            cmbPriority.Enabled = !cmbPriority.Enabled;
        }

        private void chTags_CheckedChanged(object sender, EventArgs e)
        {
            txtTags.Enabled = !txtTags.Enabled;
        }

        private void chCmmnt_CheckedChanged(object sender, EventArgs e)
        {
            txtComment.Enabled = !txtComment.Enabled;
        }

        private void chFile_CheckedChanged(object sender, EventArgs e)
        {
            txtFile.Enabled = !txtFile.Enabled;
            btnOpenFile.Enabled = !btnOpenFile.Enabled;
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            var openFile = new OpenFileDialog();
            openFile.Filter = "Alll files (*)|*";
            if (openFile.ShowDialog() == DialogResult.OK)
                txtFile.Text = openFile.FileName;
            openFile.Dispose();
        }
    }
}
