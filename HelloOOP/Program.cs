using System;
using Mylib1;

namespace HelloOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            car.TurboAccelerate();
            Console.WriteLine(car.Speed);
            Bus bus = new Bus();
            bus.SlowAccelerate();
            Console.WriteLine(bus.Speed);
            
        }
    }
    class Bus : Vehicle
    {
        public void SlowAccelerate() 
        {
            Burn(1);
            _rpm += 500;
        }
    }

}
