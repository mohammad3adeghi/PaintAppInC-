using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint_App
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen p;
        int font;

        int x = -1;
        int y = -1;
        bool moving = false;

        public Form1()
        {
            InitializeComponent();
            g = panel2.CreateGraphics();
            p = new Pen(Color.Black, font);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            p.Color = ((PictureBox)sender).BackColor;
            defColor.BackColor = ((PictureBox)sender).BackColor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                p.Color = colorDialog1.Color;
                defColor.BackColor = colorDialog1.Color;
            }

        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            x = e.X;
            y = e.Y;
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            x = -1;
            y = -1;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if(moving && x != -1 && y != -1)
            {
                g.DrawLine(p, new Point(x, y), e.Location);
                x = e.X;
                y = e.Y;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
        }
    }
}
