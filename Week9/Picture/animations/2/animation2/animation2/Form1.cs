using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace animation2
{
    public partial class Form1 : Form
    {
        Point point = new Point(00, 100);
        Point point1 = new Point(20, 70);
        Point point2 = new Point(10, 145);
        Point point4 = new Point(70, 145);
        Point point5 = new Point(0, 160);
        Point point6 = new Point(0, 0);
        public Form1()
        {
            InitializeComponent();
        }

        private void paint(object sender, PaintEventArgs e)
        {

            e.Graphics.FillRectangle(new SolidBrush(Color.Yellow), new Rectangle(point6, new Size(20000, 50000)));
            e.Graphics.FillRectangle(new SolidBrush(Color.Gray), new Rectangle(point5, new Size(20000, 50)));
            e.Graphics.FillRectangle(new SolidBrush(Color.Black), new Rectangle(point, new Size(100, 50)));
            e.Graphics.FillRectangle(new SolidBrush(Color.Blue), new Rectangle(point1, new Size(50, 35)));
            e.Graphics.FillEllipse(new SolidBrush(Color.Black), new Rectangle(point2, new Size(20, 20)));
            e.Graphics.FillEllipse(new SolidBrush(Color.Black), new Rectangle(point4, new Size(20, 20)));

        }
        private void button2_Click(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            timer3.Enabled = true;
            timer1.Enabled = false;
            timer3.Interval = 1;

        }
        private void button3_Click(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            timer3.Enabled = false;
            timer1.Enabled = true;
            timer1.Interval = 1;
        }


        private void timer3_Tick(object sender, EventArgs e)
        {
            point.X = point.X - 2;
            point1.X = point1.X - 2;
            point2.X = point2.X - 2;
            point4.X = point4.X - 2;
            pictureBox1.Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            point.X = point.X;
            point1.X = point1.X;
            point2.X = point2.X;
            point4.X = point4.X;
            pictureBox1.Refresh();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            timer2.Enabled = true;
            timer3.Enabled = false;
            timer1.Enabled = false;
            timer2.Interval = 1;
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            point.X = point.X + 2;
            point1.X = point1.X + 2;
            point2.X = point2.X + 2;
            point4.X = point4.X + 2;
            pictureBox1.Refresh();
        }


    }
}
