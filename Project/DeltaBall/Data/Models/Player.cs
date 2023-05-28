using System.ComponentModel.DataAnnotations;

namespace DeltaBall.Data.Models
{
    // Связь клиентов с играми, на которые они записаны
    public class Player
    {
        [Key]
        [Display(Name = "Номер п/п")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [Display(Name = "Запланированная игра")]
        public Guid GameId { get; set; }
        [Display(Name = "Запланированная игра")]
        public ScheduleGame Game { get; set; }

        [Required]
        [Display(Name = "Игрок")]
        public Guid ClientId { get; set; }
        [Display(Name = "Игрок")]
        public Client Client { get; set; }

        [Required]
        [Display(Name = "Создатель игры")]
        public bool IsCreator { get; set; }

        [Required]
        [Display(Name = "Цена для данного игрока")]
        public double Price { get; set; }
    }
}
