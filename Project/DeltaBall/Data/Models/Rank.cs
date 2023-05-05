using System.ComponentModel.DataAnnotations;

namespace DeltaBall.Data.Models
{
    public class Rank
    {
        [Required]
        [Display(Name = "Номер п/п")]
        public int Id { get; set; }

        [Display(Name = "Название ранга")]
        public string Name { get; set; }

        [Display(Name = "Минимальное количество опыта для получения ранга")]
        public int MinExp { get; set; }

        [Display(Name = "Максимальное количество опыта для данного ранга")]
        public int MaxExp { get; set; }

        [Display(Name = "Скидка для данного ранга в процентах на одну игру")]
        public int Discount { get; set; }

        // Выбирается через OpenFileDialog или аналогичный
        // Если нет берется дефолтная
        [Display(Name = "Картинка для данного ранга")]
        public string ImagePath { get; set; }
    }
}
