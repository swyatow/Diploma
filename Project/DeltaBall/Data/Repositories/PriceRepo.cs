using DeltaBall.Data.Models;
using DeltaBall.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DeltaBall.Data.Repositories
{
    public class PriceRepo : IPriceRepo
    {
        private readonly AppDbContext _context;
        public PriceRepo(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Возвращает цену по ее ID
        /// </summary>
        /// <param name="id">ID цены</param>
        /// <returns></returns>
        public Price GetPriceById(int id)
        {
            return _context.Prices
                .Include(x => x.Scenario)
                .Include(x => x.GameType)
                .FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Возвращает список всех цен
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Price> GetPrices()
        {
            return _context.Prices
                .Include(x=>x.Scenario)
                .Include(x=>x.GameType)
                .ToList();
        }

        /// <summary>
        /// Сохраняет или обновляет информацию о цене в базе данных
        /// </summary>
        /// <param name="obj"></param>
        public void SavePrice(Price obj)
        {
            if (_context.Prices.Any(x => x.Id == obj.Id))
                _context.Entry(obj).State = EntityState.Modified;
            else
                _context.Entry(obj).State = EntityState.Added;

            _context.SaveChanges();
        }

        /// <summary>
        /// Удаляет цену
        /// </summary>
        /// <param name="obj">Объект цены</param>
        /// <returns></returns>
		public bool DeletePrice(Price obj)
		{
			if (_context.Prices.Any(x => x.Id == obj.Id))
			{
				_context.Entry(obj).State = EntityState.Deleted;
				_context.SaveChanges();
				return true;
			}
			return false;
		}
	}
}
