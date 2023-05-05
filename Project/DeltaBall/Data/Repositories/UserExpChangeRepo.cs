using DeltaBall.Data.Models;
using DeltaBall.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DeltaBall.Data.Repositories
{
    public class UserExpChangeRepo : IUserExpChangeRepo
    {
        private readonly AppDbContext _context;
        public UserExpChangeRepo(AppDbContext context)
        {
            _context = context;
        }

        public bool DeleteExpChange(UserExpChange obj)
        {
            if (_context.UserExpChanges.Any(x => x.Id == obj.Id))
            {
                _context.Entry(obj).State = EntityState.Deleted;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public UserExpChange GetExpChangeById(Guid id)
        {
            return _context.UserExpChanges.FirstOrDefault(x => x.Id == id);
        }
        
        public IEnumerable<UserExpChange> GetExpChanges()
        {
            return _context.UserExpChanges;
        }

        public void SaveExpChange(UserExpChange obj)
        {
            if (_context.UserExpChanges.Any(x => x.Id == obj.Id))
                _context.Entry(obj).State = EntityState.Added;
            else
                _context.Entry(obj).State = EntityState.Modified;

            _context.SaveChanges();
        }
    }
}
