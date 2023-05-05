using DeltaBall.Data.Models;
using DeltaBall.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DeltaBall.Data.Repositories
{
    public class GameTypeRepo : IGameTypeRepo
    {
        private readonly AppDbContext _context;
        public GameTypeRepo(AppDbContext context)
        {
            _context = context;
        }
        public bool DeleteType(GameType obj)
        {
            if (_context.GameTypes.Any(x => x.Id == obj.Id))
            {
                _context.Entry(obj).State = EntityState.Deleted;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public GameType GetTypeById(int id)
        {
            return _context.GameTypes.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<GameType> GetTypes()
        {
            return _context.GameTypes;
        }

        public void SaveType(GameType obj)
        {
            if (_context.GameTypes.Any(x => x.Id == obj.Id))
                _context.Entry(obj).State = EntityState.Added;
            else
                _context.Entry(obj).State = EntityState.Modified;

            _context.SaveChanges();
        }
    }
}
