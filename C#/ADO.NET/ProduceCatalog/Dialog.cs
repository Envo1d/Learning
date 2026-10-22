using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsADO2
{
    public partial class Dialog : Form
    {
        string arg;
        public Dialog(string arg = "")
        {
            InitializeComponent();
            this.arg = arg;
            if(arg=="Color")
            {
                label2.Visible = false;
                textBox2.Visible = false;
                label1.Text = "Color";
            }
            if(arg=="Calorie")
            {
                label2.Visible = false;
                textBox2.Visible = false;
                label1.Text = "Calorie";
            }
            if(arg=="CalorieRange")
            {
                label1.Text = "From";
                label2.Text = "To";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(arg=="Color")
            {
                if(textBox1.Text != "")
                {
                    (this.Owner as Form1).color = textBox1.Text;
                    DialogResult = DialogResult.OK;
                }
            }
            if(arg=="Calorie")
            {
                if(textBox1.Text != "")
                {
                    bool f = true;
                    foreach(char c in textBox1.Text)
                    {
                        f = char.IsDigit(c);
                        if (!f)
                            break;
                    }
                    if(f)
                    {
                        (this.Owner as Form1).calorieF = Convert.ToInt32(textBox1.Text);
                        DialogResult = DialogResult.OK;
                    }
                }
            }
            if (arg == "CalorieRange")
            {
                if (textBox1.Text != "")
                {
                    bool fF = true; bool fS = true;
                    foreach (char c in textBox1.Text)
                    {
                        fF = char.IsDigit(c);
                        if (!fF)
                            break;
                    }
                    foreach (char c in textBox2.Text)
                    {
                        fS = char.IsDigit(c);
                        if (!fS)
                            break;
                    }
                    if (fF && fS)
                    {
                        (this.Owner as Form1).calorieF = Convert.ToInt32(textBox1.Text);
                        (this.Owner as Form1).calorieS = Convert.ToInt32(textBox2.Text);
                        DialogResult = DialogResult.OK;
                    }
                }
            }
        }
    }
}
