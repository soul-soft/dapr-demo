using Api1.Actors;
using Api1.Models;
using Dapr.Actors;
using Dapr.Actors.Client;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

namespace Api1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActorController : ControllerBase
    {
        private readonly IActorProxyFactory _actors;
        private readonly ILogger<HealthController> _logger;

        public ActorController(
            IActorProxyFactory actors,
            ILogger<HealthController> logger)
        {
            _actors = actors;
            _logger = logger;
        }

        /// <summary>
        /// µ÷ÓÃ
        /// </summary>
        /// <returns></returns>
        [HttpPost("{id}")]
        public async Task<int> Post(string id)
        {
            var scoreActor = _actors.CreateActorProxy<IScoreActor>(new ActorId(id), "ScoreActor");

            return await scoreActor.IncrementScoreAsync();
        }
    }
}