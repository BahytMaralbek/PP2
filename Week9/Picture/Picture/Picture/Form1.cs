using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Picture
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        public Form1()
        {
            InitializeComponent();
            Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);
            pictureBox1.Image = bitmap;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Point[] points1 = 
            {
                new Point(100, 100), new Point(105, 110), new Point(115, 110), new Point(110, 120),
                new Point(115, 130), new Point(105, 130),new Point(100,140),new Point(95,130),
                new Point(85,130),new Point(90,120),new Point(85,110),new Point(95,110)
            };
            Pen penCircles = new Pen(Color.White, 2);
            Point[] points2 =
            {
                new Point(150,250),new Point(155,260),new Point(165,260),new Point(160,270),
                new Point(165,280),new Point(155,280),new Point(150,290),new Point(145,280),
                new Point(135,280),new Point(140,270),new Point(135,260),new Point(145,260)
            };
            Point[] points3 =
            {
                new Point(440,70),new Point(445,80),new Point(455,80),new Point(450,90),
                new Point(455,100),new Point(440,70),new Point(440,70),new Point(440,70),
                new Point(440,70),new Point(440,70),new Point(440,70),new Point(440,70),
            }
            SolidBrush solidWhite = new SolidBrush(Color.White);
            SolidBrush solidRed = new SolidBrush(Color.Red);
            graphics.FillEllipse(solidWhite, 20, 40, 21, 21);
            graphics.FillEllipse(solidWhite, 25, 250, 21, 21);
            graphics.FillEllipse(solidWhite, 200, 30, 21, 21);
            graphics.FillEllipse(solidWhite, 350, 50, 21, 21);
            graphics.FillEllipse(solidWhite, 200, 220, 21, 21);
            graphics.FillEllipse(solidWhite, 500, 100, 21, 21);
            graphics.FillEllipse(solidWhite, 430, 170, 21, 21);
            graphics.FillEllipse(solidWhite, 490, 300, 21, 21);
            graphics.FillPolygon(solidRed, points1);
            graphics.FillPolygon(solidRed, points2);
        }
    }
}
