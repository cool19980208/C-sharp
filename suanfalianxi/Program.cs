using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suanfalianxi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator c = new Calculator();//如果想访问其他类的方法，需要实例化
            //int x = c.Add(3, 9);
            //Console.WriteLine(x);//输出Add的返回值
            //string str = c.GetToday();
            //Console.WriteLine(str);//输出Today的日期
            //c.PrintSum(6, 6);//返回Sum的结果
            //int sum = c.PrintToX(100);
            //Console.WriteLine(sum);
            Console.WriteLine(c.HanoiSum(64));

        }
    }
    class Calculator
    {
        //  public int Add(int a, int b) //public 是公有，让其他的类可以访问到，如果不加，其他类(class)访问不到
        //  {
        //      int result = a + b;
        //      return result;
        //  }
        // public string GetToday()
        //  {
        //      int day = DateTime.Now.Day;
        //      return day.ToString();
        //  }
        //public void PrintSum(int a,int b )
        //  {
        //      int result = a + b;
        //      Console.WriteLine(result);
        //  }

        //public void PrintTo1(int a)//循环算法，从高到低循环
        //{
        //   for (int i = a; i > 0; i--)
        //    {
        //        Console.WriteLine(i);
        //    }
        //}
        //public void PrintTo1(int i) //递归算法  一层嵌一层，然后一层一层递归的去输出
        //{
        //    if (i == 1)
        //    {
        //        Console.WriteLine(i);
        //    }
        //    else
        //    {
        //        Console.WriteLine(i);
        //        PrintTo1(i - 1);
        //    }

        //}

        //题目：计算1到100的和
        //循环 占用内存小
        //public void PrintToX(int x)
        //{
        //    int sum = 0;
        //    //运行过程。 int i = 1  从i = 1开始循环；
        //    //i< x+1 是条件，每次都需要检查条件，因为当前i是1，所以1小于 x+1，运算完后；
        //    //进行i++，自动在i的基础上增加1。直到条件到100不小于 x+1，那个这个循环就跳出了
        //    for (int i = 1; i < x + 1; i++)
        //    {
        //        sum = sum + i; //sum += i

        //    }
        //    Console.WriteLine(sum);
        //}

        //递归 占用内存大
        //public int PrintToX(int x)
        //{

        //    if (x==1)
        //    {
        //        return 1;
        //    }
        //    else
        //    {
        //        int result = x + PrintToX(x - 1);
        //        return result;
        //    }

        //}
        //public int PrintToX(int x)//数学算式
        //{
        //    return (1 + x) * x / 2;
        //}

        //汉诺塔 递归
        public ulong HanoiSum(int count)
        {
            ulong only = 1;//第一步：把第一个盘子挪走；第二步：然后把最后一盘子挪过去；第三步：再把其他的盘子在挪上面即可
            if (count ==1)
            {
                return only;
            }
            ulong notOnly = only + HanoiSum(count - 1)*2;//HanoiSum(count - 1) + only + HanoiSum(count - 1); 启动显示-1。说明数量太大，当前数据类型不支持，所以把int换成了ulong。
            return notOnly;
        }

    }

}
