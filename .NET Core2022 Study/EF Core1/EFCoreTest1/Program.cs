using System;
using System.Linq;

namespace EFCoreTest1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MyDbContext ctx = new MyDbContext())
            {
                var books = ctx.Authors.Where(b => b.BirthDay.Year == 1998).Take(3);

                foreach (var b in books)
                {
                    Console.WriteLine(b.Id);
                }
            }               
        }
    }
}
