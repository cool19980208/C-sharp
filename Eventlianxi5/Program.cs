using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Eventlianxi5
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();//事件的拥有者
            Waiter waiter = new Waiter();//事件的响应者
            customer.Order += waiter.Action;//事件成员   订阅事件
            customer.Action();
            customer.PayTheBill();

        }
    }

    //传递事件信息的  事件的名字+EventArgs  自然派生于EventArgs
    public class OrderEventArgs : EventArgs
    {
        public string DishName { get; set; }
        public string Size { get; set; }
    }

    //public delegate void OrderEventHandler(Customer customer, OrderEventArgs e);  //事件的委托类型  自己定义的事件委托类型
    public class Customer//顾客
    {
        public event EventHandler Order;//简略声明事件  event是声明事件的，而不是修饰符   EventHandler是微软自带的通用声明事件使用的类型
        //注释的为声明事件
        //private OrderEventHandler orderEventHandler;
        //public event OrderEventHandler Order//事件---点单  
        //{
        //    add//添加事件处理器
        //    {
        //        this.orderEventHandler += value;
        //    }
        //    remove//移除事件处理器
        //    { 
        //        this.orderEventHandler -= value;
        //    }
        //}
        public double Bill { get; set; }
        public void PayTheBill()
        {
            Console.WriteLine("我Cool支付了${0}", this.Bill);
        }

        public void Walkln()
        {
            Console.WriteLine("走进餐厅");
        }
        public void SitDown()
        {
            Console.WriteLine("坐下");
        }
        public void Think()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("我想想{0}", i);
                Thread.Sleep(1000);
            }
            this.OnOrder("满汉全席", "large");
        }
        protected void OnOrder(string dishName,string size)
        {
            if (this.Order != null)//判断有没有人来订阅事件，如果没人来订阅，就是null，就会报错，所以需要判断是不是为空
            {
            OrderEventArgs e = new OrderEventArgs();
            e.DishName = dishName;
            e.Size = size ;
            this.Order.Invoke(this, e);

        }
        }
        public void Action()
        {
            Console.ReadLine();
            this.Walkln();
            this.SitDown();
            this.Think();
        }
    }
    public class Waiter//服务生
    {
        public void Action(object sender, EventArgs e)//事件处理器
        {
            Customer customer = sender as Customer;//转换
            OrderEventArgs orderlnfo = e as OrderEventArgs;//转换
            Console.WriteLine("我点了{0}", orderlnfo.DishName);
            double price = 10;//正常份
            switch (orderlnfo.Size)
            {
                case "small"://小份
                    price = price * 0.5;
                    break;
                case "large"://大份
                    price = price * 1.5;
                    break;
                default:
                    break;
            }
            customer.Bill += price;
        }

    }
}
