using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        //cоздал функцию которая будет выводить элементы массива по два раза
        static void F1(int n)
        {
            for(int i = 0; i < 2; i++)
            {
                Console.Write(n + " ");
            }
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());//ввожу размер массива
            int [] arr = new int[n];              //создаю интовый массив с размером н
            string s = Console.ReadLine();        //через стринг s ввожу элементы массива 
            string[] ss = s.Split();              //создаю стринговый массив в который добавляю элементы разделенные пробелом
            for(int i = 0; i < ss.Length; i++)
            {
                arr[i] = int.Parse(ss[i]);        //пробегаюсь по стринговому массиву и все его элементы превращаю в числа
            }                                     //и добавляю их в интовый массив
            for(int i = 0; i < n; i++)
            {
                F1(arr[i]);                       //через функция вывожу все элементы интового массива 
            }
        }
    }
}
