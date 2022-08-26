using Api1.Models;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

namespace Api1.Controllers
{
    [ApiController]
    [Route("binding")]
    public class BindingController : ControllerBase
    {
        private readonly DaprClient _dapr;
        private readonly ILogger<HealthController> _logger;

        public BindingController(
            DaprClient dapr,
            ILogger<HealthController> logger)
        {
            _dapr = dapr;
            _logger = logger;
        }

        /// <summary>
        /// °ó¶¨-Êä³ö
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task Post()
        {
            await _dapr.InvokeBindingAsync("binding", "create", new Student
            {
                Age = 50,
                Name = "zs"
            });
        }
    }
}