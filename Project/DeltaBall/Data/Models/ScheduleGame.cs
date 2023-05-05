using System.ComponentModel.DataAnnotations;

namespace DeltaBall.Data.Models
{
    // Запланированные игры
    public class ScheduleGame
    {
        [Key]
        [Display(Name = "Номер п/п")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Display(Name = "Название игры")]
        public string Name { get; set; }

        [Display(Name = "Дата начала игры")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Продолжительность")]
        public int Hours { get; set; }

        [Display(Name = "Итоговая сумма")]
        public float Price { get; set; }

        [Display(Name = "Максимальное количество участников")]
        public int MaxPeoples { get; set; }

        [Display(Name = "Полигон")]
        public Guid RangeId { get; set; }
        [Display(Name = "Полигон")]
        public ShootRange Range { get; set; }

        [Display(Name = "Сценарий игры")]
        public int ScenarioId { get; set; }
        [Display(Name = "Сценарий игры")]
        public GameScenario Scenario { get; set; }

        [Display(Name = "Тип игры")]
        public int TypeId { get; set; }
        [Display(Name = "Тип игры")]
        public GameType Type { get; set; }

        [Display(Name = "Статус игры")]
        public int StatusId { get; set; }

        [Display(Name = "Статус игры")]
        public GameStatus Status { get; set; }
    }
}
