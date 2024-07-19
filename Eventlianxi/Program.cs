using System;
using System.Timers;

namespace Eventlianxi
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer();//事件的拥有者
            timer.Interval = 1000;//每隔1秒触发一次
            Boy boy = new Boy();//事件的响应者
            Girl girl = new Girl();
            timer.Elapsed += boy.Action;//+= 是用来订阅事件的，左边是事件（Elapsed），右边是事件处理器（Action）  后面跟事件响应者的事件处理器  
            timer.Elapsed += girl.Action;//事件处理器的名字 建议用 有意义的名字
            timer.Start();
            //一个事件有两个事件处理器的例子
            Console.ReadLine();
        }
    }
    class Boy
    {
        internal void Action(object sender, ElapsedEventArgs e)//事件处理器
        {
            Console.WriteLine("Cool");
        }
    }

    class Girl
    {
        internal void Action(object sender, ElapsedEventArgs e)//事件处理器
        {
            Console.WriteLine("jump");
        }
    }
}
