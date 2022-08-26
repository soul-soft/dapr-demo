using Api1.Models;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

namespace Api1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceInvokeController : ControllerBase
    {
        private readonly DaprClient _dapr;
        private readonly ILogger<ServiceInvokeController> _logger;

        public ServiceInvokeController(
            DaprClient dapr,
            ILogger<ServiceInvokeController> logger)
        {
            _dapr = dapr;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            return await _dapr.InvokeMethodAsync<IEnumerable<WeatherForecast>>(HttpMethod.Get, "api2", "WeatherForecast");
        }
    }
}