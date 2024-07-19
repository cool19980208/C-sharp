using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace propertylianxi
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                Student stu = new Student();
                stu.Age = 15;
                Console.WriteLine(stu.CamWork);//主动调用去计算是否可以工作
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
    }
    class Student
    {
        private int age;

        public int Age//实例属性
        {
            get { return age; }
            set { age = value;
                this.CalculateCanWork();//主动调用
            }
        }
        private bool canWork;

        public bool CamWork
        {
            get { return canWork; }
        }
        private void CalculateCanWork()
        {
            if (this.age>=16)
            {
                this.canWork = true;
            }
            else
            {
                this.canWork = false;
            }
        }



        //private static int amount;//静态属性

        //public static int Amount
        //{
        //    get { return amount; }
        //    set 
        //    {
        //        if (value>=0)
        //        {
        //            amount = value;
        //        }
        //        else
        //        {
        //            throw new Exception("amount不能小于0");
        //        }
        //    }
        //}

        //private int age;//public int Age;   如果是private， age就是小写；如果是public ， Age就是首字母大写

        //public int Age
        //{
        //    get 
        //    { 
        //        return this.age; 
        //    }
        //    set 
        //    {
        //        if (value >= 0 && value <= 120)
        //        {
        //            this.age = value;
        //        }
        //        else
        //        {
        //            throw new Exception("Age value has error");
        //        }
        //    }
        //}

        //public int GetAge()// Get 调取
        //{
        //    return this.age;
        //}
        //public void SetAge(int value)//Set 更新/添加
        //{
        //    if (value >= 0 && value <= 120)
        //    {
        //        this.age = value;
        //    }
        //    else
        //    {
        //        throw new Exception("Age value has error");
        //    }
        //}
    }
}
