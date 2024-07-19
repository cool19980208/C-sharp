using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codelianxi
{
    class Program
    {
        static void Main(string[] args)
        {
            //while语句练习
            //int score = 0;
            //bool canContinue = true;
            //while (canContinue)
            //{
            //    Console.WriteLine("请输入第一个数字");
            //    string st1 = Console.ReadLine();
            //    int x = int.Parse(st1);//用int.Parse 将字符串转换为整数类型int

            //    Console.WriteLine("请输入第一个数字");
            //    string st2 = Console.ReadLine();
            //    int y = int.Parse(st2);//用int.Parse 将字符串转换为整数类型int

            //    int sum = x + y;
            //    if (sum == 100)
            //    {
            //        score++;
            //        Console.WriteLine("你做对了！{0}+{1}={2}",x,y,sum);
            //    }
            //    else
            //    {
            //        Console.WriteLine("你做错了！{0}+{1}={2}",x,y,sum);
            //        canContinue = false;
            //    }
            //}
            //Console.WriteLine("你赢了{0}个回合",score);
            //Console.WriteLine("结束");

            //do语句练习
            int score = 0;
            int sum = 0;
            do
            {
                Console.WriteLine("请输入第一个数字");
                string st1 = Console.ReadLine();
                if (st1.ToLower()=="end")
                {
                    break;
                }
                int x = 0;
                try
                {
                    x = int.Parse(st1);//用int.Parse 将字符串转换为整数类型int
                }
                catch (Exception)
                {

                    Console.WriteLine("输入格式不正确，请重新开始输入");
                    continue;
                }
                   
                Console.WriteLine("请输入第一个数字");
                string st2 = Console.ReadLine();
                if (st2.ToLower() == "end")
                {
                    break;
                }
                int y = 0;
                try
                {
                    y= int.Parse(st2);//用int.Parse 将字符串转换为整数类型int
                }
                catch (Exception)
                {

                    Console.WriteLine("输入格式不正确，请重新开始输入");
                    continue;
                }
                    
                sum = x + y;
                if (sum == 100)
                {
                    score++;
                    Console.WriteLine("你做对了！{0}+{1}={2}", x, y, sum);
                }
                else
                {
                    Console.WriteLine("你做错了！{0}+{1}={2}", x, y, sum);
                }
            } while (sum==100);
            Console.WriteLine("你赢了{0}个回合", score);
            Console.WriteLine("结束");
        }
    }
}
