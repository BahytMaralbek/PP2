using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(PrintAbc);
            Thread t2 = new Thread(PrintDef);
            Console.CursorVisible = false;
            t1.Start();
            t2.Start();
            PrintAbc();
            PrintDef();
        }
        
        private static void PrintDef()
        {
            int t11 = 0;
            Console.SetCursorPosition(5, 0);
            while (true)
            {
                Console.SetCursorPosition(5, t11);
                t11++;
                Console.WriteLine("def");
                Thread.Sleep(3000);
            }
        }

        private static void PrintAbc()
        {
            int t22 = 0;
            Console.SetCursorPosition(0, 0);
            while (true)
            {
                Thread.Sleep(2000);
                Console.SetCursorPosition(0, t22);
                t22++;
                Console.WriteLine("abc");
            }
            
        }
    }
}
