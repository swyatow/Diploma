using DeltaBall.Data.Models;
using DeltaBall.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DeltaBall.Data.Repositories
{
    public class UserExpChangeModeRepo : IUserExpChangeModeRepo
    {
        private readonly AppDbContext _context;
        public UserExpChangeModeRepo(AppDbContext context)
        {
            _context = context;
        }

        public bool DeleteChangeMode(UserExpChangeMode obj)
        {
            if (_context.UserExpChangeModes.Any(x => x.Id == obj.Id))
            {
                _context.Entry(obj).State = EntityState.Deleted;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public UserExpChangeMode GetChangeModeById(int id)
        {
            return _context.UserExpChangeModes.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<UserExpChangeMode> GetChangeModes()
        {
            return _context.UserExpChangeModes;
        }

        public void SaveChangeMode(UserExpChangeMode obj)
        {
            if (_context.UserExpChangeModes.Any(x => x.Id == obj.Id))
                _context.Entry(obj).State = EntityState.Added;
            else
                _context.Entry(obj).State = EntityState.Modified;

            _context.SaveChanges();
        }
    }
}
