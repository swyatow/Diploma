using DeltaBall.Data.Models;
using DeltaBall.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.RegularExpressions;

namespace DeltaBall.Data.Repositories
{
    public class ClientRepo : IClientRepo
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public ClientRepo(AppDbContext context, UserManager<IdentityUser> manager)
        {
            _context = context;
            _userManager = manager;
        }
        /// <summary>
        /// Получить клиента по его ID
        /// </summary>
        /// <param name="id">Guid клиента</param>
        /// <returns></returns>
        public Client GetClientById(Guid id)
        {
            return GetClients().FirstOrDefault(x=>x.Id == id);
        }

        /// <summary>
        /// Получить список всех клиентов
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Client> GetClients()
        {
            return _context.Clients.Include(x => x.Rank).OrderBy(x=>x.FullName).ToList();
        }

        /// <summary>
        /// Создать нового или изменить существующего клиента
        /// </summary>
        /// <param name="obj">Объект клиента</param>
        public async Task<bool> SaveClientAsync(Client obj, string password)
        {
            IdentityUser user;
			try
            {
				if (_context.Clients.Any(x => x.Id == obj.Id))
				{
					user = _context.Users.First(x => x.Id == obj.Id.ToString());
					user.UserName = obj.FullName;
					user.NormalizedUserName = obj.FullName.ToUpper();
					user.Email = obj.Email;
					user.NormalizedEmail = obj.Email.ToUpper();
					user.PhoneNumber = obj.PhoneNumber;
                    user.PhoneNumberConfirmed = true;
                    user.EmailConfirmed = true;
					_context.Entry(user).State = EntityState.Modified;
					_context.Entry(obj).State = EntityState.Modified;
				}
				else
				{
					user = new IdentityUser()
					{
						Id = obj.Id.ToString(),
						UserName = obj.FullName,
						NormalizedUserName = obj.FullName.ToUpper(),
						Email = obj.Email,
						NormalizedEmail = obj.Email.ToUpper(),
						PhoneNumber = obj.PhoneNumber,
						EmailConfirmed = true,
						PhoneNumberConfirmed = true,
						LockoutEnabled = false,
						TwoFactorEnabled = false,
					    PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, password)
					};
					_context.Entry(obj).State = EntityState.Added;
				}
				_context.SaveChanges();
				await _userManager.AddToRoleAsync(user, "Client");
			}
			catch (Exception e)
            {
                return false;
            }
			return true;
		}

		/// <summary>
		/// Каскадное удаление клиента из базы 
		/// </summary>
		/// <param name="obj">Объект клиента</param>
		/// <returns></returns>
		public bool DeleteClient(Client obj)
        {
            if(_context.Clients.Any(x => x.Id == obj.Id))
            {
                _context.Entry(_context.Users.FirstOrDefault(x => x.Id == obj.Id.ToString())).State = EntityState.Deleted;
                _context.Entry(obj).State = EntityState.Deleted;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
