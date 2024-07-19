using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZhanHeTui
{
    class Program
    {
        static  void Main(string[] args)//unsafe= 承认自己在写不安全的代码，int* 这是指针的用法
        {
            unsafe//为什么还会红呢？
            {
                int* p = stackalloc int[9999999];
            }
               
        }
    }
}
