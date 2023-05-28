using System.ComponentModel.DataAnnotations;

namespace DeltaBall.Data.Models
{
    //Статус игры
    public class GameStatus
    {
        [Required]
        [Display(Name = "Номер п/п")]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Название статуса")]
        public string Name { get; set; }
    }
}
