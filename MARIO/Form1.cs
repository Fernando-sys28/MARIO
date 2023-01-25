using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MARIO
{
    public partial class Form1 : Form
    {
        //Global variables
        int motion1 = 2;
        int motion2 = 4;
        int motion3 = 6;

        int width = 688;

        int l1_X1, l1_X2, l2_X1,l2_X2, l3_X1, l3_X2;

        Bitmap layer1, layer2, layer3;

        bool right, up, hold = true;

        static Graphics g;

        public Form1()
        {
            InitializeComponent();

            layer1 = Resource1.L1;
            layer2 = Resource1.L2;
            layer3 = Resource1.L3;
            
            l1_X1= l2_X1 = l3_X1= 0;
            l1_X2 = l2_X2 = l3_X2 = width;

            player.Image = Resource1.Kirbyh;
        }

        private void BackgroundMove()
        {
            if (l1_X1 < -width) { l1_X1 = width - motion1; }
            l1_X1 -= motion1; l1_X2 -= motion1;
            if (l1_X2 < -width) { l1_X2 = width - motion1; }

            if (l2_X1 < -width) { l2_X1 = width - motion2; }
            l2_X1 -= motion2; l2_X2 -= motion2;
            if (l2_X2 < -width) { l2_X2 = width - motion2; }

            if (l3_X1 < -width) { l3_X1 = width - motion3; }
            l3_X1-= motion3; l3_X2 -= motion3;
            if (l3_X2 < -width) { l3_X2 = width - motion3; }

            Invalidate();
        }

       
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(right)
                BackgroundMove();

            else if (up)
                BackgroundMove();

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Right & hold)
            {
                right= true;
                hold = false;
                player.Image = Resource1.kirbyrun;
            }

            if (e.KeyData == Keys.Up & hold)
            {
                up = true;
                hold = false;
                if (up == true)
                {
                    player.Location = new Point(200, 80);
                    player.Image = Resource1.kirbypink;
                }
           
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Right & !hold)
            {
                right= false;
                hold = true;
                player.Image = Resource1.Kirbyh;

            }

            if (e.KeyData == Keys.Up & !hold)
            {
                up = false;
                hold = true;
                if (up == false)
                {
                    player.Location = new Point(200,120);
                    player.Image = Resource1.Kirbyh;
                }

            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            g.DrawImage(layer1, l1_X1, 0, layer1.Width, this.Height - 50);
            g.DrawImage(layer1, l1_X2, 0, layer1.Width, this.Height - 50);

            g.DrawImage(layer2, l2_X1, 50, layer1.Width, this.Height - 150);
            g.DrawImage(layer2, l2_X2, 50, layer1.Width, this.Height - 150);

            g.DrawImage(layer3, l3_X1, 0, layer1.Width, this.Height - 50);
            g.DrawImage(layer3, l3_X2, 0, layer1.Width, this.Height - 50);
        }
    }
}
