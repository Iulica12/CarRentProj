namespace CarRentProj.Models
{
    public class Make
    {
        public int Id { get; set; }
        public string MakeName { get; set; }
        public virtual List<Car>? Cars { get; set; }
    }
}
