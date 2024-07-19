using System.Runtime.Loader;
using System.IO;
using System;
using System.Collections.Generic;
using BabyStroller.SDK;

namespace BabyStroller
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var folder = Path.Combine(Environment.CurrentDirectory, "Animals");
            var files = Directory.GetFiles(folder);
            var animalTypes = new List<Type>();
            foreach (var file in files)
            {
                var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(file);
                var types = assembly.GetTypes();
                foreach (var t in types)
                {
                    if(t.GetInterfaces().Contains(typeof(IAnimal)))//判断第三方的内容
                    {
                        var isUnfinished =t.GetCustomAttributes(false).Any(a=>a.GetType()==typeof(UnfinishedAttribute));
                        if(isUnfinished)continue;
                        animalTypes.Add(t);
                    }
                    //if (t.GetMethod("Voice")!=null)
                    //{
                     
                    //    animalTypes.Add(t);
                    //}
                }
            }
            while (true)
            {
                for (int i = 0; i < animalTypes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}.{animalTypes[i].Name}");
                }
                Console.WriteLine("===================");
                Console.WriteLine("请输入你要选择的动物编号:");
                int index =int.Parse(Console.ReadLine());
                if (index >animalTypes.Count || index<1)
                {
                    Console.WriteLine("没有这样的动物。再试一次！");
                     continue;
                }
                Console.WriteLine("请输入次数");
                int times =int.Parse(Console.ReadLine());
                var t=animalTypes[index-1];
                var m = t.GetMethod("Voice");
                var o = Activator.CreateInstance(t);
                //m.Invoke(o,new object[] {times});
                var a = o as IAnimal;//这两句替代了上面这个，因为加入了接口
                a.Voice(times);
            }
        }
        
    }
}
