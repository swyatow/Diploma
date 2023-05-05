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

        public Client GetClientById(Guid id)
        {
            return _context.Clients.FirstOrDefault(x=>x.Id == id);
        }

        public IEnumerable<Client> GetClients()
        {
            return _context.Clients;
        }

        public void SaveClient(Client obj)
        {
            if (_context.Clients.Any(x => x.Id == obj.Id))
                _context.Entry(obj).State = EntityState.Added;
            else
                _context.Entry(obj).State = EntityState.Modified;

            _context.SaveChanges();
        }

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
