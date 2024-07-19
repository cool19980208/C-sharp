using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mylib1
{
  public class Vehicle
    {
        protected int _rpm;// 变量名字 前面带_ ，一般都是用于实例字段并且是私有的情况下  车的转速
        private int _fuel;//油
       
        public void Refuel()//加油
        {
            _fuel = 100;
        }


        protected void Burn(int fuel)//烧油过程   protected一般用于方法
        {
            _fuel -= fuel;
        }

        public void Accelerate()
        {
            Burn(1);//烧一格油
            _rpm += 1000;
        }
        public int Speed { get { return _rpm / 100; } }//车根据转速去算多少迈
    }

    public class Car:Vehicle
    {
        public void TurboAccelerate()
        {
            Burn(2);
            _rpm += 3000;
        }
    }
}
