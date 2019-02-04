using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            string s = sr.ReadToEnd();
            for(int i = 0; i < s.Length; i++)
            {
                for(int j=s.Length-1;j>=i;)
            }
           
        }
    }
}
