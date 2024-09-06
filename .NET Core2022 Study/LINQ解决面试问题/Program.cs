using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ解决面试问题
{
    class Program
    {
        static void Main(string[] args)
        {
            ////LINQ方法
            //int i = 5;
            //int j = 8;
            //int k = 6;
            //int[] nums = new int[] { i, j, k };
            //int max = nums.Max();
            //Console.WriteLine(max);

            ////常规方法
            //int i = 5;
            //int j = 8;
            //int k = 6;
            //int max = Math.Max(i, Math.Max(j, k));
            //Console.WriteLine(max);

            //案例1
            //有一个用逗号分隔的表示成绩的字符串，如"61,90,100,99,18,22,38,66,80,93,55,50,89"，计算这些成绩的平均值。

            //自己写的，没用LINQ
            string s = "61,90,100,99,18,22,38,66,80,93,55,50,89";
            //double sum = 0;
            // String[] items = s.Split(",");

            // for (int i = 0; i < items.Length; i++)
            // {
            //     sum = sum + double.Parse(items[i]);
            //     if (i == items.Length-1)
            //     {
            //         double CJ = sum / items.Length;
            //         Console.WriteLine(CJ);
            //     }
            // }
            ////展开写
            //String[] items = s.Split(",");
            //IEnumerable<int> nums = items.Select(e => Convert.ToInt32(e));
            //double avg = nums.Average();
            //Console.WriteLine(avg);
            //最简洁的写法
            double avg = s.Split(',').Select(e => Convert.ToInt32(e)).Average();
            Console.WriteLine(avg);
            //案例2
            //统计一个字符串中每个字母出现的频率（忽略大小写），然后按照从高到低的顺序输出出现频率高于2次的单词和其出现的频率。
            string s1 = "a,b,c,w,g,t,k,l,i,u,t,q,a,z,v,A,FG,JF,AD,TRDH,SDFDS,EAREW,SDFFSA,AFDS,N";
            var strs = s1.Where(c => char.IsLetter(c)).Select(c => char.ToLower(c)).GroupBy(c => c)
                .Select(g=>new { g.Key,Count=g.Count()}).OrderByDescending(g=>g.Count).Where(g=>g.Count>2);
            foreach (var item in strs)
            {
                Console.WriteLine(item);
            }
            
           
        }
    }
}
