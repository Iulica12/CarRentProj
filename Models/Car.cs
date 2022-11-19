using System.ComponentModel.DataAnnotations;

namespace CarRentProj.Models
{
    public class Car
    {
        public int Id { get; set; }
        public int Year { get; set; }
        [Required]
        [StringLength(150,ErrorMessage = "Name is too long")]
        public string Name { get; set; }
    }
}
