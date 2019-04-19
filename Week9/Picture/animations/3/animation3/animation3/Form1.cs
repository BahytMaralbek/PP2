using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace animation3
{
    public partial class Form1 : Form
    {
        Point point1 = new Point(50, 50);
        Size size = new Size(200, 200);
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = false;
            timer1.Interval = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = true;
            timer2.Interval = 1;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush solidBrush = new SolidBrush(Color.Purple);
            e.Graphics.FillEllipse(solidBrush, new Rectangle(point1,size));

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            point1.X += 2;
            Refresh();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            point1.X -= 2;
            Refresh();
        }
    }
}
