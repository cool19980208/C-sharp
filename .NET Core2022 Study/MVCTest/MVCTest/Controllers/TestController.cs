using Microsoft.AspNetCore.Mvc;
using MVCTest.Models;

namespace MVCTest.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Demo1()//Action方法:操作方法
        {
            Person model = new Person("Cool2", true, new DateTime(1998, 8, 8));
            Test("hello");
            return View(model);
        }
        public void Test(string Name)
        {
            Console.WriteLine(  "hello");
        }
    }
}
