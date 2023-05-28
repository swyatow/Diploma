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
    public class UserExpChangeModeController : Controller
    {
        private readonly DataManager _dataManager;

        public UserExpChangeModeController(DataManager context)
        {
            _dataManager = context;
        }
        public IActionResult Create()
        {
            ViewData["Title"] = "Создание режима изменения опыта";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Multiplier")] UserExpChangeMode userExpChangeMode)
        {
            if (ModelState.IsValid)
            {
                _dataManager.UserExpChangeModes.SaveChangeMode(userExpChangeMode);
                return RedirectToAction("Info", "Table", new { name = "UserExpChangeModes" }, null);
            }
            ViewData["Title"] = "Создание режима изменения опыта";
            return View(userExpChangeMode);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var userExpChangeMode = _dataManager.UserExpChangeModes.GetChangeModeById(id);
            if (userExpChangeMode == null)
            {
                return NotFound();
            }
            ViewData["Title"] = "Редактирование режима изменения опыта";
            return View(userExpChangeMode);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Multiplier")] UserExpChangeMode userExpChangeMode)
        {
            if (id != userExpChangeMode.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _dataManager.UserExpChangeModes.SaveChangeMode(userExpChangeMode);
                return RedirectToAction("Info", "Table", new { name = "UserExpChangeModes" }, null);
            }
            ViewData["Title"] = "Редактирование режима изменения опыта";
            return View(userExpChangeMode);
        }
        
        public async Task<IActionResult> Delete(int id)
        {
            var userExpChangeMode = _dataManager.UserExpChangeModes.GetChangeModeById(id);
            if (userExpChangeMode == null)
            {
                return NotFound();
            }
            ViewData["Title"] = "Удаление режима изменения опыта";
            return View(userExpChangeMode);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userExpChangeMode = _dataManager.UserExpChangeModes.GetChangeModeById(id);
            if (userExpChangeMode != null)
            {
                _dataManager.UserExpChangeModes.DeleteChangeMode(userExpChangeMode);
            }
            return RedirectToAction("Info", "Table", new { name = "UserExpChangeModes" }, null);
        }
    }
}
