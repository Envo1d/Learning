using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsHW4
{
    public partial class AddCarDialog : Form
    {
        public event EventHandler<Car> AddCar;
        public event EventHandler<Car> MainFormEvents;
        private bool isUpdateEvent = false;
        private bool isDeleteEvent = false;
        public Car Car { get; set; }
        public AddCarDialog()
        {
            InitializeComponent();

            btnClose.MouseEnter += CloseEnter;
            btnClose.MouseLeave += CloseLeave;
            btnAddRec.Click += AddClick;
            btnAddRec.MouseEnter += AddEnter;
            btnAddRec.MouseLeave += AddLeave;
            btnDeleteRec.Click += DeleteClick;
            btnDeleteRec.MouseEnter += DeleteEnter;
            btnDeleteRec.MouseLeave += DeleteLeave;
            btnUpdateRec.Click += UpdateClick;
            btnUpdateRec.MouseEnter += UpdateEnter;
            btnUpdateRec.MouseLeave += UpdateLeave;
        }

        private void Clear()
        {
            txtBoxId.Text = null;
            txtBoxModel.Text = null;
            txtBoxPrice.Text = null;
            btnYes.Checked = btnNo.Checked = false;
        }
        public void SelectedCarHandler(object sender, Car c)
        {
            if (c == null) return;
            Car = c;
            txtBoxId.Text = $"{Car.Id}";
            txtBoxModel.Text = $"{Car.Model}";
            txtBoxPrice.Text = $"{Car.Price}";
            if (Car.Sold)
            {
                btnYes.Checked = true;
                btnNo.Checked = false;
            }
            else
            {
                btnNo.Checked = true;
                btnYes.Checked = false;
            }
        }

        #region DragForm

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern int ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        private void DialogName_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void pnlUp_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion

        #region BtnsEvents
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CloseEnter(object sender, EventArgs e)
        {
            btnClose.Image = Image.FromFile("Assets/close.png");
        }
        private void CloseLeave(object sender, EventArgs e)
        {
            btnClose.Image = Image.FromFile("Assets/close_icon.png");
        }
        private void AddClick(object sender, EventArgs e)
        {
            if (txtBoxId.Text == "" || txtBoxModel.Text == "" || txtBoxPrice.Text == "" || (btnYes.Checked == false && btnNo.Checked == false))
                MessageBox.Show("Not all fields are filled", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    Car = new Car
                    {
                        Id = Convert.ToInt32(txtBoxId.Text),
                        Model = txtBoxModel.Text,
                        Price = Convert.ToDecimal(txtBoxPrice.Text),
                        Sold = btnYes.Checked
                    };
                    AddCar?.Invoke(this, Car);
                    Clear();
                }
                catch (Exception msg) { MessageBox.Show(msg.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error); Clear(); }
            }
        }
        private void AddEnter(object sender,EventArgs e)
        {
            btnAddRec.Image = Image.FromFile("Assets/addrec.png");
        }
        private void AddLeave(object sender,EventArgs e)
        {
            btnAddRec.Image = Image.FromFile("Assets/addrec_icon.png");
        }
        private void DeleteClick(object sender, EventArgs e)
        {
            if (txtBoxId.Text == "" || txtBoxModel.Text == "" || txtBoxPrice.Text == "" || (btnYes.Checked == false && btnNo.Checked == false))
                MessageBox.Show("Not all fields are filled", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    Car = new Car
                    {
                        Id = Convert.ToInt32(txtBoxId.Text),
                        Model = txtBoxModel.Text,
                        Price = Convert.ToDecimal(txtBoxPrice.Text),
                        Sold = btnYes.Checked
                    };
                    if (isUpdateEvent)
                    { MainFormEvents -= (Owner as CarCatalogForm).UpdateRecEvent; isUpdateEvent = !isUpdateEvent; }
                    MainFormEvents += (Owner as CarCatalogForm).DeleteRecEvent;
                    MainFormEvents?.Invoke(this, Car);
                    isDeleteEvent = !isDeleteEvent;
                    Clear();
                }
                catch (Exception msg) { MessageBox.Show(msg.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error); Clear(); }
            }
        }
        private void DeleteEnter(object sender, EventArgs e)
        {
            btnDeleteRec.Image = Image.FromFile("Assets/delete.png");
        }
        private void DeleteLeave(object sender, EventArgs e)
        {
            btnDeleteRec.Image = Image.FromFile("Assets/delete_icon.png");
        }
        private void UpdateClick(object sender, EventArgs e)
        {

            if (txtBoxId.Text == "" || txtBoxModel.Text == "" || txtBoxPrice.Text == "" || (btnYes.Checked == false && btnNo.Checked == false))
                MessageBox.Show("Not all fields are filled", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    Car = new Car
                    {
                        Id = Convert.ToInt32(txtBoxId.Text),
                        Model = txtBoxModel.Text,
                        Price = Convert.ToDecimal(txtBoxPrice.Text),
                        Sold = btnYes.Checked
                    };
                    if (isDeleteEvent)
                    { MainFormEvents -= (Owner as CarCatalogForm).DeleteRecEvent; isDeleteEvent = !isDeleteEvent; }
                    MainFormEvents += (Owner as CarCatalogForm).UpdateRecEvent;
                    MainFormEvents?.Invoke(this, Car);
                    isUpdateEvent = !isUpdateEvent;
                    Clear();
                }
                catch (Exception msg) { MessageBox.Show(msg.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error); Clear(); }
            }
        }
        private void UpdateEnter(object sender, EventArgs e)
        {
            btnUpdateRec.Image = Image.FromFile("Assets/update.png");
        }
        private void UpdateLeave(object sender, EventArgs e)
        {
            btnUpdateRec.Image = Image.FromFile("Assets/update_icon.png");
        }
        #endregion
    }
}
