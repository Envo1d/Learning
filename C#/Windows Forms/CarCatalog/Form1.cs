using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormsHW4
{
    public partial class CarCatalogForm : Form
    {
        private const string btnPath = "Assets/";
        private Size pnlMenuSize = new Size(48, 708);
        private bool menuOpened = false;
        private AddCarDialog carDialog;
        public event EventHandler<Car> CarEvents;
        private SaveLoad saveLoad = new SaveLoad();

        public CarCatalogForm()
        {
            InitializeComponent();
            pnlMenu.Size = pnlMenuSize;

            lblAdd.Visible = false;
            lblRemove.Visible = false;

            #region BtnEvents
            btnClose.Click += CloseClick;
            btnClose.MouseEnter += CloseMsEnter;
            btnClose.MouseLeave += CloseMsLeave;
            btnMinimize.Click += MinimizeClick;
            btnMinimize.MouseEnter += MinimizeMsEnter;
            btnMinimize.MouseLeave += MinimizeMsLeave;
            btnMenu.Click += MenuClick;
            btnMenu.MouseEnter += MenuMsEnter;
            btnMenu.MouseLeave += MenuMsLeave;
            btnAdd.Click += AddClick;
            btnAdd.MouseEnter += AddMsEnter;
            btnAdd.MouseLeave += AddMsLeave;
            btnRemove.Click += RemoveClick;
            btnRemove.MouseEnter += RemoveMsEnter;
            btnRemove.MouseLeave += RemoveMsLeave;
            btnLoad.Click += LoadClick;
            btnLoad.MouseEnter += LoadEnter;
            btnLoad.MouseLeave += LoadLeave;
            btnSave.Click += SaveClick;
            btnSave.MouseEnter += SaveEnter;
            btnSave.MouseLeave += SaveLeave;
            lblAdd.Click += AddClick;
            lblAdd.MouseEnter += AddMsEnter;
            lblAdd.MouseLeave += AddMsLeave;
            lblRemove.Click += RemoveClick;
            lblRemove.MouseEnter += RemoveMsEnter;
            lblRemove.MouseLeave += RemoveMsLeave;
            lblLoad.Click += LoadClick;
            lblLoad.MouseEnter += LoadEnter;
            lblLoad.MouseLeave += LoadLeave;
            lblSave.Click += SaveClick;
            lblSave.MouseEnter += SaveEnter;
            lblSave.MouseLeave += SaveLeave;
            #endregion
        }

        #region DiffFormEvents
        private void CarDialogAddEvent(object sender, Car car)
        {
            if (car == null) return;
            lstBox.Items.Add(car);
        }
        private void lstBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            carDialog = new AddCarDialog();
            carDialog.Owner = this;
            carDialog.Show();
            carDialog.AddCar += CarDialogAddEvent;
            CarEvents += carDialog.SelectedCarHandler;
            CarEvents?.Invoke(sender, lstBox.SelectedItem as Car);
        }
        private void lstBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                lstBox.Items.Remove(lstBox.SelectedItem);
        }
        public void UpdateRecEvent(object sender, Car car)
        {
            if (car == null) return;
            var idx = lstBox.SelectedIndex;
            lstBox.Items.RemoveAt(idx);
            if (lstBox.Items.Count == 0)
                lstBox.Items.Add(car);
            else
                lstBox.Items.Insert(idx, car);
        }
        public void DeleteRecEvent(object sender, Car car)
        {
            if (car == null) return;
            lstBox.Items.Remove(lstBox.SelectedItem);
        }
        #endregion

        #region BtnsEvents
        public void CloseClick(object sender, EventArgs e)
        {
            this.Close();
        }
        public void CloseMsEnter(object sender, EventArgs e)
        {
            btnClose.Image = Image.FromFile(btnPath + "close.png");
        }
        public void CloseMsLeave(object sender, EventArgs e)
        {
            btnClose.Image = Image.FromFile(btnPath + "close_icon.png");
        }
        public void MinimizeClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        public void MinimizeMsEnter(object sender, EventArgs e)
        {
            btnMinimize.Image = Image.FromFile(btnPath + "minimize.png");
        }
        public void MinimizeMsLeave(object sender, EventArgs e)
        {
            btnMinimize.Image = Image.FromFile(btnPath + "minimize_icon.png");
        }
        public void MenuClick(object sender, EventArgs e)
        {
            if (!menuOpened)
            {
                while(pnlMenu.Width < 151)
                {
                    pnlMenu.Width++;
                }
                
                menuOpened = !menuOpened;
            }
            else
            {
                while (pnlMenu.Width > pnlMenuSize.Width)
                {
                    pnlMenu.Width--;
                }
                
                menuOpened = !menuOpened;
            }
            lblAdd.Visible = !lblAdd.Visible;
            lblRemove.Visible = !lblRemove.Visible;
        }
        public void MenuMsEnter(object sender, EventArgs e)
        {
            btnMenu.Image = Image.FromFile(btnPath + "menu.png");
        }
        public void MenuMsLeave(object sender, EventArgs e)
        {
            btnMenu.Image = Image.FromFile(btnPath + "menu_icon.png");
        }
        public void AddClick(object sender, EventArgs e)
        {
            carDialog = new AddCarDialog();
            carDialog.Owner = this;
            carDialog.Show();
            carDialog.AddCar += CarDialogAddEvent;
            CarEvents += carDialog.SelectedCarHandler;
        }
        public void AddMsEnter(object sender, EventArgs e)
        {
            btnAdd.Image = Image.FromFile(btnPath + "add.png");
            lblAdd.ForeColor = Color.FromArgb(255, 110, 110);
        }
        public void AddMsLeave(object sender, EventArgs e)
        {
            btnAdd.Image = Image.FromFile(btnPath + "add_icon.png");
            lblAdd.ForeColor = Color.White;
        }
        public void RemoveClick(object sender, EventArgs e)
        {
            lstBox.Items.Clear();
            lstBox.SelectedIndex = -1;
        }
        public void RemoveMsEnter(object sender, EventArgs e)
        {
            btnRemove.Image = Image.FromFile(btnPath + "remove.png");
            lblRemove.ForeColor = Color.FromArgb(255, 110, 110);
        }
        public void RemoveMsLeave(object sender, EventArgs e)
        {
            btnRemove.Image = Image.FromFile(btnPath + "remove_icon.png");
            lblRemove.ForeColor = Color.White;
        }
        public void LoadClick(object sender, EventArgs e)
        {
            saveLoad.Clear();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "C:\\";
            openFileDialog.Filter = "Xml files (*.xml)|*.xml";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                saveLoad.Load(openFileDialog.OpenFile());
                if (saveLoad.info.cars.Count != 0)
                {
                    foreach (var car in saveLoad.info.cars)
                    {
                        lstBox.Items.Add(car);
                    }
                    saveLoad.Clear();
                }
            }
            openFileDialog.Dispose();
        }
        public void LoadEnter(object sender, EventArgs e)
        {
            btnLoad.Image = Image.FromFile(btnPath + "load.png");
            lblLoad.ForeColor = Color.FromArgb(255, 110, 110);
        }
        public void LoadLeave(object sender, EventArgs e)
        {
            btnLoad.Image = Image.FromFile(btnPath + "load_icon.png");
            lblLoad.ForeColor = Color.White;
        }
        public void SaveClick(object sender, EventArgs e)
        {
            saveLoad.Clear();
            foreach(var car in lstBox.Items)
            {
                saveLoad.info.cars.Add(car as Car);
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Xml files (*.xml)|*.xml";
            saveFileDialog.InitialDirectory = "C:\\";
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                saveLoad.Save(saveFileDialog.OpenFile());
            }
            saveFileDialog.Dispose();
        }
        public void SaveEnter(object sender, EventArgs e)
        {
            btnSave.Image = Image.FromFile(btnPath + "save.png");
            lblSave.ForeColor = Color.FromArgb(255, 110, 110);
        }
        public void SaveLeave(object sender, EventArgs e)
        {
            btnSave.Image = Image.FromFile(btnPath + "save_icon.png");
            lblSave.ForeColor = Color.White;
        }
        #endregion

        #region FormDrag
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern int ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        private void UpPnl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void FormName_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion
    }
}