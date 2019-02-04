﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        public static bool isPrime (int n)    //создаю функцию которая определяет простое число или нет
        {
            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0)
                    return false;
            }return true;
        }
        static void Main(string[] args)
        {
            string ss = Console.ReadLine();
            string s = Console.ReadLine();    //создаю один стринг чтобы вводить размер массива и второй чтобы
            int n = int.Parse(ss);
            string[] a = s.Split();                                 //вводить его значения потом создаю массив и добавляю 
            for(int i = 0; i < a.Length ; i++)
            {
                int b = int.Parse(a[i]);                            //каждый элемент превращаю в числа и вывожу через пробел
                if (isPrime(b) == true && b!=1)
                {
                    Console.Write(a[i] + " ");
                }
            }
        }
    }
}
