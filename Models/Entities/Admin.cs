namespace Rentcar.Models.Entities
{
    public class Admin
    {
        public int Id { get; set; }
        public bool IsActive { get; set; } = true;
        public int UserAccountId { get; set; }
        public UserAccount UserAccount { get; set; } = null!;
    }
}
