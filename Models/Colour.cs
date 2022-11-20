using System.ComponentModel;

namespace CarRentProj.Models
{
    public class Colour : BaseDomainEntity
    {
        [DisplayName("Colour")]
        public string Name { get; set; }

        public virtual List<Car>? Car { get; set; }
    }
}
