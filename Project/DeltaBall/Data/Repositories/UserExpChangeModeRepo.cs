using DeltaBall.Data.Models;
using DeltaBall.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DeltaBall.Data.Repositories
{
    public class UserExpChangeModeRepo : IUserExpChangeModeRepo
    {
        private readonly AppDbContext _context;
        public UserExpChangeModeRepo(AppDbContext context)
        {
            _context = context;
        }        

        /// <summary>
        /// Возвращает конкретный режим изменения истории по ID
        /// </summary>
        /// <param name="id">ID режима изменения</param>
        /// <returns></returns>
        public UserExpChangeMode GetChangeModeById(int id)
        {
            return _context.UserExpChangeModes.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Возвращает список режимов изменения истории
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserExpChangeMode> GetChangeModes()
        {
            return _context.UserExpChangeModes.ToList();
        }

        /// <summary>
        /// Сохраняет или обновляет информацию о режиме изменения в базе данных
        /// </summary>
        /// <param name="obj"></param>
        public void SaveChangeMode(UserExpChangeMode obj)
        {
            if (_context.UserExpChangeModes.Any(x => x.Id == obj.Id))
                _context.Entry(obj).State = EntityState.Modified;
            else
                _context.Entry(obj).State = EntityState.Added;

            _context.SaveChanges();
        }

        /// <summary>
        /// Удаляет режим изменения истории опыта
        /// </summary>
        /// <param name="obj">Объект режима</param>
        /// <returns></returns>
		public bool DeleteChangeMode(UserExpChangeMode obj)
		{
			if (_context.UserExpChangeModes.Any(x => x.Id == obj.Id))
			{
				_context.Entry(obj).State = EntityState.Deleted;
				_context.SaveChanges();
				return true;
			}
			return false;
		}
	}
}
