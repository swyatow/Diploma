using DeltaBall.Data.Repositories.Interfaces;

namespace DeltaBall.Data
{
    public class DataManager
    {
        public IClientRepo Clients { get; set; }
        public IGameScenarioRepo GameScenarios { get; set; }
        public IGameTypeRepo GameTypes { get; set; }
        public IGameStatusRepo GameStatuses { get; set; }
        public IPlayerRepo Players { get; set; }
        public IPriceRepo Prices { get; set; }
        public IRankRepo Ranks { get; set; }
        public IScheduleGameRepo ScheduleGames { get; set; }
        public IShootRangeRepo ShootRanges { get; set; }
        public IUserExpChangeRepo UserExpChanges { get; set; }
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
