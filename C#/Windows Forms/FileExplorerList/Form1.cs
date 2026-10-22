using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WindowsForms7
{
    public partial class Form1 : Form
    {
        private MenuStrip menu = new MenuStrip();
        private ImageList treeList = new ImageList();
        private ImageList viewListLarge = new ImageList();
        private DriveInfo[] drives = DriveInfo.GetDrives();
        public string renamed;
        private ColumnHeader sortingColumn = null;
        private bool isRenamedByClick = false;
        private string renameList;
        public Form1()
        {
            InitializeComponent();

            ToolStripMenuItem exitItem = new ToolStripMenuItem("Exit");
            ToolStripMenuItem fileItem = menu.Items.Add("&File") as ToolStripMenuItem;
            exitItem.ShortcutKeys = Keys.Control | Keys.X;
            exitItem.ShowShortcutKeys = true;
            exitItem.Click += (sender, e) => Close();
            fileItem.DropDownItems.Add(exitItem);
            Controls.Add(menu);

            treeList.Images.Add("folder", Image.FromFile("Images/folder.png"));
            treeList.Images.Add("folder_open", Image.FromFile("Images/folder_open.png"));
            treeList.Images.Add("file", Image.FromFile("Images/file.png"));
            treeList.Images.Add("drive", Image.FromFile("Images/drive.png"));

            viewListLarge.Images.Add("folder", Image.FromFile("Images/folder.png"));
            viewListLarge.Images.Add("folder_open", Image.FromFile("Images/folder_open.png"));
            viewListLarge.Images.Add("file", Image.FromFile("Images/file.png"));
            viewListLarge.Images.Add("drive", Image.FromFile("Images/drive.png"));
            viewListLarge.ImageSize = new Size(50, 50);

            treeView1.ImageList = treeList;
            listView1.LargeImageList = viewListLarge;
            listView1.SmallImageList = treeList;

            treeView1.BeforeExpand += BeforeExpand;
            treeView1.AfterCollapse += AfterCollapse;
            treeView1.MouseDoubleClick += TreeDoubleClick;
            treeView1.PreviewKeyDown += TreeKey;

            ToolStripMenuItem deleteItem = new ToolStripMenuItem("Delete");
            ToolStripMenuItem renameItem = new ToolStripMenuItem("Rename");
            ContextMenuStrip contextMenuTree = new ContextMenuStrip();
            renameItem.Click += RenameClick;
            deleteItem.Click += DeleteClick;
            contextMenuTree.Items.AddRange(new[] { deleteItem, renameItem });
            treeView1.ContextMenuStrip = contextMenuTree;
            treeView1.NodeMouseClick += (sender, args) => treeView1.SelectedNode = args.Node;

            foreach (var drive in drives)
            {
                if (drive.IsReady)
                {
                    TreeNode node = treeView1.Nodes.Add(drive.Name, drive.Name, imageKey: "drive", selectedImageKey: "drive");
                    node.Nodes.Add("?");
                }
            }

            treeView1.AfterSelect += TreeView1_AfterSelect;

            var names = Enum.GetNames(typeof(View));
            var viewItem = menu.Items.Add("&View") as ToolStripMenuItem;
            viewItem.DropDownItems.AddRange(names.Select(ev => new ToolStripMenuItem(ev, null, ViewChange)).ToArray());

            ToolStripMenuItem vwItem = new ToolStripMenuItem("View");
            ContextMenuStrip contextMenuList = new ContextMenuStrip();
            vwItem.DropDownItems.AddRange(names.Select(ev => new ToolStripMenuItem(ev, null, ViewChange)).ToArray());
            contextMenuList.Items.Add(vwItem);
            ToolStripMenuItem rnmItem = new ToolStripMenuItem("Rename");
            rnmItem.Click += ListRename;
            ToolStripMenuItem dltItem = new ToolStripMenuItem("Delate");
            dltItem.Click += ListDelete;
            contextMenuList.Items.Add(rnmItem);
            contextMenuList.Items.Add(dltItem);
            listView1.ContextMenuStrip = contextMenuList;

            listView1.View = View.Tile;
            listView1.MouseDoubleClick += ListView1_MouseDoubleClick;
            listView1.Columns.Add("Name");
            listView1.Columns.Add("Size");
            listView1.Columns.Add("Date of creation");

            pictureBox1.MouseEnter += (s, e) => pictureBox1.Image = Image.FromFile("Images/up2.png");
            pictureBox1.MouseLeave += (s, e) => pictureBox1.Image = Image.FromFile("Images/up.png");

            listView1.ColumnClick += ColumnClick;

            treeView1.AfterLabelEdit += AfterLabelEdit;
            treeView1.BeforeLabelEdit += BeforeLabelEdit;

            listView1.PreviewKeyDown += ListView1_PreviewKeyDown;
            listView1.AfterLabelEdit += AfterListLabelEdit;
            listView1.BeforeLabelEdit += BeforeListLabelEdit;
        }

        private void BeforeListLabelEdit(object sender, LabelEditEventArgs e)
        {
            listView1.PreviewKeyDown -= ListView1_PreviewKeyDown;
        }
        private void AfterListLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (e.Label == null)
                return;
            bool isDrive = false;
            foreach (var drive in drives)
            {
                if (e.Label.Contains(drive.Name))
                    isDrive = true;
            }
            if (!isDrive)
            {
                if (e.Label != null)
                {
                    if (e.Label.Length > 0)
                    {
                        if (e.Label.IndexOfAny(new char[] { '@', ',', '!' }) == -1)
                        {
                            Directory.Move(textBox1.Text + $"\\{renameList}", textBox1.Text + $"\\{e.Label}");
                            if (treeView1.SelectedNode.Nodes.ContainsKey(renameList))
                            {
                                treeView1.SelectedNode.Toggle();
                                treeView1.SelectedNode.Toggle();
                            }
                            if (treeView1.SelectedNode.Parent.Nodes.ContainsKey(renameList))
                            {
                                treeView1.SelectedNode.Parent.Toggle();
                                treeView1.SelectedNode.Parent.Toggle();
                            }
                            listView1.PreviewKeyDown += ListView1_PreviewKeyDown;
                        }
                        else
                        {
                            e.CancelEdit = true;
                            MessageBox.Show("Invalid tree node label.\n" +
                               "The invalid characters are: '@', ',', '!'",
                               "Node Label Edit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        e.CancelEdit = true;
                        MessageBox.Show("Invalid tree node label.\nThe label cannot be blank",
                           "Node Label Edit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
        private void ListView1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (listView1.SelectedItems[0].ImageKey == "file")
                    Process.Start(textBox1.Text + $"\\{listView1.SelectedItems[0].Text}");
                else { ListView1_MouseDoubleClick(null, new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0)); }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                ListDelete(null, null);
            }
            else if (e.KeyCode == Keys.Delete)
            {
                ListRename(null, null);
            }
        }
        private void ListDelete(object sender, EventArgs e)
        {
            try
            {
                string[] check;
                if (treeView1.SelectedNode.ImageKey != "file")
                    check = Directory.GetDirectories(treeView1.SelectedNode.FullPath);
                DialogResult res = MessageBox.Show($"Do you want to delete {listView1.SelectedItems[0].Text}?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {

                    if (listView1.SelectedItems[0].ImageKey == "file")
                        File.Delete(textBox1.Text + $"\\{listView1.SelectedItems[0].Text}");
                    else
                    {
                        try
                        {
                            Directory.Delete(textBox1.Text + $"\\{listView1.SelectedItems[0].Text}");
                        }
                        catch (Exception msg)
                        {
                            DialogResult result = MessageBox.Show(msg.Message + "\nDelete?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                                Directory.Delete(textBox1.Text + $"\\{listView1.SelectedItems[0].Text}", true);
                        }
                    }
                    
                    if (treeView1.SelectedNode.Nodes.ContainsKey(listView1.SelectedItems[0].Text))
                    {
                        treeView1.SelectedNode.Toggle();
                        treeView1.SelectedNode.Toggle();
                    }
                    if(treeView1.SelectedNode.Parent.Nodes.ContainsKey(listView1.SelectedItems[0].Text))
                    {
                        treeView1.SelectedNode.Parent.Toggle();
                        treeView1.SelectedNode.Parent.Toggle();
                    }
                    listView1.Items.Remove(listView1.SelectedItems[0]);
                }
            }
            catch (UnauthorizedAccessException msg) { MessageBox.Show(msg.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
        private void ListRename(object sender, EventArgs e)
        {
            try
            {
                string[] check;
                if (listView1.SelectedItems[0].ImageKey != "file")
                    check = Directory.GetDirectories(textBox1.Text + $"\\{listView1.SelectedItems[0].Text}");
                string tmp = textBox1.Text;
                while (textBox1.Text.Contains("\\"))
                    textBox1.Text = textBox1.Text.Replace("\\", "");
                foreach (var drive in drives)
                {
                    if (drive.Name == textBox1.Text)
                        return;
                }
                textBox1.Text = tmp;
                listView1.LabelEdit = true;
                renameList = listView1.SelectedItems[0].Text;
                listView1.SelectedItems[0].BeginEdit();
            }
            catch (UnauthorizedAccessException msg) { MessageBox.Show(msg.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
        private void BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            treeView1.PreviewKeyDown -= TreeKey;
        }
        private void AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Node.ImageKey != "drive")
            {
                if (e.Label != null)
                {
                    if (e.Label.Length > 0)
                    {
                        if (e.Label.IndexOfAny(new char[] { '@', ',', '!' }) == -1)
                        {
                            renamed = e.Label;
                            isRenamedByClick = true;
                            RenameClick(null, null);
                            treeView1.PreviewKeyDown += TreeKey;
                            e.Node.EndEdit(false);
                        }
                        else
                        {
                            e.CancelEdit = true;
                            MessageBox.Show("Invalid tree node label.\n" +
                               "The invalid characters are: '@', ',', '!'",
                               "Node Label Edit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            e.Node.BeginEdit();
                        }
                    }
                    else
                    {
                        e.CancelEdit = true;
                        MessageBox.Show("Invalid tree node label.\nThe label cannot be blank",
                           "Node Label Edit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Node.BeginEdit();
                    }
                }
            }
        }
        private void ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ColumnHeader clHeader = listView1.Columns[e.Column];

            SortOrder order = (SortOrder)1;
            if (sortingColumn == null)
            {
                order = SortOrder.Ascending;
            }
            else
            {
                if (clHeader == sortingColumn)
                {
                    if (sortingColumn.Text.StartsWith("↓ "))
                    {
                        order = SortOrder.Descending;
                    }
                    else
                    {
                        order = SortOrder.Ascending;
                    }
                }
                else
                {
                    order = SortOrder.Ascending;
                }
                sortingColumn.Text = sortingColumn.Text.Substring(2);
            }
            List<ListViewItem> items = new List<ListViewItem>();
            List<ListViewItem> dir = new List<ListViewItem>();
            List<ListViewItem> files = new List<ListViewItem>();
            foreach (var item in listView1.Items)
                items.Add(item as ListViewItem);
            sortingColumn = clHeader;

            if (e.Column == 0)
                if (order == SortOrder.Ascending)
                {
                    sortingColumn.Text = "↓ " + sortingColumn.Text;
                    dir = items.Where(i => i.ImageKey == "folder").OrderBy(i => i.Text).ToList();
                    files = items.Where(i => i.ImageKey == "file").OrderBy(i => i.Text).ToList();
                }
                else
                {
                    sortingColumn.Text = "↑ " + sortingColumn.Text;
                    dir = items.Where(i => i.ImageKey == "folder").OrderByDescending(i => i.Text).ToList();
                    files = items.Where(i => i.ImageKey == "file").OrderByDescending(i => i.Text).ToList();
                }
            else if (e.Column == 1)
                if (order == SortOrder.Ascending)
                {
                    sortingColumn.Text = "↓ " + sortingColumn.Text;
                    dir = items.Where(i => i.ImageKey == "folder").ToList();
                    files = items.Where(i => i.ImageKey == "file").OrderBy(i => Convert.ToDouble(i.SubItems[1].Text)).ToList();
                }
                else
                {
                    sortingColumn.Text = "↑ " + sortingColumn.Text;
                    dir = items.Where(i => i.ImageKey == "folder").ToList();
                    files = items.Where(i => i.ImageKey == "file").OrderByDescending(i => Convert.ToDouble(i.SubItems[1].Text)).ToList();
                }
            else if (e.Column == 2)
                if (order == SortOrder.Ascending)
                {
                    sortingColumn.Text = "↓ " + sortingColumn.Text;
                    dir = items.Where(i => i.ImageKey == "folder").OrderBy(i => Convert.ToDateTime(i.SubItems[2].Text)).ToList();
                    files = items.Where(i => i.ImageKey == "file").OrderBy(i => Convert.ToDateTime(i.SubItems[2].Text)).ToList();
                }
                else
                {
                    sortingColumn.Text = "↑ " + sortingColumn.Text;
                    dir = items.Where(i => i.ImageKey == "folder").OrderByDescending(i => Convert.ToDateTime(i.SubItems[2].Text)).ToList();
                    files = items.Where(i => i.ImageKey == "file").OrderByDescending(i => Convert.ToDateTime(i.SubItems[2].Text)).ToList();
                }

            listView1.Items.Clear();
            listView1.Items.AddRange(dir.ToArray());
            listView1.Items.AddRange(files.ToArray());

            GC.Collect();
        }
        private void ListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                string path;
                if (textBox1.Text != "")
                    path = textBox1.Text.Replace("\\", "\\\\") + "\\" + listView1.SelectedItems[0].Name;
                else
                    path = listView1.SelectedItems[0].Text;
                if (listView1.SelectedItems[0].ImageKey != "file")
                {
                    listView1.Items.Clear();
                    try
                    {
                        var folderDirec = Directory.GetDirectories(path);
                        var folderFiles = Directory.GetFiles(path);
                        textBox1.Text = path.Replace("\\\\", "\\");
                        for (int i = 0; i < folderDirec.Length; i++)
                        {
                            folderDirec[i] = folderDirec[i].Replace(path, "");
                            if (folderDirec[i].Contains("\\"))
                                folderDirec[i] = folderDirec[i].Replace("\\", "");
                        }
                        for (int i = 0; i < folderFiles.Length; i++)
                        {
                            folderFiles[i] = folderFiles[i].Replace(path, "");
                            if (folderFiles[i].Contains("\\"))
                                folderFiles[i] = folderFiles[i].Replace("\\", "");
                        }
                        foreach (var item in folderDirec)
                        {
                            var itm = listView1.Items.Add(item, item, imageKey: "folder");
                            DirectoryInfo info = new DirectoryInfo(path + item);
                            itm.SubItems.Add("");
                            itm.SubItems.Add(info.CreationTime.Date.ToShortDateString());
                        }
                        foreach (var item in folderFiles)
                        {
                            var itm = listView1.Items.Add(item, item, imageKey: "file");
                            FileInfo info = new FileInfo(path + "\\" + item);
                            itm.SubItems.Add($"{(info.Length / 1024 == 0 ? 1 : info.Length / 1024)}");
                            itm.SubItems.Add(info.CreationTime.Date.ToShortDateString());
                        }
                    }
                    catch (Exception msg) { MessageBox.Show($"{msg.Message}", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                {
                    if (e.Button == MouseButtons.Left)
                        Process.Start(textBox1.Text + $"\\{listView1.SelectedItems[0].Text}");
                }
            }
        }
        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.ImageKey != "file")
            {
                listView1.Items.Clear();
                try
                {
                    var folderDirec = Directory.GetDirectories(e.Node.FullPath);
                    var folderFiles = Directory.GetFiles(e.Node.FullPath);
                    textBox1.Text = e.Node.FullPath.Replace("\\\\", "\\");
                    for (int i = 0; i < folderDirec.Length; i++)
                    {
                        folderDirec[i] = folderDirec[i].Replace(e.Node.FullPath, "");
                        if (folderDirec[i].Contains("\\"))
                            folderDirec[i] = folderDirec[i].Replace("\\", "");
                    }
                    for (int i = 0; i < folderFiles.Length; i++)
                    {
                        folderFiles[i] = folderFiles[i].Replace(e.Node.FullPath, "");
                        if (folderFiles[i].Contains("\\"))
                            folderFiles[i] = folderFiles[i].Replace("\\", "");
                    }
                    foreach (var item in folderDirec)
                    {
                        var itm = listView1.Items.Add(item, item, imageKey: "folder");
                        DirectoryInfo info = new DirectoryInfo(e.Node.FullPath + item);
                        itm.SubItems.Add("");
                        itm.SubItems.Add(info.CreationTime.Date.ToShortDateString());
                    }
                    foreach (var item in folderFiles)
                    {
                        var itm = listView1.Items.Add(item, item, imageKey: "file");
                        FileInfo info = new FileInfo(e.Node.FullPath + "\\" + item);
                        itm.SubItems.Add($"{(info.Length / 1024 == 0 ? 1 : info.Length / 1024)}");
                        itm.SubItems.Add(info.CreationTime.Date.ToShortDateString());
                    }
                }
                catch (UnauthorizedAccessException msg) { MessageBox.Show($"{msg.Message}", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }
        private void ViewChange(object sender, EventArgs e)
        {
            var menuItem = sender as ToolStripMenuItem;
            if (menuItem == null) return;
            listView1.View = (View)Enum.Parse(typeof(View), menuItem.Text);
            if (listView1.View == View.Details)
            {
                foreach (ColumnHeader column in listView1.Columns)
                {
                    column.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                }
            }
        }
        private void BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.ImageKey != "drive")
                e.Node.ImageKey = "folder_open";
            e.Node.Nodes.Clear();
            try
            {
                var folderDirec = Directory.GetDirectories(e.Node.FullPath);
                var folderFiles = Directory.GetFiles(e.Node.FullPath);
                for (int i = 0; i < folderDirec.Length; i++)
                {
                    folderDirec[i] = folderDirec[i].Replace(e.Node.FullPath, "");
                    if (folderDirec[i].Contains("\\"))
                        folderDirec[i] = folderDirec[i].Replace("\\", "");
                }
                for (int i = 0; i < folderFiles.Length; i++)
                {
                    folderFiles[i] = folderFiles[i].Replace(e.Node.FullPath, "");
                    if (folderFiles[i].Contains("\\"))
                        folderFiles[i] = folderFiles[i].Replace("\\", "");
                }
                foreach (var item in folderDirec)
                {
                    TreeNode node = e.Node.Nodes.Add(item, item, imageKey: "folder", selectedImageKey: "folder_open");
                    node.Nodes.Add("?");
                }
                foreach (var item in folderFiles)
                {
                    TreeNode node = e.Node.Nodes.Add(item, item);
                    FileInfo fileInfo = new FileInfo(item);

                    node.ImageKey = "file";
                    node.SelectedImageKey = "file";
                }
            }
            catch (Exception msg) { MessageBox.Show($"{msg.Message}", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void AfterCollapse(object sender, TreeViewEventArgs e)
        {
            e.Node.Nodes.Clear();
            e.Node.Nodes.Add("?");
            e.Node.ImageKey = "folder";
            GC.Collect();
        }
        private void TreeDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && treeView1.SelectedNode.ImageKey == "file")
                Process.Start(treeView1.SelectedNode.FullPath);
        }
        private void TreeKey(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (treeView1.SelectedNode.ImageKey == "file")
                    Process.Start(treeView1.SelectedNode.FullPath);
                else
                    treeView1.SelectedNode.Toggle();
            }
            if (e.KeyCode == Keys.Delete)
            {
                DeleteClick(null, null);
            }
            if (e.KeyCode == Keys.F12)
            {
                RenameClick(null, null);
            }
        }
        private void RenameClick(object sender, EventArgs e)
        {
            try
            {
                string[] tmp;
                if (treeView1.SelectedNode.ImageKey != "file")
                    tmp = Directory.GetDirectories(treeView1.SelectedNode.FullPath);
                foreach (var drive in drives)
                {
                    if (drive.Name == treeView1.SelectedNode.FullPath)
                        throw new UnauthorizedAccessException("Error");
                }
                if (!isRenamedByClick)
                {
                    RenameDialog renameDialog = new RenameDialog(treeView1.SelectedNode.Name);
                    renameDialog.Owner = this;
                    DialogResult res = renameDialog.ShowDialog();
                    if (res == DialogResult.OK)
                    {
                        string rename = treeView1.SelectedNode.FullPath.Replace(treeView1.SelectedNode.Name, renamed);
                        if (rename.ToLower() == treeView1.SelectedNode.FullPath.ToLower())
                            throw new UnauthorizedAccessException("DIR exist");
                        Directory.Move(treeView1.SelectedNode.FullPath, rename);
                        treeView1.SelectedNode.Parent.Toggle();
                        treeView1.SelectedNode.Toggle();
                    }
                }
                else
                {
                    string rename = treeView1.SelectedNode.FullPath.Replace(treeView1.SelectedNode.Name, renamed);
                    if (rename.ToLower() == treeView1.SelectedNode.FullPath.ToLower())
                        throw new UnauthorizedAccessException("DIR exist");
                    Directory.Move(treeView1.SelectedNode.FullPath, rename);
                    treeView1.SelectedNode.Parent.Toggle();
                    treeView1.SelectedNode.Toggle();
                    isRenamedByClick = false;
                }
            }
            catch (UnauthorizedAccessException msg) { MessageBox.Show(msg.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            if (textBox1.Text.Contains(treeView1.SelectedNode.Parent.Text))
            {
                string path = textBox1.Text.Replace("\\", "\\\\");
                listView1.Items.Clear();
                try
                {
                    var folderDirec = Directory.GetDirectories(path);
                    var folderFiles = Directory.GetFiles(path);
                    textBox1.Text = path.Replace("\\\\", "\\");
                    for (int i = 0; i < folderDirec.Length; i++)
                    {
                        folderDirec[i] = folderDirec[i].Replace(path, "");
                        if (folderDirec[i].Contains("\\"))
                            folderDirec[i] = folderDirec[i].Replace("\\", "");
                    }
                    for (int i = 0; i < folderFiles.Length; i++)
                    {
                        folderFiles[i] = folderFiles[i].Replace(path, "");
                        if (folderFiles[i].Contains("\\"))
                            folderFiles[i] = folderFiles[i].Replace("\\", "");
                    }
                    foreach (var item in folderDirec)
                    {
                        var itm = listView1.Items.Add(item, item, imageKey: "folder");
                        DirectoryInfo info = new DirectoryInfo(path + item);
                        itm.SubItems.Add("");
                        itm.SubItems.Add(info.CreationTime.Date.ToShortDateString());
                    }
                    foreach (var item in folderFiles)
                    {
                        var itm = listView1.Items.Add(item, item, imageKey: "file");
                        FileInfo info = new FileInfo(path + "\\" + item);
                        itm.SubItems.Add($"{(info.Length / 1024 == 0 ? 1 : info.Length / 1024)}");
                        itm.SubItems.Add(info.CreationTime.Date.ToShortDateString());
                    }
                }
                catch (UnauthorizedAccessException msg) { MessageBox.Show($"{msg.Message}", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }
        private void DeleteClick(object sender, EventArgs e)
        {
            try
            {
                string[] tmp;
                if (treeView1.SelectedNode.ImageKey != "file")
                    tmp = Directory.GetDirectories(treeView1.SelectedNode.FullPath);
                foreach (var drive in drives)
                {
                    if (drive.Name == treeView1.SelectedNode.FullPath)
                        throw new UnauthorizedAccessException("Error");
                }
                DialogResult res = MessageBox.Show($"Do you want to delete {treeView1.SelectedNode.Name}?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {

                    if (treeView1.SelectedNode.ImageKey == "file")
                        File.Delete(treeView1.SelectedNode.FullPath);
                    else
                    {
                        try
                        {
                            Directory.Delete(treeView1.SelectedNode.FullPath);
                        }
                        catch (Exception msg)
                        {
                            DialogResult result = MessageBox.Show(msg.Message + "\nDelete?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                                Directory.Delete(treeView1.SelectedNode.FullPath, true);
                        }
                    }
                    treeView1.SelectedNode.Parent.Toggle();
                    treeView1.SelectedNode.Toggle();
                }
            }
            catch (UnauthorizedAccessException msg) { MessageBox.Show(msg.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            if (textBox1.Text.Contains(treeView1.SelectedNode.Parent.Text))
            {
                string path = textBox1.Text.Replace("\\", "\\\\");
                listView1.Items.Clear();
                try
                {
                    var folderDirec = Directory.GetDirectories(path);
                    var folderFiles = Directory.GetFiles(path);
                    textBox1.Text = path.Replace("\\\\", "\\");
                    for (int i = 0; i < folderDirec.Length; i++)
                    {
                        folderDirec[i] = folderDirec[i].Replace(path, "");
                        if (folderDirec[i].Contains("\\"))
                            folderDirec[i] = folderDirec[i].Replace("\\", "");
                    }
                    for (int i = 0; i < folderFiles.Length; i++)
                    {
                        folderFiles[i] = folderFiles[i].Replace(path, "");
                        if (folderFiles[i].Contains("\\"))
                            folderFiles[i] = folderFiles[i].Replace("\\", "");
                    }
                    foreach (var item in folderDirec)
                    {
                        var itm = listView1.Items.Add(item, item, imageKey: "folder");
                        DirectoryInfo info = new DirectoryInfo(path + item);
                        itm.SubItems.Add("");
                        itm.SubItems.Add(info.CreationTime.Date.ToShortDateString());
                    }
                    foreach (var item in folderFiles)
                    {
                        var itm = listView1.Items.Add(item, item, imageKey: "file");
                        FileInfo info = new FileInfo(path + "\\" + item);
                        itm.SubItems.Add($"{(info.Length / 1024 == 0 ? 1 : info.Length / 1024)}");
                        itm.SubItems.Add(info.CreationTime.Date.ToShortDateString());
                    }
                }
                catch (UnauthorizedAccessException msg) { MessageBox.Show($"{msg.Message}", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                return;
            string path = textBox1.Text.Replace("\\", "\\\\");
            var idx = path.LastIndexOf("\\\\");
            string newPath = "";
            for (int i = 0; i < idx; i++)
            {
                newPath += path[i];
            }
            ListViewItem dr = null;
            foreach (var drive in drives)
            {
                if (drive.IsReady)
                    if (drive.Name.Replace("\\", "") == newPath)
                    {
                        listView1.Items.Clear();
                        foreach (var d in drives)
                        { dr = listView1.Items.Add(d.Name); dr.ImageKey = "drive"; }
                        textBox1.Text = null;
                        return;
                    }
            }
            listView1.Items.Clear();
            try
            {
                var folderDirec = Directory.GetDirectories(newPath);
                var folderFiles = Directory.GetFiles(newPath);
                textBox1.Text = newPath.Replace("\\\\", "\\");
                for (int i = 0; i < folderDirec.Length; i++)
                {
                    folderDirec[i] = folderDirec[i].Replace(newPath, "");
                    if (folderDirec[i].Contains("\\"))
                        folderDirec[i] = folderDirec[i].Replace("\\", "");
                }
                for (int i = 0; i < folderFiles.Length; i++)
                {
                    folderFiles[i] = folderFiles[i].Replace(newPath, "");
                    if (folderFiles[i].Contains("\\"))
                        folderFiles[i] = folderFiles[i].Replace("\\", "");
                }
                foreach (var item in folderDirec)
                {
                    var itm = listView1.Items.Add(item, item, imageKey: "folder");
                    DirectoryInfo info = new DirectoryInfo(newPath + item);
                    itm.SubItems.Add("");
                    itm.SubItems.Add(info.CreationTime.Date.ToShortDateString());
                }
                foreach (var item in folderFiles)
                {
                    var itm = listView1.Items.Add(item, item, imageKey: "file");
                    FileInfo info = new FileInfo(newPath + "\\" + item);
                    itm.SubItems.Add($"{(info.Length / 1024 == 0 ? 1 : info.Length / 1024)} K");
                    itm.SubItems.Add(info.CreationTime.Date.ToShortDateString());
                }
            }
            catch (UnauthorizedAccessException msg) { MessageBox.Show($"{msg.Message}", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            GC.Collect();
        }
    }
}