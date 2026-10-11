using Rentcar.Models.Enums;

namespace Rentcar.Models.Entities
{
    public class Charge
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public decimal Amount { get; set; }
        public string Reason { get; set; } = string.Empty;
        public int ManagerId { get; set; }
        public ChargeStatus Status { get; set; }
        public ChargeType Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? PaidAt { get; set; }
    }
}
