using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reader
{
    public partial class ReaderForm : Form
    {
        private Mutex Mutex { get; set; }
        private FileStream fs;
        private System.Windows.Forms.Timer timer;
        private bool isCreated;
        public ReaderForm()
        {
            InitializeComponent();
            Thread.Sleep(1000);
            Mutex = new Mutex(false, "FileReadWrite", out isCreated);
            timer = new();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            fs = new FileStream("C:/WriteRead/test.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            this.FormClosing += ReaderForm_FormClosing;
        }

        private void ReaderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            fs.Close();
            try { Mutex.ReleaseMutex(); } catch { };
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(o => { Read(); });
            timer.Stop();
        }

        private void Read()
        {
        Flag:
            while (!Mutex.WaitOne(1000))
            {
                this.Invoke((Action)(() => { textBox1.Text += "Waiting for mutex\r\n"; }));

            } 
            byte[] array = null;
            try
            {
                array = new byte[fs.Length];
            }
            catch { this.Invoke((Action)(() => { this.Close(); })); };
            fs.Read(array, 0, array.Length);
            if (array.Length == 0 || array[0] == 0)
                this.Invoke((Action)(() => { this.Close(); }));
            try
            {
                this.Invoke((Action)(() => { textBox1.Text = System.Text.Encoding.Default.GetString(array) + "\r\n"; }));
            }
            catch { this.Invoke((Action)(() => { this.Close(); })); };
            Mutex.ReleaseMutex();
            goto Flag;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (isCreated)
                Close();
            else
            {
                timer.Start();
            }
        }
    }
}
