using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Task2
{
    class Program
    {
        class MyThread
        {
            public MyThread(string name)
            {
                threadfield.Name = name;
            }
            public void startThread()
            {
                threadfield.Start();
            }
            Thread threadfield = new Thread(start);
            public static void start()
            {
                for (int i= 1;i<= 4; i++)
                {
                    Console.WriteLine(Thread.CurrentThread.Name + ":" + i);
                }
                Console.WriteLine(Thread.CurrentThread.Name + " stop");
            }
        }
        static void Main(string[] args)
        {
            MyThread t1 = new MyThread("Thread 1");
            MyThread t2 = new MyThread("Thread 2");
            MyThread t3 = new MyThread("Thread 3");
            

            t1.startThread();
            t2.startThread();
            t3.startThread();
           
        }
    }
}
