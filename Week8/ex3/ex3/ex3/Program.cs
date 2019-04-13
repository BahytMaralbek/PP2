using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DelegateSample
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintDelegate printDelegate = new PrintDelegate(Color);
            printDelegate += BW;
            printDelegate += Silk;
            PrintJob printJob = new PrintJob(printDelegate);
            printJob.Print("Hello!");
        }
        static void Color(string msg)
        {
            Console.WriteLine("color:" + msg);
        }
        static void BW(string msg)
        {
            Console.WriteLine("bw:" + msg);
        }
        static void Silk(string msg)
        {
            Console.WriteLine("silk:" + msg);
        }
        delegate void PrintDelegate(string msg);

        class PrintJob
        {
            PrintDelegate printDelegate;
            public PrintJob(PrintDelegate printDelegate)
            {
                this.printDelegate = printDelegate;
            }
            public void Print(string msg)
            {
                Thread.Sleep(2000);
                printDelegate.Invoke(msg);
            }
        }
    }
}
