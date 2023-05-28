using DeltaBall.Data.Models;
using DeltaBall.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DeltaBall.Data.Repositories
{
    public class ShootRangeRepo : IShootRangeRepo
    {
        private readonly AppDbContext _context;
        public ShootRangeRepo(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Возвращает конретный полигон по ID
        /// </summary>
        /// <param name="id">ID полигона</param>
        /// <returns></returns>
        public ShootRange GetRangeById(Guid id)
        {
            return _context.ShootRanges.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Возвращает список полигонов
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ShootRange> GetRanges()
        {
            return _context.ShootRanges.ToList();
        }

        /// <summary>
        /// Сохраняет или обновляет информацию о полигоне в базе данных
        /// </summary>
        /// <param name="obj">Объект полигона</param>
        public void SaveRange(ShootRange obj)
        {
            if (_context.ShootRanges.Any(x => x.Id == obj.Id))
                _context.Entry(obj).State = EntityState.Modified;
            else
                _context.Entry(obj).State = EntityState.Added;

            _context.SaveChanges();
        }

        /// <summary>
        /// Удаляет полигон из базы данных
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
		public bool DeleteRange(ShootRange obj)
		{
			if (_context.ShootRanges.Any(x => x.Id == obj.Id))
			{
				_context.Entry(obj).State = EntityState.Deleted;
				_context.SaveChanges();
				return true;
			}
			return false;
		}
	}
}
