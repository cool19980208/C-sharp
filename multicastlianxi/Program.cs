using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;//多线程

namespace multicastlianxi
{
    class Program
    {
        static void Main(string[] args)
        {
            Student stu1 = new Student() { ID = 1, PenColor = ConsoleColor.Yellow };
            Student stu2 = new Student() { ID = 2, PenColor = ConsoleColor.Green };
            Student stu3 = new Student() { ID = 3, PenColor = ConsoleColor.Red };

            Thread task1 = new Thread(new ThreadStart(stu1.DoHomework));
            Thread task2 = new Thread(new ThreadStart(stu2.DoHomework));
            Thread task3 = new Thread(new ThreadStart(stu3.DoHomework));

            task1.Start();
            task2.Start();
            task3.Start();





            for (int i = 0; i < 10; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Main thread {0}.", i);
                Thread.Sleep(1000);
            }

        }
    }
    class Student
    {
        public int ID { get; set; }
        public ConsoleColor PenColor { get; set; }//输出笔的颜色

        public void DoHomework()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.ForegroundColor = this.PenColor;
                Console.WriteLine("Student {0} doing homework {1} hour(s)", this.ID,i);
                Thread.Sleep(1000);//1000毫秒=1s
            }
        }
    }
}
