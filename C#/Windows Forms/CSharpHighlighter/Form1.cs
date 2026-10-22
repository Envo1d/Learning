using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms8
{
    public partial class Form1 : Form
    {
        MenuStrip menu = new MenuStrip();
        string FileName { get; set; }
        LoadKeys keys = new LoadKeys();
        public Form1()
        {
            InitializeComponent();

            var fileItem = menu.Items.Add("&File") as ToolStripMenuItem;

            var openItem = fileItem.DropDownItems.Add("Open") as ToolStripMenuItem;
            openItem.Click += OpenClick;

            fileItem.DropDownItems.Add(new ToolStripSeparator());

            var exitItem = fileItem.DropDownItems.Add("Exit") as ToolStripMenuItem;
            exitItem.Click += ExitClick;
            exitItem.ShowShortcutKeys = true;
            exitItem.ShortcutKeys = Keys.Control | Keys.X;  

            Controls.Add(menu);

            richBox.AllowDrop = true;
            richBox.DragDrop += RichBoxDragDrop;
            richBox.DragEnter += RichBoxDragEnter;
        }

        private void RichBoxDragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                richBox.Text = e.Data.GetData(DataFormats.StringFormat).ToString();
            }
            else if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var files = e.Data.GetData(DataFormats.FileDrop) as string[];
                richBox.LoadFile( files[0], RichTextBoxStreamType.PlainText);
            }
            ScanWord();
        }
        private void RichBoxDragEnter(object sender, DragEventArgs e)
        {
            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                e.Effect = DragDropEffects.Copy;
            }
            else if ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void OpenClick(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Title = "Открыть файл",
                Filter = "C# код|*.cs*|Текстовые файлы|*.txt|Rtf файлы|*.rtf|Все файлы|*.*"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var filePath = dialog.FileName;
                if (filePath.EndsWith(".txt") || filePath.EndsWith(".cs"))
                {
                    richBox.LoadFile(filePath, RichTextBoxStreamType.PlainText);
                    FileName = filePath;
                }
                else if (filePath.EndsWith(".rtf"))
                {
                    richBox.LoadFile(filePath, RichTextBoxStreamType.RichText);
                    FileName = filePath;
                }
                ScanWord();
            }
        }
        private void ExitClick(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ScanWord()
        {
            char[] separator = { '.', ',', ';', ':', '(', ')', '[', ']', '-', '+', '=', '\\', '*', '?', '\"', '\'', '$', '@', ' ', '!',
                (char)10, '&', '^', '_', '%', '#', '`', '~', '{', '}', '/', '|', '\n','\t','<','>' };
            List<string> tmp = richBox.Text.Split(separator, StringSplitOptions.RemoveEmptyEntries).Distinct().ToList();
            tmp.Sort();
            for (int i = 0; i < tmp.Count; i++)
            {
                string tmps = tmp[i];
                List<string> keyWord = keys.GetList(tmps);
                if (keyWord != null)
                    for (int j = 0; j < keyWord.Count; j++)
                    {
                        if (tmps == keyWord[j])
                        {
                            int idx = 0;
                            while (true)
                            {
                                idx = richBox.Find(tmps, idx, RichTextBoxFinds.WholeWord | RichTextBoxFinds.MatchCase);
                                if (idx == -1)
                                    break;
                                richBox.Select(idx, tmps.Length);
                                richBox.SelectionColor = Color.Blue;
                                idx += tmps.Length;
                            }
                        }
                    }
            }
        }
    }
}
