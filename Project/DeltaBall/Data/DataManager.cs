using DeltaBall.Data.Repositories.Interfaces;
using System.ComponentModel;

namespace DeltaBall.Data
{
    public class DataManager
    {
        [DisplayName("Таблица клиентов")]
        public IClientRepo Clients { get; set; }
		[DisplayName("Таблица сценариев игры")]
		public IGameScenarioRepo GameScenarios { get; set; }
		[DisplayName("Таблица типов игры")]
		public IGameTypeRepo GameTypes { get; set; }
		[DisplayName("Таблица статусов игры")]
		public IGameStatusRepo GameStatuses { get; set; }
		[DisplayName("Таблица игроков")]
		public IPlayerRepo Players { get; set; }
		[DisplayName("Таблица цен")]
		public IPriceRepo Prices { get; set; }
		[DisplayName("Таблица рангов")]
		public IRankRepo Ranks { get; set; }
		[DisplayName("Таблица запланированных игр")]
		public IScheduleGameRepo ScheduleGames { get; set; }
		[DisplayName("Таблица полигонов")]
		public IShootRangeRepo ShootRanges { get; set; }
		[DisplayName("Таблица истории изменения опыта игроков")]
		public IUserExpChangeRepo UserExpChanges { get; set; }
		[DisplayName("Таблица режимов изменения опыта игроков")]
		public IUserExpChangeModeRepo UserExpChangeModes { get; set; }

        public DataManager(IClientRepo clients, IGameScenarioRepo gameScenarios, IGameTypeRepo gameTypes, IGameStatusRepo gameStatuses, IPlayerRepo players, IPriceRepo prices, IRankRepo ranks, IScheduleGameRepo scheduleGames, IShootRangeRepo shootRanges, IUserExpChangeRepo userExpChanges, IUserExpChangeModeRepo userExpChangeModes)
        {
            Clients = clients;
            GameScenarios = gameScenarios;
            GameTypes = gameTypes;
            GameStatuses = gameStatuses;
            Players = players;
            Prices = prices;
            Ranks = ranks;
            ScheduleGames = scheduleGames;
            ShootRanges = shootRanges;
            UserExpChanges = userExpChanges;
            UserExpChangeModes = userExpChangeModes;
        }
    }
}
