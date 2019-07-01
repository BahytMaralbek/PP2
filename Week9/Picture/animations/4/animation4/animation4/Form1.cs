using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace animation4
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        Point point = new Point(1,1);
        Size size = new Size(20, 20);
        public Form1()
        {
            InitializeComponent();
            Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            pictureBox1.Image = bitmap;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer2.Start();
            timer2.Interval = 1;
            timer2.Tick += timer2_Tick;
        }
        

        private void timer2_Tick(object sender, EventArgs e)
        {
            if(pictureBox1.Width - point.X == size.Width && point.Y!= pictureBox1.Height-20)
            {
                point.Y++;
                pictureBox1.Refresh();
                
            }
            else if (point.Y==pictureBox1.Height-20 && point.X!=1)
            {
                point.X--;
                pictureBox1.Refresh();
    
            }
            else if (point.X == 1 && point.Y >1)
            {
                point.Y--;
                pictureBox1.Refresh();
             
            }
            else
            {
                point.X++;
                pictureBox1.Refresh();
             
            }
        }
        private void paint(object sender, PaintEventArgs e)
        {
            graphics.DrawRectangle(new Pen(Color.Pink,3),new Rectangle(point,size));
        }
    }
}
