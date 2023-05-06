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
        public ClientRepo(AppDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Получить клиента по его ID
        /// </summary>
        /// <param name="id">Guid клиента</param>
        /// <returns></returns>
        public Client GetClientById(Guid id)
        {
            return _context.Clients.FirstOrDefault(x=>x.Id == id);
        }

        /// <summary>
        /// Получить список всех клиентов
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Client> GetClients()
        {
            return _context.Clients;
        }

        /// <summary>
        /// Создать нового или изменить существующего клиента
        /// </summary>
        /// <param name="obj">Объект клиента</param>
        public void SaveClient(Client obj)
        {
            if (_context.Clients.Any(x => x.Id == obj.Id))
                _context.Entry(obj).State = EntityState.Modified;
            else
                _context.Entry(obj).State = EntityState.Added;

            _context.SaveChanges();
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
                _context.Entry(obj).State = EntityState.Deleted;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
