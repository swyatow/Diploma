using System.ComponentModel.DataAnnotations;

namespace DeltaBall.Data.Models
{
    // Полигоны/площадки для проведения игр
    public class ShootRange
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Номер п/п")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Название полигона")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Описание полигона")]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Адрес")]
        public string Adress { get; set; }
    }
}
