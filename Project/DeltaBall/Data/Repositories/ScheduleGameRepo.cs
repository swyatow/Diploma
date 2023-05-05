using DeltaBall.Data.Models;
using DeltaBall.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DeltaBall.Data.Repositories
{
    public class ScheduleGameRepo : IScheduleGameRepo
    {
        private readonly AppDbContext _context;
        public ScheduleGameRepo(AppDbContext context)
        {
            _context = context;
        }

        public bool DeleteGame(ScheduleGame obj)
        {
            if (_context.ScheduleGames.Any(x => x.Id == obj.Id))
            {
                _context.Entry(obj).State = EntityState.Deleted;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public ScheduleGame GetGameById(Guid id)
        {
            return _context.ScheduleGames.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<ScheduleGame> GetGames()
        {
            return _context.ScheduleGames;
        }

        public IEnumerable<ScheduleGame> GetNotFullGames()
        {
            return _context.ScheduleGames
                .Where(x => x.MaxPeoples > _context.Players.Count(y=>y.GameId == x.Id));
        }

        public void SaveGame(ScheduleGame obj)
        {
            if (_context.ScheduleGames.Any(x => x.Id == obj.Id))
                _context.Entry(obj).State = EntityState.Added;
            else
                _context.Entry(obj).State = EntityState.Modified;

            _context.SaveChanges();
        }
    }
}
