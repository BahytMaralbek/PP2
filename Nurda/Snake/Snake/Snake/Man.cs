using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace MazeGame
{
    class Man : GameObject
    {
        public Man(char sign) : base(sign)
        {
            body.Add(new Point(15, 15));
        }

        public void Move(int dx, int dy)
        {
            Clear();
            body[0].X += dx;
            body[0].Y += dy;
        }

        public bool CheckIntersection(List<Point> points)
        {
            bool res = false;

            foreach (Point p in points)
            {
                if (p == body[0]) continue;
                if (p.X == body[0].X && p.Y == body[0].Y)
                {
                    res = true;
                    break;
                }
            }
            return res;
        }  
    }
}
