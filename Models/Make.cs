using System.ComponentModel;

namespace CarRentProj.Models
{
    public class Make : BaseDomainEntity
    {
        [DisplayName("Make")]
        public string MakeName { get; set; }

        public virtual List<Car>? Car { get; set; }
        public virtual List<CarModel>? CarModels { get; set; }
    }
}
