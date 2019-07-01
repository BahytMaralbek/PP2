using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BonusProblem
{
    public partial class Form1 : Form
    {
        int dx = 0, dy = 0;
        
        public Form1()
        {
            InitializeComponent();
            timer1.Tick += timer1_Tick;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            BackColor = Color.Red;
            SolidBrush brush = new SolidBrush(Color.Gray);
            e.Graphics.FillRectangle(brush,new Rectangle(50+dx,600+dy,40,40));
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ModifierKeys == Keys.Up)
            {
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dx++;
            dy++;
            Refresh();
        }
    }
}
