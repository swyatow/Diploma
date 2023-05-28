using System.ComponentModel.DataAnnotations;

namespace DeltaBall.Data.Models
{
    //Цены на разные виды игр для 1 человека
    public class Price
    {
        [Key]
        [Display(Name = "Номер п/п")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Цена для одного человека")]
        public int Value { get; set; }

        [Required]
        [Display(Name = "Сценарий")]
        public int ScenarioId { get; set; }
        [Display(Name = "Сценарий")]
        public GameScenario Scenario { get; set; }

        [Required]
        [Display(Name = "Режим игры")]
        public int GameTypeId { get; set; }
        [Display(Name = "Режим игры")]
        public GameType GameType { get; set; }
    }
}
