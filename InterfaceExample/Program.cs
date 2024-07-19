using System;
using System.Collections;

namespace InterfaceExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new PhoneUser(new nuojiyaPhone());
            user.UsePhone();
        }      
    }
    class PhoneUser//使用者的功能
    {
        private IPhone _phone;
        public PhoneUser(IPhone phone)
        {
            _phone = phone;
        }
        public void UsePhone()
        {
            _phone.Dail();
            _phone.PickUp();
            _phone.Send();
            _phone.Receive();
        }
    }
    interface IPhone//接口
    {
        void Dail();
        void PickUp();
        void Send();
        void Receive();
    }
    class ailixinPhone : IPhone
    {
        public void Dail()
        {
            Console.WriteLine("ailixin is Dail");
        }

        public void PickUp()
        {
            Console.WriteLine("ailixin is PickUp");
        }

        public void Receive()
        {
            Console.WriteLine("ailixin is Receive");
        }

        public void Send()
        {
            Console.WriteLine("ailixin is Send");
        }
    }//爱立信手机

    class nuojiyaPhone : IPhone
    {
        public void Dail()
        {
            Console.WriteLine("nuojiya is Dail");
        }

        public void PickUp()
        {
            Console.WriteLine("nuojiya is PickUp");
        }

        public void Receive()
        {
            Console.WriteLine("nuojiya is Receive");
        }

        public void Send()
        {
            Console.WriteLine("nuojiya is Send");
        }
    }//诺基亚手机
}
