using DeltaBall.Data;
using DeltaBall.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DeltaBall.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataManager _dataManager;

        public HomeController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Index()
        {
            ViewData["Scenarios"] = _dataManager.GameScenarios.GetScenarios();
            ViewData["Types"] = _dataManager.GameTypes.GetTypes();
            return View(_dataManager.ShootRanges.GetRanges());
        }
    }
}