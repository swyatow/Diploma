using Microsoft.AspNetCore.Mvc;

namespace DeltaBall.Areas.Player.Controllers
{
    [Area("Player")]
    public class HomeController : Controller
    {
        public IActionResult Profile()
        {
            return View();
        }
    }
}
