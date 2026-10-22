using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Writer
{
    public partial class WriterForm : Form
    {
        private Mutex Mutex { get; set; }
        private bool isCreated;
        private FileStream fs;
        private string dirPath = "C:/WriteRead";
        private string filePath = "test.txt";
        public WriterForm()
        {
            InitializeComponent();
            Mutex = new Mutex(true, "FileReadWrite", out isCreated);
            if (!Directory.Exists(dirPath))
                Directory.CreateDirectory(dirPath);
            if (File.Exists($"{dirPath}/{filePath}"))
                File.Delete($"{dirPath}/{filePath}");
            fs = new FileStream($"{dirPath}/{filePath}", FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read);
            this.FormClosing += WriterForm_FormClosing;
        }

        private void WriterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            fs.Close();
            try { Mutex.ReleaseMutex(); } catch { };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] arr = Encoding.Default.GetBytes(textBox1.Text);
            fs.Write(arr, 0, arr.Length);
            fs.Flush();
            textBox1.Text = null;
            Mutex.ReleaseMutex();
            Mutex.WaitOne();
        }
    }
}
