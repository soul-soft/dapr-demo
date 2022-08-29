using Api1.Models;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

namespace Api1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PubController : ControllerBase
    {
        private readonly DaprClient _dapr;
        private readonly ILogger<HealthController> _logger;

        public PubController(
            DaprClient dapr,
            ILogger<HealthController> logger)
        {
            _dapr = dapr;
            _logger = logger;
        }

        /// <summary>
        /// ·¢²¼
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task Post()
        {
            await _dapr.PublishEventAsync("pubsub", "student-post", new Student
            {
                Age = 10,
                Name = "zs"
            });
        }
    }
}