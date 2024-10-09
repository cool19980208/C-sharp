using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace 配置系统集成1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Test1Controller : ControllerBase
    {
        private readonly IWebHostEnvironment webEnv;

        public Test1Controller(IWebHostEnvironment webEnv)
        {
            this.webEnv = webEnv;
        }

        [HttpGet]
        public string Demo1()
        {
            return webEnv.EnvironmentName;
            //return Environment.GetEnvironmentVariable("haha");
        }
    }
}
