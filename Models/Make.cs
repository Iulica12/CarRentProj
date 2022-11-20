using System.ComponentModel;

namespace CarRentProj.Models
{
    public class Make
    {
        public int Id { get; set; }
        [DisplayName("Name")]
        public string MakeName { get; set; }
        public virtual List<Car>? Car { get; set; }
    }
}
