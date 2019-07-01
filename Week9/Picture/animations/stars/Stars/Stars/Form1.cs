using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stars
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        Random random = new Random();
        int x, y;
        public Form1()
        {
            InitializeComponent();
            Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            pictureBox1.Image = bitmap;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Start();
            timer1.Tick += timer1_Tick;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush solidBrush = new SolidBrush(Color.Yellow);
            SolidBrush solidBrush2 = new SolidBrush(Color.Black);
            graphics.FillRectangle(solidBrush, new Rectangle(x, y, 20, 20));
            graphics.FillRectangle(solidBrush2, new Rectangle(x, y, 20, 20));
            graphics.FillRectangle(solidBrush, new Rectangle(x, y, 20, 20));
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            x = random.Next(1, pictureBox1.Width);
            y = random.Next(1, pictureBox1.Height);
            pictureBox1.Refresh();
        }
    }
}
