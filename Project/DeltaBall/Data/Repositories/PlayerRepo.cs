using DeltaBall.Data.Models;
using DeltaBall.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DeltaBall.Data.Repositories
{
    public class PlayerRepo : IPlayerRepo
    {
        private readonly AppDbContext _context;
        public PlayerRepo(AppDbContext context)
        {
            _context = context;
        }

        public bool DeletePlayer(Player obj)
        {
            if (_context.Players.Any(x => x.Id == obj.Id))
            {
                _context.Entry(obj).State = EntityState.Deleted;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public Player GetPlayerById(Guid id)
        {
            return _context.Players.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Player> GetPlayersForGame(Guid id)
        {
            return _context.Players.Where(x => x.GameId == id);
        }

        public void SavePlayer(Player obj)
        {
            if (_context.Players.Any(x => x.Id == obj.Id))
                _context.Entry(obj).State = EntityState.Added;
            else
                _context.Entry(obj).State = EntityState.Modified;

            _context.SaveChanges();
        }
    }
}
