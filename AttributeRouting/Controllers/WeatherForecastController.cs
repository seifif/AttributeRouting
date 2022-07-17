using Microsoft.AspNetCore.Mvc;

namespace AttributeRouting.Controllers
{
    [ApiController]
    [Route("[controller]")]
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

        [Route("")]
        [Route("/")]
        [Route("/Home")]
        [Route("/[controller]/[action]")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [Route("Day")]
        [Route("Day/Get")]
        [Route("Day/Get/{dayIndex?}")]
        public ActionResult<WeatherForecast> Get(int dayIndex)
        {
            var rng = new Random();
            return new WeatherForecast
            {
                Date = DateTime.Now.AddDays(dayIndex),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            };
        }

        [HttpGet("{dayStartIndex}/{dayEndIndex}")]
        public IEnumerable<WeatherForecast> Get(int dayStartIndex, int dayEndIndex)
        {
            var rng = new Random();
            return Enumerable.Range(dayStartIndex, dayEndIndex).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("/Get")]
        [HttpGet("Index")]
        [Route("Day/Get/3")]
        public IEnumerable<WeatherForecast> GetIndex()
        {
            var rng = new Random();
            return Enumerable.Range(1, 3).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}