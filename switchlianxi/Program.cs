using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace switchlianxi
{
    class Program
    {
        static void Main(string[] args)
        {
            Level myLevel = Level.High;
            switch (myLevel) //输入值之后，按 回车键，下面会自动写出情况
            {
                case Level.High:
                    Console.WriteLine("High");
                    break;
                case Level.Mid:
                    Console.WriteLine("Mid");
                    break;
                case Level.Low:
                    Console.WriteLine("Low");
                    break;
                default:
                    Console.WriteLine("输入错误");
                    break;
            }
            //int score = 100;
            //switch (score/10)
            //{
            //    case 10: // 因为101 整除后也是10，所以给10单独设置一下  case后面只能跟常量，变量不行
            //        if (score == 100)
            //        {
            //            goto case 8;
            //        }
            //        else
            //        {
            //            goto case default;
            //        }
            //    case 8:
            //    case 9:
            //        Console.WriteLine("A");
            //        break;
            //    case 7:
            //    case 6:
            //        Console.WriteLine("B");
            //        break;
            //    case 5:
            //    case 4:
            //        Console.WriteLine("C");
            //        break;
            //    case 3:
            //    case 2:
            //    case 1:
            //    case 0:
            //        Console.WriteLine("D");
            //        break;
            //    default:  //default 相当于 if else  当中的 else 一样
            //        Console.WriteLine("错误");
            //        break;
            //}

        }
        enum Level 
        {
            High,
            Mid,
            Low
        }
    }
}
