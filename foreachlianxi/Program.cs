using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace foreachlianxi
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArray = new int[] { 1, 2, 3, 4, 5, 6 };//数组
            foreach (var item in intArray)
            {
                Console.WriteLine(item);
            }


            //List<int> intlist = new List<int>() { 1, 2, 3, 4, 5 };
            //IEnumerator enumerator = intlist.GetEnumerator();//禅宗的故事 指月
            //while (enumerator.MoveNext())
            //{
            //    Console.WriteLine(enumerator.Current);
            //}

            //enumerator.Reset();//初始化次数，重头再来
            //while (enumerator.MoveNext())//为什么只打印了一遍，而不是俩遍呢？  因为在第一遍执行的时候我指月，已经到了最后一个；
            //{                            //所以第二遍还是什么都没打印出来，重置一下次数，就可重新从头开始指月
            //    Console.WriteLine(enumerator.Current);
            //}
        }
    }
}
