using Microsoft.AspNetCore.Mvc;

namespace MyFirstWebApplication.Controllers
{
    [ApiController]//Attribute---属性
    [Route("[controller]")]//设置路由规则，规则中[controller]代表控制器的名字，也就是WeatherForecast
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[] 
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]//发送Get请求接口
        public IEnumerable<WeatherForecast> Get()//Get方法返回对象会被自动进行Json序列化返回给客户端
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
