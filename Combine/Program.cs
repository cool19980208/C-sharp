using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Combine.Models;

namespace Combine
{
    class Program
    {
        static void Main(string[] args)
        {
            SchoolEntities1 dbContext = new SchoolEntities1();
            var allFullNames = dbContext.Students.Select(P => P.Sname + "" + P.Sno).ToList();
            foreach (var FN in allFullNames)
            {
                Console.WriteLine(FN);
            }

        }
    }
}
