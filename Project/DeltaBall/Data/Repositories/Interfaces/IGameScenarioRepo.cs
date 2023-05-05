using DeltaBall.Data.Models;

namespace DeltaBall.Data.Repositories.Interfaces
{
    public interface IGameScenarioRepo
    {
        public GameScenario GetScenarioById(int id);

        public IEnumerable<GameScenario> GetScenarios();

        public void SaveScenario(GameScenario obj);

        public bool DeleteScenario(GameScenario obj);
    }
}
