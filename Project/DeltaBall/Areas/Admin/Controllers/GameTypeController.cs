using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeltaBall.Data;
using DeltaBall.Data.Models;

namespace DeltaBall.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GameTypeController : Controller
    {
        private readonly DataManager _dataManager;

        public GameTypeController(DataManager context)
        {
            _dataManager = context;
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Создание режима игры";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] GameType gameType)
        {
            if (ModelState.IsValid)
            {
                _dataManager.GameTypes.SaveType(gameType);
                return RedirectToAction("Info", "Table", new { name = "GameTypes" }, null);
            }
            ViewData["Title"] = "Создание режима игры";
            return View(gameType);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var gameType = _dataManager.GameTypes.GetTypeById(id);
            if (gameType == null)
            {
                return NotFound();
            }
            ViewData["Title"] = "Редактирование режима игры";
            return View(gameType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] GameType gameType)
        {
            if (id != gameType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _dataManager.GameTypes.SaveType(gameType);
                return RedirectToAction("Info", "Table", new { name = "GameTypes" }, null);
            }
            ViewData["Title"] = "Редактирование режима игры";
            return View(gameType);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var gameType = _dataManager.GameTypes.GetTypeById(id);
            if (gameType == null)
            {
                return NotFound();
            }
            ViewData["Title"] = "Удаление режима игры";
            return View(gameType);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gameType = _dataManager.GameTypes.GetTypeById(id);
            if (gameType != null)
            {
                _dataManager.GameTypes.DeleteType(gameType);
            }
            return RedirectToAction("Info", "Table", new { name = "GameTypes" }, null);
        }
    }
}
