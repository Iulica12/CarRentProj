using System.ComponentModel;

namespace CarRentProj.Models
{
    public class CarModel :BaseDomainEntity
    {
        [DisplayName("Model")]
        public string Name { get; set; }

        [DisplayName("Make")]
        public int? MakeId { get; set; }
        public virtual Make? Make { get; set; }
        public virtual List<Car>? Car { get; set; }
    }
}
