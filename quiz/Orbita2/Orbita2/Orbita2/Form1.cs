using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orbita2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void RCircle(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Red, 3);
            Pen pen2 = new Pen(Color.Blue, 3);
            Pen pen3 = new Pen(Color.Pink, 3);
            SolidBrush sd = new SolidBrush(Color.White);
            for (int i = 0; i >= 0; i += 5)
            {
                this.DoubleBuffered = true;
                Thread.Sleep(100);
                e.Graphics.FillRectangle(sd, 0, 0, 600, 600);
                e.Graphics.DrawArc(pen, new Rectangle(75, 75, 125, 125), i, 16);
                e.Graphics.DrawArc(pen2, new Rectangle(75, 75, 125, 125), 15 + i, 345);
                e.Graphics.DrawArc(pen3, new Rectangle(45, 45, 95, 95), i, 345);
                e.Graphics.DrawArc(new Pen(Color.Green,3), new Rectangle(15, 15, 25, 25), i, 345);


                double x1 = 138;
                double phi = 180 * i / 1000 / Math.PI;
                double y1 = 138;
                double r = 50;
                double xa = x1 + r * Math.Cos(phi);
                double ya = y1 + r * Math.Sin(phi);

                double x2 = 150;
                double y2 = 150;
                double r2 = 30;
                double xa2 = x2 + r2 * Math.Cos(phi);
                double ya2 = y2 + r2 * Math.Sin(phi);

                double x3 = 170;
                double y3 = 170;
                double r3 = 10;
                double xa3 = x3 + r3 * Math.Cos(phi);
                double ya3 = y3 + r3 * Math.Sin(phi);
                e.Graphics.DrawEllipse(pen, (float)xa - 25, (float)ya - 25, 50, 50);
                e.Graphics.DrawEllipse(pen2, (float)xa2 - 15, (float)ya2 - 15, 30, 30);
                e.Graphics.DrawEllipse(pen3, (float)xa3 - 5, (float)ya3 - 5, 10, 10);
            }

        }
    }
}
