using System.ComponentModel.DataAnnotations;

namespace DeltaBall.Data.Models
{
    // Полигоны/площадки для проведения игр
    public class ShootRange
    {
        [Required]
        [Display(Name = "Номер п/п")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Display(Name = "Название полигона")]
        public string Name { get; set; }

        [Display(Name = "Описание полигона")]
        public string Description { get; set; }

        [Display(Name = "Адрес")]
        public string Adress { get; set; }
    }
}
