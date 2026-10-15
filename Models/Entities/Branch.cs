using System.ComponentModel.DataAnnotations;

namespace Rentcar.Models.Entities
{
    public class Branch
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(1000)]
        public string Address { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public ICollection<Car> Cars { get; set; } = new List<Car>();
        public ICollection<Booking> ReceivingBookings {  get; set; } = new List<Booking>();
        public ICollection<Booking> ReturnBookings { get; set; } = new List<Booking>();
        public ICollection<Manager> Managers { get; set; } = new List<Manager>();
        public ICollection<CarMovement> FromCarMovements { get; set; } = new List<CarMovement>();
        public ICollection<CarMovement> ToCarMovements { get; set; } = new List<CarMovement>();

    }
}
