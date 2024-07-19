using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegatelianxi
{
    
    class Program
    {

        static void Main(string[] args)
        {
            IProductFactory pizzaFactory = new PizzaFactory();   //实例化
            IProductFactory toycarFactory = new ToyCarFactory();
            WrapFactory wrapFactory = new WrapFactory();            //实例化

                

            Box box1 = wrapFactory.WrapProduct(pizzaFactory);
            Box box2 = wrapFactory.WrapProduct(toycarFactory);

            Console.WriteLine(box1.Product.Name);
            Console.WriteLine(box2.Product.Name);
        }
    }

    interface IProductFactory//定义接口  接口取代委托
    {
        Product Make();
    }
    class PizzaFactory : IProductFactory
    {
        public Product Make()
        {
            Product product = new Product();
            product.Name = "Pizza";
            return product;
        }
    }
    class ToyCarFactory : IProductFactory
    {
        public Product Make()
        {
            Product product = new Product();
            product.Name = "Toy Car";
            return product;
        }
    }

    class Product  //产品
    {
        public string Name { get; set; }
       
    }
    class Box   //包装箱
    {
        public Product Product { get; set; }
    }

    class WrapFactory  //把产品 包装成盒子 交给用户 ---包装车间
    {
        public Box WrapProduct(IProductFactory productFactory)  //模版方法的返回值是Box类型，接受一个委托类型的参数---用Func委托  有返回值，返回Product类型的对象
        {
            Box box = new Box();
            Product product = productFactory.Make();
            box.Product = product;
            return box;
        }
    }
}
