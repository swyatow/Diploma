using DeltaBall.Data;
using DeltaBall.Areas.Admin.Models;
using DeltaBall.Services.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace DeltaBall.Areas.Admin.Controllers
{
    [Area("admin")]
    public class TableController : Controller
    {
        private readonly DataManager _dataManager;

        public TableController(DataManager dataManager) 
            => _dataManager = dataManager;

        public ActionResult Info(string name)
        {
            string className = name.Remove(name.Length - 1);
            if(className == "GameStatuse")
                className = className.Remove(className.Length - 1);
            Type classType = Type.GetType("DeltaBall.Data.Models." + className);
            var property = _dataManager.GetType().GetProperty(name);
            ViewData["Title"] = AttributeHelper.GetDisplayNameValue(property);
            var repo = property.GetValue(_dataManager);
            var method = repo.GetType().GetMethods().Skip(1).First();
            var rawResult = (IList)method.Invoke(repo, null);
            var result = new TableViewModel()
            {
                Items = new ArrayList(rawResult),
                Type = classType
			};
            return View(result);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
