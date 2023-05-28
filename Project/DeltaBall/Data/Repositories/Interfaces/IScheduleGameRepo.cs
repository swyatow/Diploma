using DeltaBall.Data.Models;

namespace DeltaBall.Data.Repositories.Interfaces
{
    public interface IScheduleGameRepo
    {
        public ScheduleGame GetGameById(Guid id);

        public IEnumerable<ScheduleGame> GetGames();

        public IEnumerable<Player> GetGamesByPlayer(Guid id);

        public IEnumerable<ScheduleGame> GetGamesByDate(DateTime date);

        public void SaveGame(ScheduleGame obj, Guid creatorId);

        public bool DeleteGame(ScheduleGame obj);
    }
}
