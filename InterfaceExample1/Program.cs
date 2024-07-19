using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExample1
{
    class Program
    {
        static void Main(string[] args)
        {
            var deskfan = new DeskFan(new PowerSupply());
            Console.WriteLine(deskfan.Work());
        }
    }

    public interface IPowerSupply
    {
        int GetPower();
    }
    public class PowerSupply : IPowerSupply//电源
    {
        public int GetPower() //获取电源的电压
        {
            return 199;
        }
    }
    public class DeskFan  //风扇
    {
        private IPowerSupply _powerSupply;
        public DeskFan(IPowerSupply powerSupply)
        {
            _powerSupply = powerSupply;
        }

        public string Work()
        {
            int power = _powerSupply.GetPower();
            if (power <= 0)
            {
                return "电压过低";
            }
            else if (power < 100)
            {
                return "电压低";
            }
            else if (power < 200)
            {
                return "电压正常";
            }
            else
            {
                return "电压过大";
            }

        }
    }


}
