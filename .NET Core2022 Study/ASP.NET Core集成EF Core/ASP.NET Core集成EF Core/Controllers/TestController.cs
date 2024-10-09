using BooksEFCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core集成EF_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly MyDbContext dbCtx;//我们直接注入使用即可。不需要在new MyDbContext了

        public TestController(MyDbContext dbCtx)
        {
            this.dbCtx = dbCtx;
        }
        [HttpGet]
        public string Demo1()
        {
            int c = dbCtx.Books.Count();
            return $"c={c}";
        }
    }
}
