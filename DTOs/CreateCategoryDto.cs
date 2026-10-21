using System.ComponentModel.DataAnnotations;

namespace Rentcar.DTOs
{
    public class CreateCategoryDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [Range(1, 100000)]
        public decimal BasePricePerDay { get; set; }
        [Required]
        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;
    }
}
