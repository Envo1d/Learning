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

namespace ProgressBar
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource tokenSource;
        private CancellationToken token;
        private bool isClicked = false;
        private Task task;
        private IProgress<int> progress;
        public Form1()
        {
            InitializeComponent();
            progressBar1.Maximum = 100;
            progressBar1.Minimum = 0;
            progress = new Progress<int>(value => { progressBar1.Value = value; });
            tokenSource = new();
            token = tokenSource.Token;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!isClicked)
            {
                if(tokenSource.IsCancellationRequested)
                {
                    tokenSource = new();
                    token = tokenSource.Token;
                }
                task = Task.Run(() => {
                byte num = 0;
                while (num <= 100)
                {
                        if (token.IsCancellationRequested)
                            break;
                        progress?.Report(num++);
                        Thread.Sleep(1000);
                    }
                    Thread.Sleep(1000);
                    this.Invoke((Action)(() =>
                    {
                        isClicked = !isClicked;
                        progressBar1.Value = 0;
                        button1.Text = "Start";
                    }));
                }, cancellationToken: token);
                isClicked = !isClicked;
                button1.Text = "Stop";
            }
            else
            {
                tokenSource.Cancel();
                isClicked = !isClicked;
                progressBar1.Value = 0;
                button1.Text = "Start";
            }
        }
    }
}
