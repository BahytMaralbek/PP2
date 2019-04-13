using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex4
{
    class Program
    {
        class NumberInfo
        {
            Delegate Delegate;
            public NumberInfo(Delegate Delegate)
            {
                this.Delegate = Delegate;
            }
            public void PrintAll(int n)
            {
                Delegate.Invoke(n);
            }
        }
        static void Main(string[] args)
        {
            Delegate d = new Delegate(PrintNum);
            d += PrintFactorial;
            d += PrintSum;
            NumberInfo numberInfo = new NumberInfo(d);
            numberInfo.PrintAll(5);
        }
        static void PrintFactorial(int n)
        {
            int ans = 1;
            for(int i = 2; i <= n; i++)
            {
                ans *= i;
            }
            Console.WriteLine("Factorial:" + ans);
        }
        static void PrintNum(int n)
        {
            Console.WriteLine("Number:" + n);
        }
        static void PrintSum(int n)
        {
            int sum = 0;
            for(int i = 1; i <= n; i++)
            {
                sum += i;
            }
            Console.WriteLine("Sum:" + sum);
        }
        delegate void Delegate(int n);
    }
}
