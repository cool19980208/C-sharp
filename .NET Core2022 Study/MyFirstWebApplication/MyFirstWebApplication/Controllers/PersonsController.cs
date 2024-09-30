using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstWebApplication.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/[controller]/[action]")]//[controller]代表控制器；[action]代表操作方法
    [ApiController]
    public class PersonsController : ControllerBase
    {
        [HttpGet]
        public Person[] GetAll()
        {
            return new Person[] { new Person(1, "Cool", 18), new Person(2, "Zane", 26) };
        }
        [HttpGet]
        public Person? GetById(long id)
        {
            if (id == 1)
            {
                return new Person(1, "Cool", 18);
            }
            else if (id == 2)
            {
                return new Person(2, "Zane", 26);
            }
            else
            {
                return null;
            }
        }
        [HttpPost]
        public string AddNew(Person r)
        {
            return "OK";
        }
    }
}
