﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    abstract class GameObject
    {
        public List<Point> body = new List<Point>();
        protected char sign;

        public GameObject(char sign)
        {
            this.sign = sign;
        }
        public virtual void Draw()
        {
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write(sign);
            }
        }
        public virtual void Clear()
        {
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write("  ");
            }
        }
    }
}
