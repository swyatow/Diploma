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
    public class GameStatusController : Controller
    {
        private readonly DataManager _dataManager;

        public GameStatusController(DataManager context)
        {
            _dataManager = context;
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Создание статуса игры";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] GameStatus gameStatus)
        {
            if (ModelState.IsValid)
            {
                _dataManager.GameStatuses.SaveStatus(gameStatus);
                return RedirectToAction("Info", "Table", new { name = "GameStatuses" }, null);
            }
            ViewData["Title"] = "Создание статуса игры";
            return View(gameStatus);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var gameStatus = _dataManager.GameStatuses.GetStatusById(id);
            if (gameStatus == null)
            {
                return NotFound();
            }
            ViewData["Title"] = "Редактирование статуса игры";
            return View(gameStatus);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] GameStatus gameStatus)
        {

            if (id != gameStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _dataManager.GameStatuses.SaveStatus(gameStatus);
                return RedirectToAction("Info", "Table", new { name = "GameStatuses" }, null);
            }
            ViewData["Title"] = "Редактирование статуса игры";
            return View(gameStatus);
        }
    }
}
