using Microsoft.EntityFrameworkCore;
using System;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;

namespace 多对多
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //插入
            /*Student s1 = new Student { Name = "Tom" };
            Student s2 = new Student { Name = "Zack" };
            Student s3 = new Student { Name = "Zane" };
            Student s5 = new Student { Name = "Tim" };
            Student s6 = new Student { Name = "Lucy" };

            Teacher t1 = new Teacher { Name = "杨中科" };
            Teacher t2 = new Teacher { Name = "秦始皇" };
            Teacher t3 = new Teacher { Name = "李世民" };
            t1.Students.Add(s1);
            t1.Students.Add(s3);
            t1.Students.Add(s5);
            t2.Students.Add(s2);
            t2.Students.Add(s6);
            t3.Students.Add(s1);
            t3.Students.Add(s2);
            t3.Students.Add(s6);*/
            using (MyDbContext ctx=new MyDbContext())
            {
/*                ctx.AddRange(t1, t2, t3);//把多个对象批量加入上下文
                ctx.AddRange(s1, s2, s3,s5,s6);
                await ctx.SaveChangesAsync();*/
                foreach (var t in ctx.Teachers.Include(t=>t.Students))
                {
                    Console.WriteLine($"老师{t.Name}");
                    foreach (var s in t.Students)
                    {
                        Console.WriteLine($"---{s.Name}");
                    }
                }
            }
           

        }
    }
}
