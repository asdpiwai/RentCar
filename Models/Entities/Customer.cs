namespace Rentcar.Models.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public int UserAccountId { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public UserAccount UserAccount { get; set; } = null!;
    }
}
