using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Task1
{
    class Program
    {
        public static void Startmethod()
        {
            for(int i = 0; i < 3; i++)
            {
                Console.WriteLine("Thread" + Thread.CurrentThread.Name + " " + (i+1));
            }
        }
        static void Main(string[] args)
        {
            Thread []threads = new Thread[3];
            for(int i = 0; i < 3; i++)
            {
                threads[i] = new Thread(Startmethod);
                threads[i].Name = (i+1).ToString();
                threads[i].Start();
                
            }
            
        }
    }
}
