using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace traffic_light
{

    class Program
    {
        static int ColorId = 0;
        static int colorNum
        {
            get
            {
                return ColorId;
            }
            set
            {
                if (value > 2)
                {
                    ColorId = 0;
                }
                else
                {
                    ColorId = value;
                }
            }
        }

        static void changeColor()
        {
            Console.Clear();
            for (int i = 0; i < 20; i++)
            {
                if (i < 6)
                {
                    if (colorNum == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    for (int j = 0; j < 18; j++)
                    {
                        Console.Write(" ");
                    }
                }
                else if (i > 6 && i < 14)
                {
                    if (colorNum == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    for (int j = 0; j < 18; j++)
                    {
                        Console.Write(" ");
                    }
                }
                else if (i > 14)
                {
                    if (colorNum == 2)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    for (int j = 0; j < 18; j++)
                    {
                        Console.Write(" ");
                    }
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    for (int j = 0; j < 18; j++)
                    {
                        Console.Write(" ");
                    }
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
            colorNum++;
        }

        static void Main()
        {
            Console.SetWindowSize(18, 20);
            Console.SetBufferSize(18, 20);
            Console.CursorVisible = false;
            while (true)
            {
                changeColor();
                Thread.Sleep(2000);
            }
        }
    }
}  

    

