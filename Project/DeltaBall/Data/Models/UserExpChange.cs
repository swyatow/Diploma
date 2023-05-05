﻿using System.ComponentModel.DataAnnotations;

namespace DeltaBall.Data.Models
{
    // История изменения опыта у игроков
    public class UserExpChange
    {
        [Key]
        [Display(Name = "Номер п/п")] 
        public Guid Id { get; set; } = Guid.NewGuid();

        // Может быть отрицательным в зависимости от модификатора
        [Display(Name = "Количество присваиваемого опыта")]
        public int DeltaExp { get; set; }

        [Display(Name = "Дата изменения опытаы")]
        public DateTime ChangeDate { get; set; }

        [Display(Name = "Клиент")]
        public Guid ClientId { get; set; }
        [Display(Name = "Клиент")]
        public Client Client { get; set; }

        [Display(Name = "Причина изменения опыта")]
        public int ChangeModeId { get; set; }
        [Display(Name = "Причина изменения опыта")]
        public UserExpChangeMode ChangeMode { get; set; }
    }
}
