using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
namespace Salary
{
    class Employee
    {
        public Employee() { }
        private string name;
        private string iD;
        private int salary;

         public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
         public string ID
        {
            get
            {
                return iD;
            }
            set
            {
                iD = value;
            }
        }
         public int Salary
        {
            get
            {
                return salary;
            }
            set
            {
                salary = 50000;
                salary = value;
            }
         }
    }
    class Program
    {
        public static void Serialize(Employee e)
        {
            string s = string.Format("{0}.xml", e.Name);
            string path = @"C:\Users\User\PP2\Week7\Task6";
            string dir = Path.Combine(path, s);
            FileStream fs;
            XmlSerializer xs = new XmlSerializer(typeof(Employee));
            fs = new FileStream(dir, FileMode.Create, FileAccess.Write);
            xs.Serialize(fs, e);
            fs.Close();
        }
        static void Deserialize()
        {
            Employee e = null;
            XmlSerializer xs = new XmlSerializer(typeof(Employee));
            string s = string.Format("{0}.xml", e.Name);
            string path = @"C:\Users\User\PP2\Week7\Task6";
            string dir = Path.Combine(path, s);
            FileStream fs = new FileStream(dir, FileMode.Open, FileAccess.Read);
            e = xs.Deserialize(fs) as Employee;
            fs.Close();
            Print(e);
        }
        static void Print(Employee e)
        {
            Console.WriteLine(e.Name + " " + e.ID + " " + e.Salary);
        }
        static void Main(string[] args)
        {
            Employee e = new Employee();
            e.Name = "Baha";
            e.ID = "18BD110884";
            e.Salary = 10;
            Serialize(e);
        }
        
    }
}
