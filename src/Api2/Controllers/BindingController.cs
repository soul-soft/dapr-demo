using Api2.Models;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Api2.Controllers
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
        /// ∞Û∂®- ‰»Î
        /// </summary>
        /// <param name="student"></param>
        [HttpPost]
        public void Post(Student student)
        {
            var json = JsonSerializer.Serialize(student);
            _logger.LogInformation(json);
        }
    }
}