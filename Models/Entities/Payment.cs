using Rentcar.Models.Enums;

namespace Rentcar.Models.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public decimal Price { get; set; }
        public PaymentStatus Status { get; set; }
        public PaymentType Type { get; set; }
        public string? TransactionId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}
