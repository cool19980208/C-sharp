using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trylianxi
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator cr = new Calculator();
            var x = cr.Add("", "999999999999999999999");
            Console.WriteLine(x);
        }
    }
    class Calculator
    {
        public int Add(string arg1, string arg2)
        {
            int a = 0;
            int b = 0;
            bool hasError = false;
            try
            {
                a = int.Parse(arg1);
                b = int.Parse(arg2);
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine(ane.Message);
                hasError = true;
                //Console.WriteLine("输入的字符串不能为空");
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
                hasError = true;
                //Console.WriteLine("输入内容格式不正确");
            }
            catch (OverflowException oe)
            {
                Console.WriteLine(oe.Message);
                hasError = true;
                //Console.WriteLine("输入的数量太大或太小");
            }
            finally  //不管上面是否异常，都会执行这个语句
            {
                if (hasError)
                {
                    Console.WriteLine("报错了");
                }
                else
                {
                    Console.WriteLine("正常");
                }
            }
            int result = a + b;
            return result;
        }
    }
}
