using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task2
{
    class Program
    { 
        private static int [] F1(string s)
        {
            string[] arr = s.Split();
            int[] arr2 = new int[arr.Length];
            for(int i = 0; i < arr.Length; i++)
            {
                arr2[i] = int.Parse(arr[i]);
            }
            return arr2;
        }
        private static bool F2(int n)
        {
            for(int i = 2; i * i <= n; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"C:\Users\User\PP2\Week2\Task2\In.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string s = sr.ReadToEnd();
            int [] arr = F1(s);
            sr.Close();
            fs.Close();
            FileStream fs2 = new FileStream(@"C:\Users\User\PP2\Week2\Task2\Out.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs2);
            for(int j = 0; j < arr.Length; j++)
            {
                if (F2(arr[j]) == true && arr[j] != 1)
                {
                    sw.Write(arr[j] + " ");
                }
            }
            sw.Close();
            fs2.Close();
        }
    }
}
