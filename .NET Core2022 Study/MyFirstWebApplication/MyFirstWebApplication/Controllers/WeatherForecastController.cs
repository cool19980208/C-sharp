using Microsoft.AspNetCore.Mvc;

namespace MyFirstWebApplication.Controllers
{
    [ApiController]//Attribute---����
    [Route("[controller]")]//����·�ɹ��򣬹�����[controller]��������������֣�Ҳ����WeatherForecast
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

        [HttpGet(Name = "GetWeatherForecast")]//����Get����ӿ�
        public IEnumerable<WeatherForecast> Get()//Get�������ض���ᱻ�Զ�����Json���л����ظ��ͻ���
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
