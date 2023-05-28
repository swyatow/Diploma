using System.ComponentModel.DataAnnotations;

namespace DeltaBall.Data.Models
{
    // Запланированные игры
    public class ScheduleGame
    {
        [Key]
        [Display(Name = "Номер п/п")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Название игры")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Дата начала игры")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "Продолжительность игры (ч)")]
        public int Hours { get; set; }

        [Required]
        [Display(Name = "Полная цена для 1 человека")]
        public float Price { get; set; }

        [Required]
        [Display(Name = "Максимальное количество участников")]
        public int MaxPeoples { get; set; }

        [Required]
        [Display(Name = "Полигон")]
        public Guid RangeId { get; set; }
        [Display(Name = "Полигон")]
        public ShootRange Range { get; set; }

        [Required]
        [Display(Name = "Сценарий игры")]
        public int ScenarioId { get; set; }
        [Display(Name = "Сценарий игры")]
        public GameScenario Scenario { get; set; }

        [Required]
        [Display(Name = "Тип игры")]
        public int TypeId { get; set; }
        [Display(Name = "Тип игры")]
        public GameType Type { get; set; }

        [Required]
        [Display(Name = "Статус игры")]
        public int StatusId { get; set; }

        [Display(Name = "Статус игры")]
        public GameStatus Status { get; set; }
    }
}
