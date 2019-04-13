using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeThread
{
    class Food:GameObject
    {
        public Food(char sign) : base(sign)
        {
            Generate();
        }
        public void Generate()
        {
            Point p = new Point(10, 35);
            body.Add(p);
        }
        public bool IsGoodPoint(List<Point> a, List<Point> b, Point c)
        {
            bool res = true;
            foreach (Point p in a)
            {
                if (p.X == c.X && p.Y == c.Y)
                {
                    res = false;
                    break;
                }
            }
            foreach (Point p in b)
            {
                if (p.X == c.X && p.Y == c.Y)
                {
                    res = false;
                    break;
                }
            }
            return res;
        }
        public void Generate(List<Point> a, List<Point> b)
        {
            body.Clear();
            Random random = new Random(DateTime.Now.Second);
            Point p = new Point(random.Next(0, 37), random.Next(0, 37));
            while (!IsGoodPoint(a, b, p))
            {
                p = new Point(random.Next(0, 37), random.Next(0, 37));
            }
            body.Add(p);
        }
    }
}
