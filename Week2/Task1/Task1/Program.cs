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
            FileStream fs = new FileStream(@"C:\Users\User\PP2\Week2\Task1\Task1\Input.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string s = sr.ReadToEnd();
            sr.Close();
            fs.Close();
            FileStream fs2 = new FileStream(@"C:\Users\User\PP2\Week2\Task1\Task1\Messi.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs2);
            int a = 0;
            for (int i = 0; i < s.Length/2; i++)
            {
                if(s[i] == s[s.Length - 1 - i])
                {
                    a++;
                }
            }
            if(a == s.Length / 2)
            {
                sw.Write("Yes");
            }
            else
            {
                sw.Write("No");
            }
            sw.Close();
            fs2.Close();
        }
    }
}
