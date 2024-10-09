using ClassLibrary1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DIWebAPI1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly MyService1 myService1;
        //private readonly TestService testService;
        private readonly Class1 class1;

        public TestController(MyService1 myService1, Class1 class1)
        {
            this.myService1 = myService1;//构造函数
            this.class1 = class1;
        }
        [HttpGet]
        public string Test()
        {
            var names = myService1.GetNames();
            return string.Join(",", names);
        }
        [HttpGet]
        public int Test1([FromServices]TestService testService)//Action参数来注入，只有使用频率不高而且比较消化资源的服务才用这种。因为不使用，会拖慢其他方法的运行
        {
            return testService.Count;
        }
    }
}
