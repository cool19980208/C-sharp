using System;
using System.Collections.Generic;
using System.Linq;

namespace 揭秘LINQ方法的背后
{
    class Program
    {
        static void Main(string[] args)
        {
            // 使用Where扩展方法对数组进行过滤，筛选出所有大于40的元素
            // Where方法接受一个lambda表达式作为参数，该lambda表达式定义了过滤条件
            // 在这个例子中，条件是元素a的值大于40
            // 最终，result变量将包含所有满足条件的元素，即大于40的元素
            int[] arrays = { 60, 25, 55, 80, 40, 30, 50, 90, 70, 77, 76, 66, 88 };
            // IEnumerable<int> result = arrays.Where(a => a > 40);//Where方法是扩展方法，using System.Linq
            var result = MyWhere2(arrays, a => a > 40);
            foreach (int i in result)
            {
                Console.WriteLine(i);
            }
        }
        static IEnumerable<int> MyWhere(IEnumerable<int> items,Func<int,bool> f)
        {
            List<int> result = new List<int>();
            foreach(int i in items)
            {
                if (f(i)==true)
                {
                    result.Add(i);
                }
            }
            return result;
        }
        static IEnumerable<int> MyWhere2(IEnumerable<int> items, Func<int, bool> f)
        {
            foreach (int i in items)
            {
                if (f(i) == true)
                {
                    yield return i;
                }
            }
        }
    }
}
