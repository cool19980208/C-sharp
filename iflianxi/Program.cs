using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iflianxi
{
    class Program
    {
        static void Main(string[] args)
        {
            //新需求  80---100 打印A,60---79 打印B,40---59 打印C,0---39 打印D.
            int score = 100;
            if (score>=80 && score<=100) //else if 是逐级筛选的过程，所以有些内容可以省略
            {
                Console.WriteLine("A");
            }
            else if (score >= 60)//&& score <= 79  可以省略
            {
                Console.WriteLine("B");
            }
            else if (score >= 40)//&& score <= 59  可以省略
            {
                Console.WriteLine("C");
            }
            else if(score >= 0)//&& score <= 39 可以省略  
            {
                Console.WriteLine("D");
            }
            else
            {
                Console.WriteLine("输入错误");
            }

        }
    }
}
