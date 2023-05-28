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
    public class ShootRangeController : Controller
    {
        private readonly DataManager _dataManager;

        public ShootRangeController(DataManager context)
        {
            _dataManager = context;
        }
        public IActionResult Create()
        {
            ViewData["Title"] = "Создание полигона";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Adress")] ShootRange shootRange)
        {
            if (ModelState.IsValid)
            {
                _dataManager.ShootRanges.SaveRange(shootRange);
                return RedirectToAction("Info", "Table", new { name = "ShootRanges" }, null);
            }
            ViewData["Title"] = "Создание полигона";
            return View(shootRange);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var shootRange = _dataManager.ShootRanges.GetRangeById(id);
            if (shootRange == null)
            {
                return NotFound();
            }
            ViewData["Title"] = "Редактирование полигона";
            return View(shootRange);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Description,Adress")] ShootRange shootRange)
        {
            if (id != shootRange.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _dataManager.ShootRanges.SaveRange(shootRange);
                return RedirectToAction("Info", "Table", new { name = "ShootRanges" }, null);
            }
            ViewData["Title"] = "Редактирование полигона";
            return View(shootRange);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var shootRange = _dataManager.ShootRanges.GetRangeById(id);
            if (shootRange == null)
            {
                return NotFound();
            }
            ViewData["Title"] = "Удаление полигона";
            return View(shootRange);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var shootRange = _dataManager.ShootRanges.GetRangeById(id);
            if (shootRange != null)
            {
                _dataManager.ShootRanges.DeleteRange(shootRange);
            }
            return RedirectToAction("Info", "Table", new { name = "ShootRanges" }, null);
        }
    }
}
