using DeltaBall.Data.Models;
using DeltaBall.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DeltaBall.Data.Repositories
{
    public class GameScenarioRepo : IGameScenarioRepo
    {
        private readonly AppDbContext _context;
        public GameScenarioRepo(AppDbContext context)
        {
            _context = context;
        }

        public GameScenario GetScenarioById(int id)
        {
            return _context.GameScenarios.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<GameScenario> GetScenarios()
        {
            return _context.GameScenarios;
        }

        public void SaveScenario(GameScenario obj)
        {
            if (_context.GameScenarios.Any(x => x.Id == obj.Id))
                _context.Entry(obj).State = EntityState.Added;
            else
                _context.Entry(obj).State = EntityState.Modified;

            _context.SaveChanges();
        }

        public bool DeleteScenario(GameScenario obj)
        {
            if (_context.GameScenarios.Any(x => x.Id == obj.Id))
            {
                _context.Entry(obj).State = EntityState.Deleted;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
