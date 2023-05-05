﻿using System.ComponentModel.DataAnnotations;

namespace DeltaBall.Data.Models
{
    //Сценарий игры
    public class GameScenario
    {
        [Key]
        [Display(Name = "Номер п/п")]
        public int Id { get; set; }

        [Display(Name = "Название сценария")]
        public string Name { get; set; }

        [Display(Name = "Краткое описание сценария")]
        public string Description { get; set; }
    }
}
