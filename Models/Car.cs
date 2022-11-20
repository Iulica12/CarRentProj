using System.ComponentModel.DataAnnotations;

namespace CarRentProj.Models
{
    public class Car : BaseDomainEntity
    {
        [Required]
        [Range(1990, 2022)]
        public int Year { get; set; }

        [Required]
        [StringLength(10)]
        public string LicensePlateNumber { get; set; }

        public int? MakeId { get; set; }
        public virtual Make? Make { get; set; }

        public int? ColourId { get; set; }
        public virtual Colour? Colour { get; set; }

        public int? CarModelId { get; set; }
        public virtual CarModel? CarModel { get; set; }

    }
}
