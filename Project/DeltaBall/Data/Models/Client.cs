using System.ComponentModel.DataAnnotations;

namespace DeltaBall.Data.Models
{
    public class Client
    {
        [Key]
        [Display(Name = "Номер п/п")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Display(Name = "ФИО")]
        public string FullName { get; set; }

        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Адрес электронной почты")]
        public string Email { get; set; }

        [Display(Name = "Опыт игрока")]
        public int Experience { get; set; }

        [Display(Name = "Ранг игрока")]
        public int RankId { get; set; }
        [Display(Name = "Ранг игрока")]
        public Rank Rank { get; set; }
    }
}
