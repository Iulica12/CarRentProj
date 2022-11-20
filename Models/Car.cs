﻿using System.ComponentModel.DataAnnotations;

namespace CarRentProj.Models
{
    public class Car
    {
        public int Id { get; set; }
        [Required]
        [Range(1990, 2022)]
        public int Year { get; set; }
        [StringLength(150, ErrorMessage = "Name is too long")]
        public string Model { get ; set ; }
        public int? MakeId { get; set; }
        public virtual Make? Make { get; set; }
    }
}
