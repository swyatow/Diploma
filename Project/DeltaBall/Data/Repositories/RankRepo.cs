using DeltaBall.Data.Models;
using DeltaBall.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DeltaBall.Data.Repositories
{
    public class RankRepo : IRankRepo
    {
        private readonly AppDbContext _context;
        public RankRepo(AppDbContext context)
        {
            _context = context;
        }

        public bool DeleteRank(Rank obj)
        {
            if (_context.Ranks.Any(x => x.Id == obj.Id))
            {
                _context.Entry(obj).State = EntityState.Deleted;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public Rank GetRankById(int id)
        {
            return _context.Ranks.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Rank> GetRanks()
        {
            return _context.Ranks;
        }

        public void SaveRank(Rank obj)
        {
            if (_context.Ranks.Any(x => x.Id == obj.Id))
                _context.Entry(obj).State = EntityState.Added;
            else
                _context.Entry(obj).State = EntityState.Modified;

            _context.SaveChanges();
        }
    }
}
