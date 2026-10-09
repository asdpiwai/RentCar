namespace Rentcar.Models.Entities
{
    public class Branch
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
