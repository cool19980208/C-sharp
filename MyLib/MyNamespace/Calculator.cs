using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.MyNamespace
{
  internal  class Calculator//默认是internal，代表只能在本项目中去使用。不能跨项目使用
    {
        public double Add(double a,double b)
        {
            return a + b;
        }
    }
}
