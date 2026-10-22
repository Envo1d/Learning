using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsHW
{
    struct Coordinates
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    public partial class Form1 : Form
    {
        private Coordinates start;
        private Random rnd = new Random();
        private int lblNum { get; set; } = 1;
        public Form1()
        {
            InitializeComponent();
            this.Text = "Labels";
            this.MouseClick += Form1MouseClick;
        }

        private void Form1MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.Text = "Labels";
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                start.X = e.Location.X;
                start.Y = e.Location.Y;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Math.Abs(e.X - start.X) < 10 || Math.Abs(e.Y - start.Y) < 10)
                    MessageBox.Show($"Min size 10 x 10, your size is {Math.Abs(e.X - start.X)} x {Math.Abs(e.Y - start.Y)}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    Label lbl = new Label();

                    if (e.X > start.X && e.Y > start.Y)
                        lbl.Location = new Point(start.X, start.Y);
                    else if (e.X < start.X && e.Y < start.Y)
                        lbl.Location = new Point(e.X, e.Y);
                    else if (e.X > start.X && e.Y < start.Y)
                        lbl.Location = new Point(start.X, e.Y);
                    else lbl.Location = new Point(e.X, start.Y);

                    lbl.BorderStyle = BorderStyle.None;
                    lbl.BackColor = Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
                    lbl.ForeColor = Color.White;
                    lbl.Size = new Size(Math.Abs(e.X - start.X), Math.Abs(e.Y - start.Y));
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.Text = $"{lblNum++}";
                    Controls.Add(lbl);
                    lbl.MouseClick += lblMouseClick;
                }
            }
        }

        private void lblMouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                var lbls = from n in Controls.Cast<Label>() let loc = n.PointToScreen(Point.Empty) where (Cursor.Position.X > loc.X && Cursor.Position.X < loc.X + n.Width && Cursor.Position.Y > loc.Y && Cursor.Position.Y < loc.Y + n.Height) select n;
                var res = (from l in lbls let max = lbls.Max(m => m.Text) where l.Text == max select l).FirstOrDefault();
                this.Text = $"Label №{res.Text}: Area = {res.Size.Width * res.Size.Height}, X = {res.Location.X}, Y = {res.Location.Y}";
            }
        }
    }
}
