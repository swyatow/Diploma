using DeltaBall.Data;
using DeltaBall.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeltaBall.Areas.Player.Controllers
{
    [Area("Player")]
    public class HomeController : Controller
    {
        private readonly DataManager _dataManager;

        public HomeController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Profile()
        {
			ViewData["Title"] = "Профиль";
            var userId = Guid.Parse(User.Claims.First().Value);
			ViewData["ScheduledGames"] = _dataManager.ScheduleGames.GetGamesByPlayer(userId);
			ViewData["History"] = _dataManager.UserExpChanges.GetExpChangeByPlayer(userId);
            return View(_dataManager.Clients.GetClientById(userId));
        }

		public VirtualFileResult GetRankImage(int id)
		{
			var rank = _dataManager.Ranks.GetRankById(id);

			if (rank != null)
			{
				return File(rank.ImagePath, "image/" + rank.ImagePath.Split('.')[1]);
			}
			else
			{
				return null;
			}
		}
	}
}
