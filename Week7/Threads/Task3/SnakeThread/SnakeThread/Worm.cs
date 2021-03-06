﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace SnakeThread
{
    class Worm:GameObject
    {
        public enum Direction
        {
            NONE,
            UP,
            DOWN,
            LEFT,
            RIGHT
        }
        public Direction direction;
        public Worm(char sign) : base(sign)
        {
            body.Add(new Point(15, 15));
            direction = Direction.NONE;
        }

        public void Move(int dx, int dy)
        {
            Clear();

            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i].X = body[i - 1].X;
                body[i].Y = body[i - 1].Y;
            }

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

        public void Eat(List<Point> body)
        {
            this.body.Add(new Point(body[0].X, body[0].Y));
        }

        public override void Draw()
        {
            base.Draw();
            Thread.Sleep(150);
        }
    }
}
