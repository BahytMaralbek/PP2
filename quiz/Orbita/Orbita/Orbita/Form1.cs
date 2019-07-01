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

namespace Orbita
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Thread th;
        Graphics g;
        Graphics fG;
        Bitmap btm;
        bool drawing = true;
        SolidBrush pl1 = new SolidBrush(Color.Red);
        SolidBrush pl2 = new SolidBrush(Color.White);
        SolidBrush pl3 = new SolidBrush(Color.Blue);
        private void Form1_Load(object sender, EventArgs e)
        {
            btm = new Bitmap(1000, 1000);
            g = Graphics.FromImage(btm);
            fG = CreateGraphics();
            th = new Thread(Draw);
            th.IsBackground = true;
            th.Start();
        }

        private void Draw()
        {
            float angle = 0.0f;
            PointF org = new PointF(250, 250);
            float rad1 = 250;
            
            Pen pen = new Pen(Brushes.Azure, 0.0f);
            RectangleF area1 = new RectangleF(30, 30, 500, 500);
            RectangleF area2 = new RectangleF(30, 50, 500, 500);
            RectangleF area3 = new RectangleF(30, 80, 500, 500);
            RectangleF circle1 = new RectangleF(0, 0, 50, 50);
            RectangleF circle2 = new RectangleF(20, 20, 30, 30);
            RectangleF circle3 = new RectangleF(20, 30, 30, 30);
            PointF loc = PointF.Empty;
            PointF img = new PointF(20, 20);
            fG.Clear(Color.Black);
            while (drawing)
            {
                g.Clear(Color.Black);
                g.DrawEllipse(pen, area1);
                g.DrawEllipse(pen, area2);
                g.DrawEllipse(pen, area3);
                SolidBrush solidBrush = new SolidBrush(Color.Yellow);
                g.FillEllipse(solidBrush, new Rectangle(135, 150, 300, 300));
                loc = CirclePoint(rad1, angle, org);
                circle1.X = loc.X - (circle1.Width / 2) + area1.X;
                circle1.Y = loc.Y - (circle1.Height / 2) + area1.Y;
                circle2.X = loc.X - (circle2.Width / 2) + area2.X;
                circle2.Y = loc.Y - (circle2.Height / 2) + area2.Y;
                circle3.X = loc.X - (circle3.Width / 2) + area3.X;
                circle3.Y = loc.Y - (circle3.Height / 2) + area3.Y;
                g.FillEllipse(pl1, circle1);
                g.FillEllipse(pl2, circle2);
                g.FillEllipse(pl3, circle3);
                fG.DrawImage(btm, img);
                if (angle < 360)
                {
                    angle += 0.5f;
                }
                else
                {
                    angle = 0;
                }
            }
            throw new NotImplementedException();
        }

        private PointF CirclePoint(float rad, float angle, PointF org)
        {
            float x = (float)(rad * Math.Cos(angle * Math.PI / 180F)) + org.X;
            float y = (float)(rad * Math.Sin(angle * Math.PI / 180F)) + org.Y;
            return new PointF(x, y);
        }
    }
}