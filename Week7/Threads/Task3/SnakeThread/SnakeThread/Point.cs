using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeThread
{
    class Point
    {
        int x;
        int y;

        int Filter(int v)
        {
            if (v < 0)
            {
                v = 37;
            }
            else if (v > 37)
            {
                v = 0;
            }
            return v;
        }
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = Filter(value);
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = Filter(value);
            }
        }
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
