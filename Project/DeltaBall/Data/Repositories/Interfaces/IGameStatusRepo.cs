using DeltaBall.Data.Models;

namespace DeltaBall.Data.Repositories.Interfaces
{
    public interface IGameStatusRepo
    {
        public GameStatus GetStatusById(int id);

        public IEnumerable<GameStatus> GetStatuses();

        public void SaveStatus(GameStatus obj);

        public bool DeleteStatus(GameStatus obj);
    }
}
