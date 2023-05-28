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
    public class GameScenarioController : Controller
    {
        private readonly DataManager _dataManager;

        public GameScenarioController(DataManager context)
        {
            _dataManager = context;
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Добавление сценария";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] GameScenario gameScenario)
        {
            if (ModelState.IsValid)
            {
                _dataManager.GameScenarios.SaveScenario(gameScenario);
                return RedirectToAction("Info", "Table", new { name = "GameScenarios" }, null);
            }
            ViewData["Title"] = "Добавление сценария";
            return View(gameScenario);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var gameScenario = _dataManager.GameScenarios.GetScenarioById(id);
            if (gameScenario == null)
            {
                return NotFound();
            }
            ViewData["Title"] = "Редактирование сценария";
            return View(gameScenario);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] GameScenario gameScenario)
        {
            if (id != gameScenario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _dataManager.GameScenarios.SaveScenario(gameScenario);
                return RedirectToAction("Info", "Table", new { name = "GameScenarios" }, null);
            }
            ViewData["Title"] = "Редактирование сценария";
            return View(gameScenario);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var gameScenario = _dataManager.GameScenarios.GetScenarioById(id.Value);
            if (gameScenario == null)
            {
                return NotFound();
            }
            ViewData["Title"] = "Удаление клиента";
            return View(gameScenario);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gameScenario = _dataManager.GameScenarios.GetScenarioById(id);
            if (gameScenario != default)
            {
                _dataManager.GameScenarios.DeleteScenario(gameScenario);
            }
            return RedirectToAction("Info", "Table", new { name = "GameScenarios" }, null);
        }
    }
}
