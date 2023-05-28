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
    public class PriceController : Controller
    {
        private readonly DataManager _dataManager;

        public PriceController(DataManager context)
        {
            _dataManager = context;
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Создание цены";
            ViewData["GameTypeId"] = new SelectList(_dataManager.GameTypes.GetTypes(), nameof(GameType.Id), nameof(GameType.Name));
            ViewData["GameScenarioId"] = new SelectList(_dataManager.GameScenarios.GetScenarios(), nameof(GameScenario.Id), nameof(GameScenario.Name));
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Value,ScenarioId,GameTypeId")] Price price)
        {
            ModelState.ClearValidationState("Scenario");
            ModelState.MarkFieldValid("Scenario");
            ModelState.ClearValidationState("GameType");
            ModelState.MarkFieldValid("GameType");
            if (ModelState.IsValid)
            {
                _dataManager.Prices.SavePrice(price);
                return RedirectToAction("Info", "Table", new { name = "Prices" }, null);
            }
            ViewData["Title"] = "Создание цены";
            ViewData["GameTypeId"] = new SelectList(_dataManager.GameTypes.GetTypes(), nameof(GameType.Id), nameof(GameType.Name));
            ViewData["GameScenarioId"] = new SelectList(_dataManager.GameScenarios.GetScenarios(), nameof(GameScenario.Id), nameof(GameScenario.Name));
            return View(price);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var price = _dataManager.Prices.GetPriceById(id);
            if (price == null)
            {
                return NotFound();
            }
            ViewData["Title"] = "Редактирование цены";
            ViewData["GameTypeId"] = new SelectList(_dataManager.GameTypes.GetTypes(), nameof(GameType.Id), nameof(GameType.Name));
            ViewData["GameScenarioId"] = new SelectList(_dataManager.GameScenarios.GetScenarios(), nameof(GameScenario.Id), nameof(GameScenario.Name));
            return View(price);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Value,ScenarioId,GameTypeId")] Price price)
        {
            if (id != price.Id)
            {
                return NotFound();
            }
            ModelState.ClearValidationState("Scenario");
            ModelState.MarkFieldValid("Scenario");
            ModelState.ClearValidationState("GameType");
            ModelState.MarkFieldValid("GameType");
            if (ModelState.IsValid)
            {
                _dataManager.Prices.SavePrice(price);
                return RedirectToAction("Info", "Table", new { name = "Prices" }, null);
            }
            ViewData["Title"] = "Редактирование цены";
            ViewData["GameTypeId"] = new SelectList(_dataManager.GameTypes.GetTypes(), nameof(GameType.Id), nameof(GameType.Name));
            ViewData["GameScenarioId"] = new SelectList(_dataManager.GameScenarios.GetScenarios(), nameof(GameScenario.Id), nameof(GameScenario.Name));
            return View(price);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var price = _dataManager.Prices.GetPriceById(id);
            if (price == null)
            {
                return NotFound();
            }
            ViewData["Title"] = "Удаление цены";
            return View(price);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var price = _dataManager.Prices.GetPriceById(id);
            if (price != null)
            {
                _dataManager.Prices.DeletePrice(price);
            }
            return RedirectToAction("Info", "Table", new { name = "Prices" }, null);
        }
    }
}
