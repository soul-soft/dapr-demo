using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

namespace Api1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthController : ControllerBase
    {
        private readonly DaprClient _dapr;
        private readonly ILogger<HealthController> _logger;

        public HealthController(
            DaprClient dapr,
            ILogger<HealthController> logger)
        {
            _dapr = dapr;
            _logger = logger;
        }
        
        /// <summary>
        /// ½¡¿µ¼ì²é
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<bool> Get()
        {
            return await _dapr.CheckHealthAsync();
        }
    }
}