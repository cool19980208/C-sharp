using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forlianxi
{
    class Program
    {
        static void Main(string[] args)
        {
            //int x = 0;
            //do//do的计数使用实例，太麻烦
            //{
            //    Console.WriteLine("Hello,World!");
            //    x++;
            //} while (x<10);

            //for (int i = 0; i < 10; i++) //1.先执行 int i = 0；从0开始计数  ； 2.在对比是不是满足 i<10 的条件，满足就执行块里面的语句，。 3.执行完快之后，在后置自增 i++。
            //                             //一次过后，一直重复 2 和 3 的步骤，直到不满足 2的条件就结束。
            //{
            //    Console.WriteLine("Hello,World!");
            //}

            //如果for里面的三个值都为空，可以正常生成吗？如果可以，那结果是什么？
            //1.可以正常生成  2.结果是无限循环。 就好似 while一样
            //while (true)
            //{

            //}

            //简单算法---9 9乘法表    用第一个循环去带入第二个循环，排序后就是 1x1   2x1......  通过二次循环去达到目的
            /*
            for (int a = 1; a <= 9; a++)
            {
                for (int b = 1; b <= a; b++)
                {
                    Console.Write("{0}x{1}={2}\t",a,b,a*b);//Console.WriteLine 一行打印一次  ；Console.Write 不换行   用\t(制表位) 去分割
                }
                Console.WriteLine(); //一轮打印一行
            }
            */
            int a = 10;
            int b = a + 5;
            int c = b - 6;
            Console.WriteLine(a, b, c);
        }
    }
}
