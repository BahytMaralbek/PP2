using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace Task1
{
    class SomeClass
    {
        public string name;
        public int num;
        public SomeClass(string name,int num)
        {
            this.name = name;
            this.num = num;
        }
        public SomeClass() { }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Console.Write("How many:");
            int n = int.Parse(Console.ReadLine());
            XmlSerializer xml = new XmlSerializer(typeof(SomeClass));
            FileStream fs;
            for(int i = 0; i < n; i++)
            {
                Console.Write("Name:");
                string nm = Console.ReadLine();
                SomeClass s = new SomeClass(nm, random.Next(1, 100));
                fs = new FileStream(nm+".xml", FileMode.Create, FileAccess.Write);
                xml.Serialize(fs, s);
            }
        }
    }
}
