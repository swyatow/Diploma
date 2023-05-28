using DeltaBall.Data.Models;
using DeltaBall.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DeltaBall.Data.Repositories
{
    public class RankRepo : IRankRepo
    {
        private readonly AppDbContext _context;
        public RankRepo(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Возвращает ранг по его ID
        /// </summary>
        /// <param name="id">ID ранга</param>
        /// <returns></returns>
        public Rank GetRankById(int id)
        {
            return _context.Ranks.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Возвращает список рангов
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Rank> GetRanks()
        {
            return _context.Ranks.ToList();
        }

		/// <summary>
		/// Сохраняет или обновляет информацию о ранге в базе данных
		/// </summary>
		/// <param name="obj">Объект ранга</param>
		public void SaveRank(Rank obj)
        {
            if (_context.Ranks.Any(x => x.Id == obj.Id))
                _context.Entry(obj).State = EntityState.Modified;
            else
                _context.Entry(obj).State = EntityState.Added;

            _context.SaveChanges();
        }

        /// <summary>
        /// Удаляет ранг
        /// </summary>
        /// <param name="obj">Объект ранга</param>
        /// <returns></returns>
		public bool DeleteRank(Rank obj)
		{
			if (_context.Ranks.Any(x => x.Id == obj.Id))
			{
				_context.Entry(obj).State = EntityState.Deleted;
				_context.SaveChanges();
				return true;
			}
			return false;
		}
	}
}
