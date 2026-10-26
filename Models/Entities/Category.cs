using System.ComponentModel.DataAnnotations;

namespace Rentcar.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [Range(1, int.MaxValue)]
        public decimal BasePricePerDay { get; set; }
        [Required]
        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}   