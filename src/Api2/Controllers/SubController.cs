using Api2.Models;
using Dapr;
using Dapr.Client;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace Api2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubController : ControllerBase
    {
        private readonly DaprClient _dapr;
        private readonly ILogger<HealthController> _logger;

        public SubController(
            DaprClient dapr,
            ILogger<HealthController> logger)
        {
            _dapr = dapr;
            _logger = logger;
        }

        /// <summary>
        /// ¶©ÔÄ
        /// </summary>
        /// <param name="student"></param>
        [HttpPost]
        [Topic("pubsub", "student-post")]
        public void Get(Student student)
        {
            var json = JsonSerializer.Serialize(student);
            _logger.LogInformation(json);
        }
    }
}