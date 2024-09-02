using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ扩展方法1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> list = new List<Employee>();
            list.Add(new Employee { Id = 1, Name = "jerry", Age = 28, Gender = true, Salary = 5000 });
            list.Add(new Employee { Id = 2, Name = "jim", Age = 33, Gender = true, Salary = 3000 });
            list.Add(new Employee { Id = 3, Name = "lily", Age = 35, Gender = false, Salary = 9000 });
            list.Add(new Employee { Id = 4, Name = "lucy", Age = 16, Gender = false, Salary = 2000 });
            list.Add(new Employee { Id = 5, Name = "kimi", Age = 25, Gender = true, Salary = 1000 });
            list.Add(new Employee { Id = 6, Name = "nancy", Age = 35, Gender = false, Salary = 8000 });
            list.Add(new Employee { Id = 7, Name = "zack", Age = 35, Gender = true, Salary = 8500 });
            list.Add(new Employee { Id = 8, Name = "jack", Age = 33, Gender = true, Salary = 8000 });
            /*var items = list.Where(e=>e.Age>25);
            foreach(var i in items)
            {
                Console.WriteLine(i);
            }

            list.Where(e => e.Age > 30 && e.Salary > 5000).Count();

            Console.WriteLine(list.Count(e => e.Age > 30&&e.Salary>5000));
            Console.WriteLine(list.Any());//比Count()实现效率高
            Console.WriteLine(list.Any(e => e.Age > 30 && e.Salary > 30000));*/
            /* Employee e1 = list.Single(e => e.Name == "jim");
             Employee e2 = list.Where(e => e.Name == "jim").Single();*/

            /*Employee e1 = list.SingleOrDefault(e => e.Name == "jim");
            Employee e2 = list.Where(e => e.Age == 33).SingleOrDefault();*/

            /* Employee e1 = list.First(e => e.Name == "jim");
             Employee e2 = list.Where(e => e.Age == 35).First();


             Employee e3 = list.FirstOrDefault(e => e.Name == "jim");
             Employee e4 = list.Where(e => e.Age == 33).FirstOrDefault();
             Console.WriteLine(e1);
             Console.WriteLine(e2);*/

            /* var e1 = list.OrderBy(e => e.Age);//正序
             var e2 = list.OrderByDescending(e => e.Age);//倒序
             foreach ( var e in e2)
             {
                 Console.WriteLine(e);
             }*/

            /* //特殊案例：按照最后一个字符排序；用Guid或者随机数进行随机排序
             var e1 = list.OrderBy(e => e.Name[e.Name.Length-1]);//取名字最后一个字母进行排序
             var e2 = list.OrderBy(e => Guid.NewGuid());//Guid 随机数算法
             Random rand = new Random();
             var e3 = list.OrderBy(e => rand.Next()); //随机数
             foreach (var e in e3)
             {
                 Console.WriteLine(e);
             }*/
            /*int[] nums = new int[] { 3, 6, 9, 111, 56, 2, 7, 3, 10 };
            var nums2 = nums.OrderBy(i => i);
            foreach (var e in nums2)
            {
                Console.WriteLine(e);
            }*/

            //案例：优先按照Age排序，如果Age相同再按照Salary排序
            /* var e1 = list.OrderBy(e => e.Age).ThenBy(e=>e.Salary);//正序
             var e2 = list.OrderByDescending(e => e.Age).ThenByDescending(e => e.Salary);//倒序
             foreach (var e in e2)
             {
                 Console.WriteLine(e);
             }*/
            //案例：获取从第2条开始获取3条数据
            var e1 = list.Skip(1).Take(3);
            foreach (var e in e1)
            {
                Console.WriteLine(e);
            }
        }
    }
}
