using DeltaBall.Data.Models;
using DeltaBall.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DeltaBall.Data.Repositories
{
    public class PriceRepo : IPriceRepo
    {
        private readonly AppDbContext _context;
        public PriceRepo(AppDbContext context)
        {
            _context = context;
        }

        public bool DeletePrice(Price obj)
        {
            if (_context.Prices.Any(x => x.Id == obj.Id))
            {
                _context.Entry(obj).State = EntityState.Deleted;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public Price GetPriceById(int id)
        {
            return _context.Prices.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Price> GetPrices()
        {
            return _context.Prices;
        }

        public void SavePrice(Price obj)
        {
            if (_context.Prices.Any(x => x.Id == obj.Id))
                _context.Entry(obj).State = EntityState.Added;
            else
                _context.Entry(obj).State = EntityState.Modified;

            _context.SaveChanges();
        }
    }
}
