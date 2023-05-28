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

		/// <summary>
		/// Возвращает конкретный статус игры по его ID
		/// </summary>
		/// <param name="id">ID статуса</param>
		/// <returns></returns>
		public GameStatus GetStatusById(int id)
        {
            return _context.GameStatuses.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Возвращает всее статусы игр
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GameStatus> GetStatuses()
        {
            return _context.GameStatuses.ToList();
        }

		/// <summary>
		/// Сохраняет или обновляет указанный сценарий в базе данных
		/// </summary>
		/// <param name="obj"></param>
		public void SaveStatus(GameStatus obj)
        {
            if (_context.GameStatuses.Any(x => x.Id == obj.Id))
                _context.Entry(obj).State = EntityState.Modified;
            else
                _context.Entry(obj).State = EntityState.Added;

            _context.SaveChanges();
        }
    }
}
