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
    public class UserExpChangeController : Controller
    {
        private readonly DataManager _dataManager;

        public UserExpChangeController(DataManager context)
        {
            _dataManager = context;
        }

        public IActionResult Info()
        {
            return View(_dataManager.UserExpChanges.GetExpChanges());
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var userExpChange = _dataManager.UserExpChanges.GetExpChangeById(id);
            if (userExpChange == null)
            {
                return NotFound();
            }

            return View(userExpChange);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
			var userExpChange = _dataManager.UserExpChanges.GetExpChangeById(id);
			if (userExpChange != null)
            {
                _dataManager.UserExpChanges.DeleteExpChange(userExpChange);
            }

			return RedirectToAction("Table", "UserExpChange");
		}
    }
}
