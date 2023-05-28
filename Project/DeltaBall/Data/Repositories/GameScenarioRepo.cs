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

        /// <summary>
        /// Возвращает конкретный сценарий по его ID
        /// </summary>
        /// <param name="id">ID сценария</param>
        /// <returns></returns>
        public GameScenario GetScenarioById(int id)
        {
            return _context.GameScenarios.FirstOrDefault(x => x.Id == id);
        }

		/// <summary>
		/// Возвращает все сценарии
		/// </summary>
		/// <returns></returns>
		public IEnumerable<GameScenario> GetScenarios()
        {
            return _context.GameScenarios.ToList();
        }

        /// <summary>
        /// Сохраняет или обновляет сценарий в базе
        /// </summary>
        /// <param name="obj">Сценарий</param>
        public void SaveScenario(GameScenario obj)
        {
            if (_context.GameScenarios.Any(x => x.Id == obj.Id))
                _context.Entry(obj).State = EntityState.Modified;
            else
                _context.Entry(obj).State = EntityState.Added;

            _context.SaveChanges();
        }

        /// <summary>
        /// Удаляет указанный сценарий
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
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
