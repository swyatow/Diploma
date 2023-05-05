using DeltaBall.Data.Models;

namespace DeltaBall.Data.Repositories.Interfaces
{
    public interface IPlayerRepo
    {
        public Player GetPlayerById(Guid id);

        public IEnumerable<Player> GetPlayersForGame(Guid id);

        public void SavePlayer(Player obj);

        public bool DeletePlayer(Player obj);
    }
}
