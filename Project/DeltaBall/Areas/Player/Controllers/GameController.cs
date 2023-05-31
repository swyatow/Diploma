using DeltaBall.Data;
using DeltaBall.Data.Models;
using DeltaBall.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Data;

namespace DeltaBall.Areas.Player.Controllers
{
	[Area("Player")]
	public class GameController : Controller
	{
		private readonly DataManager _dataManager;
		private double newPrice;

		public GameController(DataManager dataManager)
		{
			_dataManager = dataManager;
		}

		public IActionResult Create()
		{	
			ViewData["RangeId"] = new SelectList(_dataManager.ShootRanges.GetRanges(), nameof(ScheduleGame.Range.Id), nameof(ScheduleGame.Range.Name));
			ViewData["TypeId"] = new SelectList(_dataManager.GameTypes.GetTypes(), nameof(GameType.Id), nameof(GameType.Name));
			ViewData["ScenarioId"] = new SelectList(_dataManager.GameScenarios.GetScenarios(), nameof(ScheduleGame.Scenario.Id), nameof(ScheduleGame.Scenario.Name));

			ViewData["Title"] = "Создание игры";
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create([Bind("Name,StartDate,Hours,MaxPeoples,RangeId,ScenarioId,TypeId")] ScheduleGame game) 
		{
			#region Очистка неправильной валидации модели
			ModelState.ClearValidationState("Range");
			ModelState.MarkFieldValid("Range");
			ModelState.ClearValidationState("Scenario");
			ModelState.MarkFieldValid("Scenario");
			ModelState.ClearValidationState("Type");
			ModelState.MarkFieldValid("Type");
			ModelState.ClearValidationState("Status");
			ModelState.MarkFieldValid("Status");
			#endregion
			if (ModelState.IsValid)
			{
				_dataManager.ScheduleGames.CreateGame(game, Guid.Parse(User.Claims.First().Value));
				return RedirectToAction("Info", "Game", new {id = game.Id.ToString(), isEnded = "false"});
			}
			ViewData["RangeId"] = new SelectList(_dataManager.ShootRanges.GetRanges(), nameof(ScheduleGame.Range.Id), nameof(ScheduleGame.Range.Name));
			ViewData["TypeId"] = new SelectList(_dataManager.GameTypes.GetTypes(), nameof(ScheduleGame.Type.Id), nameof(ScheduleGame.Type.Name));
			ViewData["ScenarioId"] = new SelectList(_dataManager.GameScenarios.GetScenarios(), nameof(ScheduleGame.Scenario.Id), nameof(ScheduleGame.Scenario.Name));
			ViewData["Title"] = "Создание игры";
			return View(game);
		}

		public IActionResult Info(string isEnded, Guid id)
		{
			var game = _dataManager.ScheduleGames.GetGameById(id);
			if (game == null)
				return NotFound();
			ViewData["IsEnded"] = isEnded;
			ViewData["PeoplesCount"] = _dataManager.Players.GetPlayersForGame(id).Count();
			ViewData["Player"] = _dataManager.Players.GetPlayersForGame(id).FirstOrDefault(x => x.ClientId == Guid.Parse(User.Claims.First().Value));
			ViewData["Client"] = _dataManager.Clients.GetClientById(Guid.Parse(User.Claims.First().Value));
			ViewData["Title"] = "Информация об игре";
			return View(game);
		}

		public IActionResult Invite(Guid id)
		{
			var players = _dataManager.Players.GetPlayersForGame(id);
			var client = _dataManager.Clients.GetClientById(Guid.Parse(User.Claims.First().Value));
			var curPlayer = players.FirstOrDefault(x=>x.ClientId == Guid.Parse(User.Claims.First().Value));
			var game = _dataManager.ScheduleGames.GetGameById(id);
			if (curPlayer != default)
			{
				return RedirectToAction("Already");
			} 
			else if (players.Count() == game.MaxPeoples)
			{
				return RedirectToAction("Full");
			}
			else if (game.StatusId != 4)
			{
				return RedirectToAction("Ended");
			}
			ViewData["Client"] = client;
			ViewData["Title"] = "Вас пригласили на игру "+ game.Name;
			newPrice = Math.Round(game.Price * ((double)(100 - client.Rank.Discount) / 100), 1);
			ViewData["Price"] = newPrice;
			ViewData["PeoplesCount"] = players.Count();
			return View(game);
		}

		[HttpPost,ActionName("Invite")]
		public IActionResult InviteConfirmed([Bind("GameId,Price")] Data.Models.Player newPlayer)
		{
			newPlayer.ClientId = Guid.Parse(User.Claims.First().Value);
			newPlayer.IsCreator = false;
			_dataManager.Players.SavePlayer(newPlayer);
			return RedirectToAction("Profile", "Home");
		}

		public IActionResult Already() => View();

		public IActionResult Full() => View();

		public IActionResult Ended() => View();
	}
}
