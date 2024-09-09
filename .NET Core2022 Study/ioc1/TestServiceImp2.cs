using System;

public class TestServiceImp2 : ITestService, IDisposable//实现类
{
    public string Name { get; set; }

    public void Dispose()
    {
        Console.WriteLine("Disposable......");
    }

    public void SayHi()
    {
        Console.WriteLine($"Hi,I'm {Name}");
    }

}