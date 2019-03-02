using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
namespace Task2
{
    public class Mark
    {
        public int point = 100;
        public int getLetter
        {
            get
            {
                return point;
            }
            set
            {
                if (value > 100)
                    point = 100;
                else if (value < 0)
                    point = 0;
                else
                    point = value;
            }
        }
        public Mark() { }
        public Mark(int point2)
        {
            point = point2;
        }
        public override string ToString()
        {
            string s = "F";
            if (point >= 95)
            {
                s = "A";
            }
            else if (point >= 90 && point <= 94)
            {
                s = "A-";
            }
            else if (point >= 85 && point <= 89)
            {
                s = "B+";
            }
            else if (point >= 80 && point <= 84)
            {
                s = "B";
            }
            else if (point >= 75 && point <= 79)
            {
                s = "B-";
            }
            else if (point >= 70 && point <= 74)
            {
                s = "C+";
            }
            else if (point >= 65 && point <= 69)
            {
                s = "C";
            }
            else if (point >= 60 && point <= 64)
            {
                s = "C-";
            }
            else if (point >= 55 && point <= 59)
            {
                s = "D+";
            }
            else if (point >= 50 && point <= 54)
            {
                s = "D";
            }
            return s;
        }
    }
    class Program
    { 
        public static void Serialize()
        {
            List<Mark> marks = new List<Mark>();
            using(FileStream fs = new FileStream("Marks.xml", FileMode.Create, FileAccess.Write))
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<Mark>));
                xs.Serialize(fs, marks);
            }
        }
        public static void Deserialize()
        {
            using(FileStream fs = new FileStream("Marks.xml", FileMode.Open, FileAccess.Read))
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<Mark>));
                List<Mark> marks = xs.Deserialize(fs) as List<Mark>;
                foreach(var x in marks)
                {
                    Console.WriteLine("Mark:{0}", x.ToString());
                }
            }
            
        }
        static void Main(string[] args)
        {
            //Serialize();
            Deserialize();
        }
    }
}
