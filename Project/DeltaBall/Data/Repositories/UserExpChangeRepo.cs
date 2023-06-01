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

        /// <summary>
        /// Возвращает конкретное изменение в истории
        /// </summary>
        /// <param name="id">ID изменения</param>
        /// <returns></returns>
        public UserExpChange GetExpChangeById(Guid id)
        {
            return _context.UserExpChanges.FirstOrDefault(x => x.Id == id);
        }
        
        /// <summary>
        /// Возвращает список всей истории всех клиентов
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserExpChange> GetExpChanges()
        {
            return _context.UserExpChanges
                .Include(x => x.ChangeMode)
				.Include(x => x.Client)
                .OrderByDescending(x=>x.ChangeDate)
                .ToList();
        }

        /// <summary>
        /// Возвращает историю по одному игроку
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public IEnumerable<UserExpChange> GetExpChangeByPlayer(Guid id)
		{
			return _context.UserExpChanges
                .Where(x => x.ClientId == id)
                .Include(x=>x.ChangeMode)
                .Include(x=>x.Client)
                .OrderByDescending(x=>x.ChangeDate)
                .ToList();
		}

        /// <summary>
        /// Сохраняет или обновляет результат изменения опыта
        /// </summary>
        /// <param name="obj">Объект с изменением</param>
		public void SaveExpChange(UserExpChange obj)
        {
            var changeMode = _context.UserExpChangeModes.First(x => x.Id == obj.ChangeModeId);
			obj.DeltaExp = 50 * changeMode.Multiplier;
			if (_context.UserExpChanges.Any(x => x.Id == obj.Id))
            {
				_context.Entry(obj).State = EntityState.Modified;
            }
            else
            {
                _context.Entry(obj).State = EntityState.Added;
            }
            var client = _context.Clients.First(x => x.Id == obj.ClientId);
            client.Experience += obj.DeltaExp;
            var newRank = _context.Ranks.First(x => x.MinExp <= client.Experience && x.MaxExp > client.Experience);
            client.RankId = newRank.Id;

            _context.Entry(client).State = EntityState.Modified;
            _context.SaveChanges();
        }

        /// <summary>
        /// Удалить изменение опыта
        /// </summary>
        /// <param name="obj">Объект с изменением опыта</param>
        /// <returns></returns>
		public bool DeleteExpChange(UserExpChange obj)
		{
			if (_context.UserExpChanges.Any(x => x.Id == obj.Id))
			{
                var client = _context.Clients.First(x => x.Id == obj.ClientId);
                if (client.Experience - obj.DeltaExp * obj.ChangeMode.Multiplier < 0)
                    client.Experience = 0;
                else
                    client.Experience -= obj.DeltaExp * obj.ChangeMode.Multiplier;
                var newRank = _context.Ranks.First(x=>x.MinExp <= client.Experience && x.MaxExp > client.Experience);
                client.RankId = newRank.Id;

                _context.Entry(client).State = EntityState.Modified;
                _context.Entry(obj).State = EntityState.Deleted;
				_context.SaveChanges();
				return true;
			}
			return false;
		}
	}
}
