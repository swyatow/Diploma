using DeltaBall.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DeltaBall.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}