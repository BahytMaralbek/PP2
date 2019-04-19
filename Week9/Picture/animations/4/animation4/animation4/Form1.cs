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
        public enum Direction
        {
            right,left,down,up
        }
        Direction direction = Direction.right;
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
            timer2.Enabled = true;
            timer2.Interval = 1;
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            CheckDirection();
            switch (direction)
            {
                case Direction.right:
                    point.X = point.X + 1;
                    pictureBox1.Refresh();
                    break;
                case Direction.left:
                    point.X = point.X - 1;
                    pictureBox1.Refresh();
                    break;
                case Direction.down:
                    point.Y = point.Y + 1;
                    pictureBox1.Refresh();
                    break;
                case Direction.up:
                    point.Y = point.Y;
                    pictureBox1.Refresh();
                    break;
                default:
                    break;
            }
        }
        private void paint(object sender, PaintEventArgs e)
        {
            SolidBrush solidBrush = new SolidBrush(Color.Pink);
            graphics.FillRectangle(solidBrush, new Rectangle(point, size));
        }

        public void CheckDirection()
        {
            if(point.X == pictureBox1.Width - 1)
            {
                direction = Direction.down;
            }
            else if (point.Y == pictureBox1.Height - 1)
            {
                direction = Direction.left;
            }
            else if(point.X == 1)
            {
                direction = Direction.up;
            }
            else if (point.Y == 2)
            {
                direction = Direction.right;
            }
        }
    }
}
