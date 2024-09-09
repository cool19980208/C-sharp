using System;

public class TestServiceImpl : ITestService//实现类
{
    public string Name { get; set; }

    /*public void Dispose()
    {
        Console.WriteLine("Disposable......");
    }*/

    public void SayHi()
    {
        Console.WriteLine($"Hi,I'm {Name}");
    }

}