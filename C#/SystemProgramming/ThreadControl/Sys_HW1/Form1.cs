using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sys_HW1
{
    public partial class Form1 : Form
    {
        private int Lower { get; set; }
        private int Upper { get; set; }

        private bool resetFib = false;

        private int FibEnd { get; set; }
        private bool psNum = false;
        private bool psFib = false;
        private bool resetNum = false;
        private Thread numThread;
        private Thread fibThread;
        private AutoResetEvent pauseNum = new AutoResetEvent(true);  
        private AutoResetEvent pauseFib = new AutoResetEvent(true);  
        public Form1()
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;
            numThread = new Thread(Generate);
            numThread.IsBackground = true;
            fibThread = new Thread(GenerateFib);
            fibThread.IsBackground = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (numThread != null)
                numThread.Interrupt();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(numThread.IsAlive)
            {
                if (numericUpDown1.Value == 0)
                    Lower = 2;
                else
                    Lower = Convert.ToInt32(numericUpDown1.Value);
                if (numericUpDown2.Value != 0)
                    Upper = Convert.ToInt32(numericUpDown2.Value);
                numericUpDown1.Value = 0;
                numericUpDown2.Value = 0;
                resetNum = true;
            }
            else
            {
                listBox1.Items.Clear();
                if (numericUpDown1.Value == 0)
                    Lower = 2;
                else
                    Lower = Convert.ToInt32(numericUpDown1.Value);
                if (numericUpDown2.Value != 0)
                    Upper = Convert.ToInt32(numericUpDown2.Value);
                numericUpDown1.Value = 0;
                numericUpDown2.Value = 0;
                button1.Text = "Restart";
                numThread.Start();
            }
        }
        private void Generate()
        {
            Start:
            if (Upper != 0)
                for (int i = Lower; i <= Upper; i++)
                {
                    if (resetNum)
                    {
                        resetNum = false;
                        goto Start;
                    }
                    try
                    {
                        if (isSimple(i))
                            this.Invoke((MethodInvoker)(() =>
                            {
                                listBox1.Items.Add(i.ToString());
                            }));
                        Thread.Sleep(500);
                    }
                    catch (Exception)
                    { break; }
                }
            else
            {
                int i = Lower;
                while (true)
                {
                    if (resetNum)
                    { resetNum = false; goto Start; }
                    try
                    {
                        if (psNum)
                            pauseNum.WaitOne();
                        if (isSimple(i))

                            this.Invoke((MethodInvoker)(() =>
                            {
                                listBox1.Items.Add(i.ToString());
                            }));
                        Thread.Sleep(500);
                    }
                    catch (Exception)
                    { break; }
                    i++;
                }
            }
            Lower = 0;
            Upper = 0;
            this.Invoke((MethodInvoker)(()=> {
                button1.Text = "Генерировать";
            }));
        }
        private bool isSimple(int N)
        {
            for (int i = 2; i <= (int)(N / 2); i++)
            {
                if (N % i == 0)
                    return false;
            }
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (numericUpDown3.Value != 0)
            {
                if (fibThread.IsAlive)
                {
                    resetFib = true;
                    FibEnd = Convert.ToInt32(numericUpDown3.Value);
                    numericUpDown3.Value = 0;
                }
                else
                {
                    FibEnd = Convert.ToInt32(numericUpDown3.Value);
                    numericUpDown3.Value = 0;
                    button2.Text = "Restart";
                    fibThread.Start();
                }
            }
        }
        private void GenerateFib()
        {
            StartFib:
            int j = 1;
            for (int i = 1; i <= FibEnd; i += j)
            {
                if(resetFib)
                {
                    resetFib = false;
                    goto StartFib;
                }
                try
                {
                    if (psFib)
                        pauseNum.WaitOne();
                    this.Invoke((MethodInvoker)(() =>
                    {
                        listBox2.Items.Add(i.ToString());
                    }));
                }
                catch (Exception)
                { break; }
                j = i - j;
            }
            this.Invoke((MethodInvoker)(() => {
                button2.Text = "Генерировать ряд Фибоначчи";
            }));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            numThread.Interrupt();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            fibThread.Interrupt();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            psNum = !psNum;
            if (psNum)
                button5.Text = "Resume";
            else
            { 
                pauseNum.Set();
                button5.Text = "Pause";
            } 
        }

        private void button6_Click(object sender, EventArgs e)
        {
            psFib = !psFib;
            if (psFib)
                button6.Text = "Resume";
            else
            {
                pauseFib.Set();
                button6.Text = "Pause";
            }
        }
    }
}
