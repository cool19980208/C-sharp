using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fieldlianxi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Brush.DefaultColor.Red);
            Console.WriteLine(Brush.DefaultColor.Green);
            Console.WriteLine(Brush.DefaultColor.Blue);
        }
    }
    struct Color
    {
        public int Red;
        public int Green;
        public int Blue;
    }
    class Brush
    {
        public static readonly Color DefaultColor;
        static Brush()//静态构造器
        {
            Brush.DefaultColor = new Color() { Red = 0, Green = 0, Blue = 0 }; //与上一种写法一致，
        }
    }
}
 