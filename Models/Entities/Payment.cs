using Rentcar.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Rentcar.Models.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public int? ChargeId { get; set; }
        public decimal Price { get; set; }
        public PaymentStatus Status { get; set; } = PaymentStatus.Pending;
        public PaymentType Type { get; set; }
        [StringLength(100)]
        public string? TransactionId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public Booking Booking { get; set; } = null!;
        public Charge? Charge { get; set; } 
    }
}
