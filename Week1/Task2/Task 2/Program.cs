using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class Student                   //создал класс Student,и ввел туда имя,ID,и год обучения
    {
        public string name;
        public string ID;
        public int year;
        public Student(string name,string ID)   //создаю конструктор Student который содержит имя и ID
        {
            this.name = name;
            this.ID = ID;
        }
        //cоздал функцию которая выводит все элементы класса Student c увеличенным годом обучения на 1
        public void printInfo() {       
            Console.WriteLine("Name:"+this.name+Environment.NewLine+"ID:"+this.ID+ Environment.NewLine + "year of study:"+(this.year+1));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //создал экземпляр s типа Student 
            Student s = new Student("Bakyt", "18BD110884");
            s.year = 1;
            s.printInfo();
        }
    }
}
