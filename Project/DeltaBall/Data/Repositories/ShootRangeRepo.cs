using DeltaBall.Data.Models;
using DeltaBall.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DeltaBall.Data.Repositories
{
    public class ShootRangeRepo : IShootRangeRepo
    {
        private readonly AppDbContext _context;
        public ShootRangeRepo(AppDbContext context)
        {
            _context = context;
        }

        public bool DeleteRange(ShootRange obj)
        {
            if (_context.ShootRanges.Any(x => x.Id == obj.Id))
            {
                _context.Entry(obj).State = EntityState.Deleted;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public ShootRange GetRangeById(Guid id)
        {
            return _context.ShootRanges.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<ShootRange> GetRanges()
        {
            return _context.ShootRanges;
        }

        public void SaveRange(ShootRange obj)
        {
            if (_context.ShootRanges.Any(x => x.Id == obj.Id))
                _context.Entry(obj).State = EntityState.Added;
            else
                _context.Entry(obj).State = EntityState.Modified;

            _context.SaveChanges();
        }
    }
}
