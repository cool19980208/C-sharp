using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methodlianxi
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator c = new Calculator();
            double x = c.GetConeVolume(3, 6);
            Console.WriteLine(x);


            //Calculator1 d = new Calculator1();
            //double v = d.GetAy(3, 6);
            //Console.WriteLine(v);
        }
    }
    class Calculator
    {
        public double Getyuan(double r)//圆面积
        {
            return Math.PI * r * r; //Math.PI 是 π
        }
        public double GetCylinderVolume(double r, double h)//圆柱面积
        {
            double Cv = Getyuan(r);
            return Cv * h;
        }
        public double GetConeVolume(double r, double h)//圆锥面积
        {
            double v = GetCylinderVolume(r, h);
            return v / 3;
        }
    }

    //class Calculator1
    //{
    //    public double GetAe(double r)
    //    {
    //        return Math.PI * r * r;
    //    }
    //    public double GetAr(double r, double h)
    //    {
    //        return GetAe(r) * h;
    //    }
    //    public double GetAy(double r, double h)
    //    {
    //        return GetAr(r, h) / 3;
    //    }
    //}






























}












