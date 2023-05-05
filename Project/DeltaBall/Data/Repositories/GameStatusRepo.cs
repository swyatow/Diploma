using DeltaBall.Data.Models;
using DeltaBall.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DeltaBall.Data.Repositories
{
    public class GameStatusRepo : IGameStatusRepo
    {
        private readonly AppDbContext _context;
        public GameStatusRepo(AppDbContext context)
        {
            _context = context;
        }

        public GameStatus GetStatusById(int id)
        {
            return _context.GameStatuses.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<GameStatus> GetStatuses()
        {
            return _context.GameStatuses;
        }

        public void SaveStatus(GameStatus obj)
        {
            if (_context.GameStatuses.Any(x => x.Id == obj.Id))
                _context.Entry(obj).State = EntityState.Added;
            else
                _context.Entry(obj).State = EntityState.Modified;

            _context.SaveChanges();
        }

        public bool DeleteStatus(GameStatus obj)
        {
            if (_context.GameStatuses.Any(x => x.Id == obj.Id))
            {
                _context.Entry(obj).State = EntityState.Deleted;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
