using BabyStroller.SDK;

namespace Animals.lib2
{
    public class dog: IAnimal
    {
        public void Voice(int times)
        {
            for (int i = 0; i < times; i++)
            {
                Console.WriteLine("woof!");
            }
        }

    }
}
