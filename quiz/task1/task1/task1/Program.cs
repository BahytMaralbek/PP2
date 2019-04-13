using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
namespace task1
{
    class Course
    {
        public Course() { }
        public Course(string title, Teacher teacher)
        {
            this.title = title;
            this.teacher = teacher;
        }
        public string title;
        public Teacher teacher;
    }
    class Teacher
    {
        public string name;
        public string surname;
        public int salary;
        public Teacher() { }
        public Teacher(string name, string surname, int salary)
        {
            this.name = name;
            this.surname = surname;
            this.salary = salary;
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            List<Course> list = new List<Course>();
            Teacher t = new Teacher("Bakyt", "Maralbek", 50000);
            Course c1 = new Course("1", t);
            Course c2 = new Course("2", t);
            list.Add(c1);
            list.Add(c2);
            Ser(list);
        }
        public static void Ser(List<Course> c)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Course>));
            
      
                using (FileStream fs = new FileStream(c + ".xml", FileMode.Create, FileAccess.Write))
                {
                    xs.Serialize(fs, c);
                }
            
            
        }
       /*- public static void Des()
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Course>));
            List<Course> courses = null;
            string path = @"C:\Users\User\PP2\quiz";
            string file = string.Format("{0}.xml", courses);
            string 

                using (FileStream fs = new FileStream(courses + ".xml", FileMode.Open, FileAccess.Read))
                {
                    xs.Deserialize(fs) as Course;
                }
           
        }*/
    }
}

