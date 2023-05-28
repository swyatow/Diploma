using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DeltaBall.Data.Models
{
    public class Client
    {
        [Key]
        [Display(Name = "Номер п/п")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Фамилия Имя Отчество")]
        public string FullName { get; set; }

        [RegularExpression(@"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{9,9}$",
                   ErrorMessage = "Введеный номер телефона не подходит Правильная форма: 8(123)456-78-90.")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Адрес электронной почты")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Опыт игрока")]
        public int Experience { get; set; }

        [Display(Name = "Ранг игрока")]
        public int RankId { get; set; }
        public Rank Rank { get; set; }
    }
}
