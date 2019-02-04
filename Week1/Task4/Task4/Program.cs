using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());  //ввожу размер двойного массива, создаю квадратную матрицу(массив двойной)
            int[,] arr = new int[n, n];
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if(j < i || i == j)             //пробегаюсь по массиву,если j меньше или равен i,то вывожу звездочку
                    {                               //и получаю нужный мне рисунок
                        Console.Write("[*]");
                    }
                }Console.Write(Environment.NewLine);
            }
        }
    }
}
