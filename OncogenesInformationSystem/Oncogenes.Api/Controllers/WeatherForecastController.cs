using Microsoft.AspNetCore.Mvc;
using Oncogenes.DAL.Repository;

namespace Oncogenes.Api.Controllers
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

        private readonly IOncogenesRepository oncogenesRepository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IOncogenesRepository oncogenesRepository)
        {
            _logger = logger;
            this.oncogenesRepository = oncogenesRepository;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {

            var result = oncogenesRepository.GetAllGenes();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}