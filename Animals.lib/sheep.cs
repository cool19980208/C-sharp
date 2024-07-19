using BabyStroller.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals.lib
{
    [Unfinished]//特征，代表还没开发完的内容
    public class sheep: IAnimal
    {
        public void Voice(int times)
        {
            for (int i = 0; i < times; i++)
            {
                Console.WriteLine("Baa!");
            }
        }
    }
}
