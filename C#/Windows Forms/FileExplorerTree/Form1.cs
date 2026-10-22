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
using System.Diagnostics;

namespace WindowsForms6
{
    public partial class MainForm : Form
    {
        private ImageList imageList = new ImageList();
        private DriveInfo[] drivers = DriveInfo.GetDrives();
        public string renamed;
        public MainForm()
        {
            InitializeComponent();

            imageList.Images.Add("folder", Image.FromFile("folder.png"));
            imageList.Images.Add("folder_open", Image.FromFile("folder_open.png"));

            treeView.ImageList = imageList;
            treeView.BeforeExpand += BeforeExpand;
            treeView.AfterCollapse += AfterCollapse;

            foreach(var driver in drivers)
            {
                TreeNode node = treeView.Nodes.Add(driver.Name, driver.Name, imageKey: "folder", selectedImageKey: "folder_open");
                node.Nodes.Add("?");
            }

            treeView.MouseDoubleClick += TreeDoubleClick;
            treeView.PreviewKeyDown += TreeKey;

            ToolStripMenuItem deleteItem = new ToolStripMenuItem("Delete");
            ToolStripMenuItem renameItem = new ToolStripMenuItem("Rename");
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            renameItem.Click += RenameClick;
            deleteItem.Click += DeleteClick;
            contextMenu.Items.AddRange(new[] { deleteItem, renameItem });
            treeView.ContextMenuStrip = contextMenu;

            treeView.NodeMouseClick += (sender, args) => treeView.SelectedNode = args.Node;
        }

        private void BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
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
                    imageList.Images.Add("file", Image.FromFile("file.png"));
                    node.ImageKey = "file";
                    node.SelectedImageKey = "file";
                }
            }catch(UnauthorizedAccessException msg) { MessageBox.Show($"{msg.Message}", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
            if (e.Button == MouseButtons.Left && treeView.SelectedNode.ImageKey == "file")
                Process.Start(treeView.SelectedNode.FullPath);
        }
        private void TreeKey(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (treeView.SelectedNode.ImageKey == "file")
                    Process.Start(treeView.SelectedNode.FullPath);
                else
                    treeView.SelectedNode.Toggle();
            }
            if(e.KeyCode == Keys.Delete)
            {
                DeleteClick(null, null);
            }
            if(e.KeyCode == Keys.F12)
            {
                RenameClick(null, null);
            }
        }
        private void RenameClick(object sender, EventArgs e)
        {
            try {
                string[] tmp;
                if (treeView.SelectedNode.ImageKey != "file")
                    tmp = Directory.GetDirectories(treeView.SelectedNode.FullPath);
                foreach (var driver in drivers)
                {
                    if (driver.Name == treeView.SelectedNode.FullPath)
                        throw new UnauthorizedAccessException("Error");
                }
                RenameDialog renameDialog = new RenameDialog(treeView.SelectedNode.Name);
                renameDialog.Owner = this;
                DialogResult res = renameDialog.ShowDialog();
                if (res == DialogResult.OK)
                {
                    string rename = treeView.SelectedNode.FullPath.Replace(treeView.SelectedNode.Name, renamed);
                    if (rename.ToLower() == treeView.SelectedNode.FullPath.ToLower())
                        throw new UnauthorizedAccessException("DIR exist");
                    Directory.Move(treeView.SelectedNode.FullPath, rename);
                    treeView.SelectedNode.Parent.Toggle();
                    treeView.SelectedNode.Toggle();
                }
            }catch(UnauthorizedAccessException msg) { MessageBox.Show(msg.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
        private void DeleteClick(object sender ,EventArgs e)
        {
            try
            {
                string[] tmp;
                if (treeView.SelectedNode.ImageKey != "file")
                    tmp = Directory.GetDirectories(treeView.SelectedNode.FullPath);
                foreach (var driver in drivers)
                {
                    if (driver.Name == treeView.SelectedNode.FullPath)
                        throw new UnauthorizedAccessException("Error");
                }
                DialogResult res = MessageBox.Show($"Do you want to delete {treeView.SelectedNode.Name}?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(res == DialogResult.Yes)
                {
                    if (treeView.SelectedNode.ImageKey == "file")
                        File.Delete(treeView.SelectedNode.FullPath);
                    else
                    {
                        try {
                            Directory.Delete(treeView.SelectedNode.FullPath);
                        }
                        catch(Exception msg) 
                        {
                            DialogResult result = MessageBox.Show(msg.Message + "\nDelete?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if(result== DialogResult.Yes)
                                Directory.Delete(treeView.SelectedNode.FullPath, true);
                        }
                    }

                    treeView.SelectedNode.Parent.Toggle();
                    treeView.SelectedNode.Toggle();
                }
            }
            catch (UnauthorizedAccessException msg) { MessageBox.Show(msg.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

        }
    }
}
