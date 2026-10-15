using Rentcar.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Rentcar.Models.Entities
{
    public class Charge
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public decimal Amount { get; set; }
        [Required]
        [StringLength(1000)]
        public string Reason { get; set; } = string.Empty;
        public int ManagerId { get; set; }
        public ChargeStatus Status { get; set; } = ChargeStatus.Pending;
        public ChargeType Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? PaidAt { get; set; }
        public Booking Booking { get; set; } = null!;
        public Manager Manager { get; set; } = null!;
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
