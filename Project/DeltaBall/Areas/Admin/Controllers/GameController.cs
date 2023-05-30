using DeltaBall.Data;
using DeltaBall.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DeltaBall.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class GameController : Controller
	{
		private readonly DataManager _dataManager;

		public GameController(DataManager dataManager)
		{
			_dataManager = dataManager;
		}

		public IActionResult Info()
		{
			ViewData["Title"] = "Таблица игр";
			return View(_dataManager.ScheduleGames.GetGames());
		}

		public IActionResult Create()
		{
			ViewData["Title"] = "Добавление игры";
			ViewData["RangeId"] = new SelectList(_dataManager.ShootRanges.GetRanges(), nameof(ShootRange.Id), nameof(ShootRange.Name));
			ViewData["ScenarioId"] = new SelectList(_dataManager.GameScenarios.GetScenarios(), nameof(GameScenario.Id), nameof(GameScenario.Name));
			ViewData["TypeId"] = new SelectList(_dataManager.GameTypes.GetTypes(), nameof(GameType.Id), nameof(GameType.Name));
			ViewData["StatusId"] = new SelectList(_dataManager.GameStatuses.GetStatuses(), nameof(GameStatus.Id), nameof(GameStatus.Name));
			ViewData["ClientId"] = new SelectList(_dataManager.Clients.GetClients(), nameof(Client.Id), nameof(Client.FullName));
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create([Bind("Name,StartDate,Hours,MaxPeoples,RangeId,ScenarioId,TypeId")] ScheduleGame game, Guid clientId)
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
				_dataManager.ScheduleGames.CreateGame(game, clientId);
				return RedirectToAction("Info", "Game");
			}
			ViewData["Title"] = "Добавление игры";
			ViewData["RangeId"] = new SelectList(_dataManager.ShootRanges.GetRanges(), nameof(ShootRange.Id), nameof(ShootRange.Name));
			ViewData["ScenarioId"] = new SelectList(_dataManager.GameScenarios.GetScenarios(), nameof(GameScenario.Id), nameof(GameScenario.Name));
			ViewData["TypeId"] = new SelectList(_dataManager.GameTypes.GetTypes(), nameof(GameType.Id), nameof(GameType.Name));
			ViewData["StatusId"] = new SelectList(_dataManager.GameStatuses.GetStatuses(), nameof(GameStatus.Id), nameof(GameStatus.Name));
			ViewData["ClientId"] = new SelectList(_dataManager.Clients.GetClients(), nameof(Client.Id), nameof(Client.FullName));
			return View(game);
		}

        public IActionResult Edit(Guid id)
        {
			var players = _dataManager.Players.GetPlayersForGame(id);
			var game =_dataManager.ScheduleGames.GetGameById(id);
			ViewData["Title"] = "Просмотр игры";
			ViewData["Players"] = players;
			ViewData["PeoplesCount"] = players.Count();
            ViewData["StatusId"] = new SelectList(_dataManager.GameStatuses.GetStatuses(), nameof(GameStatus.Id), nameof(GameStatus.Name), game.StatusId);
            return View(game);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid gameId, int statusId)
        {
			var game = _dataManager.ScheduleGames.GetGameById(gameId);
			if (game == null) return NotFound();
			game.StatusId = statusId;
			_dataManager.ScheduleGames.SaveGame(game);
			if (game.StatusId == 6)
			{
				foreach (var player in _dataManager.Players.GetPlayersForGame(gameId))
				{
					UserExpChange newExp = new()
					{
						ChangeModeId = 5,
						ChangeDate = DateTime.Now,
						ClientId = player.ClientId
					};
					_dataManager.UserExpChanges.SaveExpChange(newExp);
				}
			}
			return RedirectToAction("Info", "Game");
        }
    }
}
