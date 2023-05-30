using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeltaBall.Data;
using DeltaBall.Data.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DeltaBall.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ClientController : Controller
    {
        private readonly DataManager _dataManager;

        public ClientController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }        

        public IActionResult Create()
        {
            ViewData["Title"] = "Добавление клиента";
            ViewData["RankId"] = new SelectList(
                _dataManager.Ranks.GetRanks(), 
                nameof(Client.Rank.Id), 
                nameof(Client.Rank.Name), 
                _dataManager.Ranks.GetRankById(1));
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,FullName,PhoneNumber,Email,Experience,RankId")] Client client)
        {
            ModelState.ClearValidationState("Rank");
            ModelState.MarkFieldValid("Rank");
            if (ModelState.IsValid)
            {
                await _dataManager.Clients.SaveClientAsync(client, client.Email);
                return RedirectToAction("Info", "Table", new { name = "Clients" }, null);
            }
            ViewData["RankId"] = new SelectList(_dataManager.Ranks.GetRanks(), nameof(Client.Rank.Id), nameof(Client.Rank.Name));
            ViewData["Title"] = "Добавление клиента";
            return View(client);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var client = _dataManager.Clients.GetClientById(id);
            if (client == default)
            {
                return NotFound();
            }
            ViewData["RankId"] = new SelectList(_dataManager.Ranks.GetRanks(), nameof(Client.Rank.Id), nameof(Client.Rank.Name));
            ViewData["Title"] = "Редактирование клиента";
            return View(client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Guid id, [Bind("Id,FullName,PhoneNumber,Email,Experience,RankId")] Client client)
        {
            if (id != client.Id)
            {
                return NotFound();
            }
            ModelState.ClearValidationState("Rank");
            ModelState.MarkFieldValid("Rank");
            if (ModelState.IsValid)
            {
                await _dataManager.Clients.SaveClientAsync(client, null);
                return RedirectToAction("Info", "Table", new {name = "Clients"}, null);
            }
            ViewData["Title"] = "Редактирование клиента";
            ViewData["RankId"] = new SelectList(_dataManager.Ranks.GetRanks(), nameof(Client.Rank.Id), nameof(Client.Rank.Name));
            return View(client);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var client = _dataManager.Clients.GetClientById(id);
            if (client == null)
            {
                return NotFound();
            }
            ViewData["Title"] = "Удаление клиента";
            return View(client);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var client = _dataManager.Clients.GetClientById(id);
            if (client != default)
            {
                _dataManager.Clients.DeleteClient(client);
            }
            return RedirectToAction("Info", "Table", new { name = "Clients" }, null);
        }
    }
}
