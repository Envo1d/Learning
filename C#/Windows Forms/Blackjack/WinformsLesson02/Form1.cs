using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformsLesson02
{
    public partial class Form1 : Form
    {
        string[] files = Directory.GetFiles("Images");
        int cash = 1000;
        private int PlayerCount { get; set; } = 0;
        private int DealerCount { get; set; } = 0;

        Point dealerCardLoc = new Point(12, 37);
        Point playerCardLoc = new Point(12, 448);
        Size cardSize = new Size(78, 110);
        Random rnd = new Random();
        int idx;
        bool playerGetFCard = false;

        public Form1()
        {
            InitializeComponent();

            lblCash.Text = $"CASH: {cash}";
            lblDealer.Text = $"Dealer: {DealerCount}";
            lblPlayer.Text = $"Player: {PlayerCount}";
            Text = "BlackJack";
            boxBet.Text = "";
            btnHit.Enabled = false;
            btnStand.Enabled = false;
        }

        private void CheckCard(bool t = false, bool f = false)
        {
            byte col;
            if (files[idx].Contains("ace") && f == true)
                col = 11;
            else if (files[idx].Contains("ace") && f == false)
                col = 1;
            else if (files[idx].Contains("king") || files[idx].Contains("queen") || files[idx].Contains("jack") || files[idx].Contains("ten"))
                col = 10;
            else if (files[idx].Contains("nine"))
                col = 9;
            else if (files[idx].Contains("eight"))
                col = 8;
            else if (files[idx].Contains("seven")) col = 7;
            else if (files[idx].Contains("six")) col = 6;
            else if (files[idx].Contains("five")) col = 5;
            else if (files[idx].Contains("four")) col = 4;
            else if (files[idx].Contains("three")) col = 3;
            else col = 2;
            if (t)
            {
                PlayerCount += col;
                lblPlayer.Text = $"Player: {PlayerCount}";
            }
            else
            {
                DealerCount += col;
                lblDealer.Text = $"Dealer: {DealerCount}";
            }
        }

        private void CheckPoints(bool end = false)
        {
            if (!end)
            {
                if (PlayerCount > 21)
                {
                    MessageBox.Show("You Lost!", "Lost", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cash -= Convert.ToInt32(boxBet.Text);
                    lblCash.Text = $"CASH: {cash}";
                    ClearTable();
                }
                else if (PlayerCount == 21)
                {
                    MessageBox.Show("You Win!", "Win", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cash += Convert.ToInt32(boxBet.Text) * 2;
                    lblCash.Text = $"CASH: {cash}";
                    ClearTable();
                } 
            }
            else {
            if (DealerCount == 21)
                {
                    MessageBox.Show("You Lost!", "Lost", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cash -= Convert.ToInt32(boxBet.Text);
                    lblCash.Text = $"CASH: {cash}";
                    ClearTable();
                } 
            else if(DealerCount > 21)
                {
                    MessageBox.Show("You Win!", "Win", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cash += Convert.ToInt32(boxBet.Text) * 2;
                    lblCash.Text = $"CASH: {cash}";
                    ClearTable();
                }
            else if (DealerCount > PlayerCount)
                {
                    MessageBox.Show("You Lost!", "Lost", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cash -= Convert.ToInt32(boxBet.Text);
                    lblCash.Text = $"CASH: {cash}";
                    ClearTable();
                }
            else if (DealerCount < PlayerCount)
                {
                    MessageBox.Show("You Win!", "Win", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cash += Convert.ToInt32(boxBet.Text) * 2;
                    lblCash.Text = $"CASH: {cash}";
                    ClearTable();
                }
            else if(DealerCount == PlayerCount)
                {
                    MessageBox.Show("Draw!", "Draw", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblCash.Text = $"CASH: {cash}";
                    ClearTable();
                }
            }
        }

        private void ClearTable()
        {
            dealerCardLoc = new Point(12, 37);
            playerCardLoc = new Point(12, 448);
            playerGetFCard = false;
            DealerCount = 0;
            PlayerCount = 0;
            lblDealer.Text = $"Dealer: {DealerCount}";
            lblPlayer.Text = $"Player: {PlayerCount}";
            btnHit.Enabled = false;
            btnStand.Enabled = false;
            boxBet.Text = "";
            boxBet.Enabled = true;
        Remove:
            foreach (var item in panel1.Controls)
                panel1.Controls.Remove(item as PictureBox);
            if(panel1.Controls.Count > 2) goto Remove;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (boxBet.Text != "")
            {
                PictureBox box = new PictureBox();
                box.Image = Image.FromFile("Images/backside.png");
                box.Location = dealerCardLoc;
                box.Name = "StartCard";
                box.SizeMode = PictureBoxSizeMode.Zoom;
                box.Size = cardSize;
                panel1.Controls.Add(box);

                PictureBox box1 = new PictureBox();
            Get:
                idx = rnd.Next(0, files.Length - 1);
                if (files[idx].Contains("backside.png"))
                    goto Get;
                box1.Image = Image.FromFile(files[idx]);
                box1.Location = new Point((int)(dealerCardLoc.X + cardSize.Width / 1.3), dealerCardLoc.Y);
                box1.SizeMode = PictureBoxSizeMode.Zoom;
                box1.Size = cardSize;
                dealerCardLoc = box1.Location;
                panel1.Controls.Add(box1);
                CheckCard();

                btnHit.Enabled = true;
                boxBet.Enabled = false;
            }
            else MessageBox.Show("Bet not set!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnHit_Click(object sender, EventArgs e)
        {
            PictureBox box = new PictureBox();
        GetC:
            idx = rnd.Next(0, files.Length - 1);
            if (files[idx].Contains("backside.png"))
                goto GetC;
            box.Image = Image.FromFile(files[idx]);
            if(playerGetFCard)
                box.Location = new Point((int)(playerCardLoc.X + cardSize.Width / 1.3), playerCardLoc.Y);
            else box.Location = playerCardLoc;
            box.SizeMode = PictureBoxSizeMode.Zoom;
            box.Size = cardSize;
            panel1.Controls.Add(box);
            playerCardLoc = box.Location;
            if (playerGetFCard == false)
                CheckCard(true, true);
            else
                CheckCard(true);
            playerGetFCard = true;
            btnStand.Enabled = true;
            CheckPoints();
        }

        private void btnStand_Click(object sender, EventArgs e)
        {
            btnStand.Enabled = false;

            if (DealerCount < PlayerCount)
            {
                PictureBox box = new PictureBox();
            Get2:
                idx = rnd.Next(0, files.Length - 1);
                if (files[idx].Contains("backside.png"))
                    goto Get2;
                box.Image = Image.FromFile(files[idx]);
                box.Location = new Point((int)(dealerCardLoc.X + cardSize.Width / 1.3), dealerCardLoc.Y);
                box.SizeMode = PictureBoxSizeMode.Zoom;
                box.Size = cardSize;
                panel1.Controls.Add(box);
                CheckCard();
            }

            dealerCardLoc = new Point(12, 37);

            foreach (var item in panel1.Controls)
                if (item is PictureBox && (item as PictureBox).Name == "StartCard")
                    panel1.Controls.Remove(item as PictureBox);

            PictureBox box1 = new PictureBox();
        Get1:
            idx = rnd.Next(0, files.Length - 1);
            if (files[idx].Contains("backside.png"))
                goto Get1;
            box1.Image = Image.FromFile(files[idx]);
            box1.Location = dealerCardLoc;
            box1.Name = "StartCard";
            box1.SizeMode = PictureBoxSizeMode.Zoom;
            box1.Size = cardSize;
            panel1.Controls.Add(box1);

            CheckCard();

            CheckPoints(true);
        }
    }
}
