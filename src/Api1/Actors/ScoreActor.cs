using Dapr.Actors;
using Dapr.Actors.Runtime;

namespace Api1.Actors
{

    public interface IScoreActor : IActor
    {
        Task<int> IncrementScoreAsync();

        Task<int> GetScoreAsync();
    }

    public class ScoreActor : Actor, IScoreActor
    {
        public ScoreActor(ActorHost host) : base(host)
        {

        }

        public async Task<int> GetScoreAsync()
        {
            var result = await StateManager.TryGetStateAsync<int>("score");
            if (result.HasValue)
            {
                return result.Value;
            }
            return 0;
        }

        public async Task<int> IncrementScoreAsync()
        {
            return await StateManager.AddOrUpdateStateAsync("score", 1, (key, currentScore) => currentScore + 1);
        }
    }
}
