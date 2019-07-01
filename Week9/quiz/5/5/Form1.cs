using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5
{
    public partial class Form1 : Form
    {
        Point p1 = new Point(200, 140);
        Point p2 = new Point(200, 100);
        int d = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.PerformStep();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 1;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.Green, 2), p1, new Point(p2.X,p2.Y));
        }
    }
}
