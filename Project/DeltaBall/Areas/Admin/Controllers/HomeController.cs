using DeltaBall.Data;
using DeltaBall.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;

namespace DeltaBall.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly DataManager _dataManager;

        public HomeController(DataManager dataManager)
            => _dataManager = dataManager;
        public IActionResult Index()
        {            
            return View();
        }
    }
}
