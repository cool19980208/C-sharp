using System;

namespace LINQTest1
{
    class Program
    {
        static void Main(string[] args)
        {
            D1 d = F1;//指向方法F1
            d();//运行方法
            Func<int,int,int> x = F2;//有返回值的
            Console.WriteLine(x(6,8));
            Action d1 = F1;//没返回值的
            d1();
        }
        static void F1()
        {
            Console.WriteLine("我是F1");
        }
        static int F2(int i,int j)
        {
            return i + j;
        }
    }
    delegate void D1(); //委托和类一级
}
