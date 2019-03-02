using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
namespace Task1
{
    class CompNum
    {
        public int a
        {
            get;
            set;
        }
        public int b
        {
            get;
            set;
        }
        public CompNum() { }
        public void Show()
        {
            Console.WriteLine(string.Format("{0} + {1}i", a, b));
        }
    }
    class Program
    { 
        static void Serialize()
        {
            CompNum cn = new CompNum()
            {
                a = 10,
                b = 7
            };
            XmlSerializer xml = new XmlSerializer(typeof(CompNum));
            using(FileStream fs = new FileStream("Baha.xml", FileMode.Create, FileAccess.Write))
            {
                xml.Serialize(fs, cn);
            }
        }
        static void Deserialize()
        {
            XmlSerializer xml = new XmlSerializer(typeof(CompNum));
            using(FileStream fs = new FileStream("Baha.xml", FileMode.Open, FileAccess.Read))
            {
                CompNum cn = xml.Deserialize(fs) as CompNum;
                cn.Show();
            }
        }
        static void Main(string[] args)
        {
            Serialize();
            Deserialize();
        }
    }
}
