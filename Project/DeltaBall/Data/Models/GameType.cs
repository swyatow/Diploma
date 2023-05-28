using System.ComponentModel.DataAnnotations;

namespace DeltaBall.Data.Models
{
    // Тип игры (используемого оружия для игры)
    public class GameType
    {
        [Required]
        [Display(Name = "Номер п/п")]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Название режима игры")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Отличительные особенности")]
        public string Description { get; set; }
    }
}
