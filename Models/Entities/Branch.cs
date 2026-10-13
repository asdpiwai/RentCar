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
    }
}
