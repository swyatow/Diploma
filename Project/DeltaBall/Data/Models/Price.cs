using System.ComponentModel.DataAnnotations;

namespace DeltaBall.Data.Models
{
    //Цены на разные виды игр для 1 человека
    public class Price
    {
        [Key]
        [Display(Name = "Номер п/п")]
        public int Id { get; set; }

        [Display(Name = "Цена для одного человека")]
        public int Value { get; set; }

        [Display(Name = "Сценарий")]
        public int ScenarioId { get; set; }
        [Display(Name = "Сценарий")]
        public GameScenario GameScenario { get; set; }

        [Display(Name = "Тип игры")]
        public int GameTypeId { get; set; }
        [Display(Name = "Тип игры")]
        public GameType GameType { get; set; }
    }
}
