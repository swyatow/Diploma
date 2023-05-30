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

        /// <summary>
        /// Получает информацию об участике игры
        /// </summary>
        /// <param name="id">ID участника</param>
        /// <returns></returns>
		public Player GetPlayerById(Guid id)
		{
			return _context.Players
                .Include(x => x.Client)
                .Include(x => x.Game)
                .FirstOrDefault(x => x.Id == id);
		}

        /// <summary>
        /// Возвращает список всех участников конкретной игры
        /// </summary>
        /// <param name="id">ID игры</param>
        /// <returns></returns>
		public IEnumerable<Player> GetPlayersForGame(Guid id)
		{
			return _context.Players.Include(x=>x.Client).Include(x=>x.Game).Where(x => x.GameId == id).ToList();
		}

        /// <summary>
        /// Сохраняет запись об участии игрока в базе данных
        /// </summary>
        /// <param name="obj">Запись об участии игрока</param>
        public void SavePlayer(Player obj)
        {
            if (_context.Players.Any(x => x.Id == obj.Id))
                _context.Entry(obj).State = EntityState.Modified;
            else
                _context.Entry(obj).State = EntityState.Added;

            _context.SaveChanges();
        }

        /// <summary>
        /// Удаляет запись на игру выбранного участника
        /// </summary>
        /// <param name="obj">Запись об участии игрока</param>
        /// <returns></returns>
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
    }
}
