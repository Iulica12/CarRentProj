using System.ComponentModel.DataAnnotations;

namespace CarRentProj.Models
{
    public class Rent
    {
        public int ID { get; set; }
        public int? MemberID { get; set; }
        public Member? Member { get; set; }
        public int? CarID { get; set; }
        public Car? Car { get; set; }
        [DataType(DataType.Date)] public DateTime ReturnDate { get; set; }
    }
}
