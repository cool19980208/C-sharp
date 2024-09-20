using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace NewTest
{
    class Program
    {
        static void Main(string[] args)
        {
           using(TestCoolContext ctx =new TestCoolContext())
            {
                /* Console.WriteLine(ctx.TPersons.Count());
                 TPerson p1 = new TPerson();
                 p1.Name = "Zane";
                 p1.BithDay = new DateTime(1998, 8, 8);
                 ctx.TPersons.Add(p1);
                 ctx.SaveChanges();*/
                // var presons = ctx.TPersons.Where(b => IsOK(b.Name)); 第一个的例子，无法被编译成SQL语句
                //var presons = ctx.TPersons.Where(b => b.Name.PadLeft(5)=="Zane");//第二个的例子，无法被编译成SQL语句
                IQueryable<TPerson> presons = ctx.TPersons.Where(b => b.Name.ToLower() == "Zane" && b.BithDay == DateTime.Now);
                string sql = presons.ToQueryString();// Microsoft.EntityFrameworkCore;
                Console.WriteLine("这就是我想要的:"+sql);
                /*foreach (var p in presons)
                {
                    Console.WriteLine(p.Name);
                }*/

            }
        }
        private static bool IsOK(string s)
        {
            return s.Contains("Z");
        }
    }
}
