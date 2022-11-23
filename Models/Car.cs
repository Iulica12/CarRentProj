using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarRentProj.Models
{
    public class Car : BaseDomainEntity
    {
        [DisplayName("Manufacture Year")]
        [Required]
        [Range(1990, 2022)]
        public int Year { get; set; }

        [DisplayName("License Plate Number")]
        [Required]
        [StringLength(10)]
        public string LicensePlateNumber { get; set; }

        [DisplayName("Make")]
        public int? MakeId { get; set; }
        public virtual Make? Make { get; set; }

        [DisplayName("Colour")]
        public int? ColourId { get; set; }
        public virtual Colour? Colour { get; set; }

        [DisplayName("Model")]
        public int? CarModelId { get; set; }
        public virtual CarModel? CarModel { get; set; }

    }
}
