using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace WinformApp
{
    public partial class Form1 : Form
    {
        private List<string> methods;
        private MethodInfo encrypt;
        private MethodInfo decrypt;
        private int Key { get; set; }
        private string filePath;
        private bool MethodAction { get; set; } = true;
        public Form1()
        {
            methods = new();
            InitializeComponent();
            comboBox1.Items.Add("Encrypt");
            comboBox1.Items.Add("Decrypt");
            comboBox1.SelectedIndex = 0;
            foreach (var item in new DirectoryInfo(Directory.GetCurrentDirectory()).GetFiles("*Method.dll"))
            {
                methods.Add(item.FullName);
                methodCmb.Items.Add(item.Name.Substring(0, item.Name.IndexOf(".dll")));
            }
            if (methods.Count != 0)
                methodCmb.SelectedIndex = 0;
        }

        private void startOp_Click(object sender, EventArgs e)
        {
            if(numericUpDown1.Value != 0)
            {
                if (!string.IsNullOrEmpty(filePath))
                {
                    Key = Convert.ToInt32(numericUpDown1.Value);
                    ThreadPool.QueueUserWorkItem(FileProcces, filePath);
                }
                else
                {
                    if (MethodAction && !string.IsNullOrEmpty(originText.Text))
                    {
                        object response = encrypt?.Invoke(null, new object[] { originText.Text, Convert.ToInt32(numericUpDown1.Value) });
                        encryptedText.Text = response.ToString();
                        originText.Text = "";
                    }
                    else if (!MethodAction && !string.IsNullOrEmpty(encryptedText.Text))
                    {
                        object response = decrypt?.Invoke(null, new object[] { encryptedText.Text, Convert.ToInt32(numericUpDown1.Value) });
                        originText.Text = response.ToString();
                        encryptedText.Text = "";
                    }
                }
            }
        }

        private void methodCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            Assembly asm = AssemblyLoadContext.Default.LoadFromAssemblyPath(methods[methodCmb.SelectedIndex]);
            Type encryptType = asm.GetType($"{methodCmb.SelectedItem.ToString()}.Chiper");
            encrypt = encryptType.GetMethod("Encrypt");
            Type decryptType = asm.GetType($"{methodCmb.SelectedItem.ToString()}.Chiper");
            decrypt = decryptType.GetMethod("Decrypt");
        }

        private void opnFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = Directory.GetCurrentDirectory();
            dlg.Filter = "Text files(*.txt)|*.txt";
            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;
            filePath = dlg.FileName;
        }
        private void FileProcces(object filename)
        {
            FileInfo fileInfo = new FileInfo(filename as string);
            string resName = "";
            if (MethodAction)
            {
                resName = fileInfo.Name + " Encrypted.txt";
                foreach (string line in File.ReadLines(filename as string))
                {
                    File.WriteAllText(resName, encrypt?.Invoke(null, new object[] { line, Key }) as string);
                }
            }
            else
            {
                resName = fileInfo.Name.Substring(0, fileInfo.Name.IndexOf(" Encrypted")) + " Decrypted.txt";
                foreach (string line in File.ReadLines(filename as string))
                {
                    File.WriteAllText(resName, decrypt?.Invoke(null, new object[] { line, Key }) as string);
                }
            }
            MessageBox.Show($"{resName}", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
                MethodAction = true;
            else if (comboBox1.SelectedIndex == 1)
                MethodAction = false;
        }
    }
}
