using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Balloon
{
    public partial class Form1 : Form
    {
        Point p;
        Size size = new Size(40, 40);
        Graphics graphics;
        public Form1()
        {
            InitializeComponent();
            Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            pictureBox1.Image = bitmap;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (p.Y != pictureBox1.Height)
            {
                p.Y = p.Y + 2;
                pictureBox1.Refresh();
            }
            else
            {
                timer1.Stop();
            }
            
        }

      


        private void picturebox1_MouseClick(object sender, MouseEventArgs e)
        {
           
            p = e.Location;
            timer1.Start();
            timer1.Interval = 1;
            timer1.Tick += timer1_Tick;
           
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush solidBrush = new SolidBrush(Color.Blue);
            if (p.X != 0)
            {
                graphics.FillEllipse(solidBrush, new Rectangle(p, size));
            }
        }

        
    }
}
