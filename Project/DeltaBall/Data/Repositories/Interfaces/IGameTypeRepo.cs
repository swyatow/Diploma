using DeltaBall.Data.Models;

namespace DeltaBall.Data.Repositories.Interfaces
{
    public interface IGameTypeRepo
    {
        public GameType GetTypeById(int id);

        public IEnumerable<GameType> GetTypes();

        public void SaveType(GameType obj);

        public bool DeleteType(GameType obj);
    }
}
