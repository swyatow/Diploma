using DeltaBall.Data.Models;

namespace DeltaBall.Data.Repositories.Interfaces
{
    public interface IScheduleGameRepo
    {
        public ScheduleGame GetGameById(Guid id);

        public IEnumerable<ScheduleGame> GetGames();

        public IEnumerable<ScheduleGame> GetNotFullGames();

        public void SaveGame(ScheduleGame obj);

        public bool DeleteGame(ScheduleGame obj);
    }
}
