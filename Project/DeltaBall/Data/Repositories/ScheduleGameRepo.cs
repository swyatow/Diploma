using DeltaBall.Data.Models;
using DeltaBall.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DeltaBall.Data.Repositories
{
    public class ScheduleGameRepo : IScheduleGameRepo
    {
        private readonly AppDbContext _context;
        public ScheduleGameRepo(AppDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Возвращает конкретную игру по ID
        /// </summary>
        /// <param name="id">ID игры</param>
        /// <returns></returns>
        public ScheduleGame GetGameById(Guid id)
        {
            return GetAllInfo()
                .FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Возвращает список игр
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ScheduleGame> GetGames()
        {
            return GetAllInfo().ToList();
        }

		/// <summary>
		/// Возвращает список игр для указанного игрока
		/// </summary>
		/// <param name="id">ID игрока</param>
		public IEnumerable<Player> GetGamesByPlayer(Guid id)
        {
            return _context.Players
                .Where(x=>x.ClientId == id).Include(x=>x.Game).Include(x=>x.Game.Status);
        }

		/// <summary>
		/// Возвращает список игр на указанный день
		/// </summary>
		/// <param name="date">Дата отбора игр</param>
		public IEnumerable<ScheduleGame> GetGamesByDate(DateTime date)
		{
			return GetAllInfo().Where(x=>x.StartDate.Date == date.Date).ToList();
		}

        /// <summary>
        /// Сохраняет информацию об игре
        /// </summary>
        /// <param name="obj">Объект игры</param>
		public void SaveGame(ScheduleGame obj, Guid creatorId)
        {
            var price = _context.Prices.FirstOrDefault(x => x.ScenarioId == obj.ScenarioId && x.GameTypeId == obj.TypeId).Value * obj.Hours;
            var client = _context.Clients.Include(x=>x.Rank).FirstOrDefault(x => x.Id == creatorId);
            obj.StatusId = 4;
            obj.Price = price;
			Player creator = new Player()
            {
                ClientId = creatorId,
                GameId = obj.Id,
                IsCreator = true,
                Price = price * ((100 - client.Rank.Discount) / 100),
            };
			_context.Entry(obj).State = EntityState.Added;
			_context.Entry(creator).State = EntityState.Added;
            _context.SaveChanges();
        }

		/// <summary>
		/// Удаляет игру
		/// </summary>
		/// <param name="obj">Объект игры</param>
		/// <returns></returns>
		public bool DeleteGame(ScheduleGame obj)
		{
			if (_context.ScheduleGames.Any(x => x.Id == obj.Id))
			{
				_context.Entry(obj).State = EntityState.Deleted;
				_context.SaveChanges();
				return true;
			}
			return false;
		}

        private IEnumerable<ScheduleGame> GetAllInfo()
        {
            return _context.ScheduleGames
                .Include(x => x.Range)
                .Include(x => x.Status)
                .Include(x => x.Scenario)
                .Include(x => x.Type);
        }
	}
}
