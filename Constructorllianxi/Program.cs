using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructorllianxi
{
    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student();
            Console.WriteLine(s.ID);
            Console.WriteLine(s.Name);
            Console.WriteLine("============================");
            Student s2 = new Student(66,"OK,You Good");
            Console.WriteLine(s2.ID);
            Console.WriteLine(s2.Name);

        }
    }

    class Student
    {
        public Student(int initID,string initName)
        {
            this.ID = initID;
            this.Name = initName;
        }
        
        public Student()//ctor然后TAB快速写出构造器
        {
            this.ID = 6;
            this.Name = "Yes,Ok";
        }
        public int ID;
        public String Name;
    }
}
