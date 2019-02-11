using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!File.Exists(@"C:\Users\User\PP2\Week2\Task1\Task1\ApituDolb"))
            {
                using(FileStream fs = new FileStream(@"C:\Users\User\PP2\Week2\Task1\Task1\ApituDolb.txt", FileMode.CreateNew, FileAccess.Write))
                {
                    using(StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.Write("Apitu is good boy!");
                    }
                }
            }

            if (!Directory.Exists(@"C:\Users\User\PP2\Week2\Task1\Task1\Shark"))
            {
                Directory.CreateDirectory(@"C:\Users\User\PP2\Week2\Task1\Task1\Shark");
            }

            string P1 = Path.Combine(@"C:\Users\User\PP2\Week2\Task1\Task1", "ApituDolb.txt");
            string P2 = Path.Combine(@"C:\Users\User\PP2\Week2\Task1\Task1\Shark", "ApituDolb.txt");
            
            if (!File.Exists(@"C:\Users\User\PP2\Week2\Task1\Task1\Shark\ApituDolb.txt"))
            {
                File.Copy(P1, P2, true);
            }

            if (File.Exists(@"C:\Users\User\PP2\Week2\Task1\Task1\ApituDolb.txt"))
            {
                File.Delete(@"C:\Users\User\PP2\Week2\Task1\Task1\ApituDolb.txt");
            }
        }
    }
}
