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
    public partial class Select_Date : Form
    {
        public Select_Date()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(dateTimePicker1.Value != dateTimePicker1.MinDate)
            {
                (Owner as Form1).dateTimeF = dateTimePicker1.Value;
                DialogResult = DialogResult.OK;
            }
        }
    }
}
