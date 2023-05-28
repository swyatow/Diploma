using DeltaBall.Data;
using DeltaBall.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace DeltaBall.Areas.Player.Controllers
{
	[Area("Player")]
	public class GameController : Controller
	{
		private readonly DataManager _dataManager;

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
				_dataManager.ScheduleGames.SaveGame(game, Guid.Parse(User.Claims.First().Value));
				return RedirectToAction("Info", "Game", new {id = game.Id.ToString()});
			}
			ViewData["RangeId"] = new SelectList(_dataManager.ShootRanges.GetRanges(), nameof(ScheduleGame.Range.Id), nameof(ScheduleGame.Range.Name));
			ViewData["TypeId"] = new SelectList(_dataManager.GameTypes.GetTypes(), nameof(ScheduleGame.Type.Id), nameof(ScheduleGame.Type.Name));
			ViewData["ScenarioId"] = new SelectList(_dataManager.GameScenarios.GetScenarios(), nameof(ScheduleGame.Scenario.Id), nameof(ScheduleGame.Scenario.Name));
			ViewData["Title"] = "Создание игры";
			return View(game);
		}

		public IActionResult Info(Guid id)
		{
			var game = _dataManager.ScheduleGames.GetGameById(id);
			if (game == null)
				return NotFound();
			ViewData["PeoplesCount"] = _dataManager.Players.GetPlayersForGame(id).Count();
			ViewData["Title"] = "Информация об игре";
			return View(game);
		}

		public IActionResult Invite(Guid id)
		{
			ViewData["Title"] = "Приглашение";
			return View();
		}
	}
}
