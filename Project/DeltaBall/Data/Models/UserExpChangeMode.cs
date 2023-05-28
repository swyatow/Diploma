using System.ComponentModel.DataAnnotations;

namespace DeltaBall.Data.Models
{
    // Причина изменения опыта игроку
    // (увеличение или уменьшение)
    public class UserExpChangeMode
    {
        [Required]
        [Display(Name = "Номер п/п")]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Название причины")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Описание причины")]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Множитель опыта")]
        public int Multiplier { get; set; }
    }
}
