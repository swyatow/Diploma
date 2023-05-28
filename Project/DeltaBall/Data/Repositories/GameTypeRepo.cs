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

        /// <summary>
        /// Вызвращает тип игры по его ID
        /// </summary>
        /// <param name="id">ID типа игры</param>
        /// <returns></returns>
        public GameType GetTypeById(int id)
        {
            return _context.GameTypes.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Возвращает список типов игры
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GameType> GetTypes()
        {
            return _context.GameTypes.ToList();
        }

        /// <summary>
        /// Сохраняет или обновляет информацию о типе игры
        /// </summary>
        /// <param name="obj">Объект типа игры</param>
        public void SaveType(GameType obj)
        {
            if (_context.GameTypes.Any(x => x.Id == obj.Id))
                _context.Entry(obj).State = EntityState.Modified;
            else
                _context.Entry(obj).State = EntityState.Added;

            _context.SaveChanges();
        }

        /// <summary>
        /// Удаляет указанный тип игры
        /// </summary>
        /// <param name="obj">Объект типа игры</param>
        /// <returns></returns>
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
	}
}
