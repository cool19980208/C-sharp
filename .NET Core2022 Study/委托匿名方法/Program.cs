using System;

namespace 委托匿名方法
{
    class Program
    {
        static void Main(string[] args)
        {
            /*//第一阶段
            Action f1 = delegate ()//没有参数和返回值的匿名方法
            {
                Console.WriteLine("cool真帅");
            };

            Action<string, int> f2 = delegate (string i, int j)//没返回值的匿名方法
            {
                 Console.WriteLine($"n={i},j={j}");
             };
            Func<int, int, int> f3 = delegate (int i, int j)//有返回值的匿名方法
            {
                   return i + j;
               };
            f1();
            f2("cool", 18);
            Console.WriteLine(f3(3, 5));*/
            /*//第二阶段
             Action f1 =  () =>{ Console.WriteLine("cool真帅");}; //没有参数和返回值的匿名方法

             Action<string, int> f2 =  ( i,  j) => { Console.WriteLine($"n={i},j={j}");};//没返回值的匿名方法

             Func<int, int, int> f3 =  ( i,  j) => { return i + j;};//有返回值的匿名方法

             f1();
             f2("cool", 18);
             Console.WriteLine(f3(3, 5));*/

            /*//第三阶段
            Action f1 = () => Console.WriteLine("cool真帅"); //没有参数和返回值的匿名方法

            Action<string, int> f2 = ( i,  j) => Console.WriteLine($"n={i},j={j}"); //没返回值的匿名方法

            Func<int, int, int> f3 = (i, j) =>  i + j; //有返回值的匿名方法

            f1();
            f2("cool", 18);
            Console.WriteLine(f3(3, 5));*/

            //第四阶段
            Func<int, bool> f5 = i => i > 5;//反推1

            Func<int, bool> f6 = delegate (int i)
              {
                  return i > 5;
              };
            Console.WriteLine(f5(6));
            Console.WriteLine(f6(6));

            Action<string> f7 = s => Console.WriteLine(s);//反推2
            Action<string> f8 = delegate (string s)
            {
                Console.WriteLine(s);
            };
            f7("帅");
            f8("努力");


        }
    }
}
