using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    class Program
    {
        public static int dx, dy;
        public static int x, y;
        public static string s = "DVD";
        public static ConsoleColor[] colors = new ConsoleColor[] { ConsoleColor.Red, ConsoleColor.Cyan, ConsoleColor.Green, ConsoleColor.Magenta, ConsoleColor.White };
        public static Random r = new Random();
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            dx = dy = 1;
            x = r.Next(0, Console.WindowWidth);
            y = r.Next(0, Console.WindowHeight);
            int c = r.Next(0, colors.Length - 1);
            Console.ForegroundColor = colors[c];
            while (true)
            {
                Move();
                Thread.Sleep(200);
            }
        }

        public static void Move()
        {
            Console.Clear();
            int c = r.Next(0, colors.Length - 1);
            x += dx;
            if (x < 0)
            {
                Console.ForegroundColor = colors[c];
                x = 0;
                dx = 1;
            }
            else if (x > Console.WindowWidth - s.Length)
            {
                Console.ForegroundColor = colors[c];
                x = Console.WindowWidth - s.Length - 1;
                dx = -1;
            }
            y += dy;
            if (y < 0)
            {
                Console.ForegroundColor = colors[c];
                y = 0;
                dy = 1;
            }
            else if (y > Console.WindowHeight)
            {
                Console.ForegroundColor = colors[c];
                y = Console.WindowHeight - 1;
                dy = -1;
            }
            Console.SetCursorPosition(x, y);
            Console.Write(s);
        }
    }
}