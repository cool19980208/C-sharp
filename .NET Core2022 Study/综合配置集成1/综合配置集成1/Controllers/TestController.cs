using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace 综合配置集成1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IOptions<SmtpSettings> optSmtp;
        private readonly IConnectionMultiplexer connectionMultiplexer;
        public TestController(IOptions<SmtpSettings> optSmtp, IConnectionMultiplexer connectionMultiplexer)
        {
            this.optSmtp = optSmtp;
            this.connectionMultiplexer = connectionMultiplexer;
        }
        [HttpGet]
        public string Demo1()
        {
            var ping = connectionMultiplexer.GetDatabase(0).Ping();
            return optSmtp.Value.ToString() + "|" + ping;
        }
    }
}
