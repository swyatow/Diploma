using DeltaBall.Data.Models;

namespace DeltaBall.Data.Repositories.Interfaces
{
    public interface IGameScenarioRepo
    {
        /// <summary>
        /// Получить сченарий по его ID
        /// </summary>
        /// <param name="id">ID сценария</param>
        /// <returns></returns>
        public GameScenario GetScenarioById(int id);

        /// <summary>
        /// Почучить список сценариев
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GameScenario> GetScenarios();

        /// <summary>
        /// Создать новый или изменить существующий сценария
        /// </summary>
        /// <param name="obj"></param>
        public void SaveScenario(GameScenario obj);

        /// <summary>
        /// Удалить сценарий из базы данных
        /// </summary>
        /// <param name="obj">Обхект сценария</param>
        /// <returns></returns>
        public bool DeleteScenario(GameScenario obj);
    }
}
