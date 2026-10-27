using System.ComponentModel.DataAnnotations;

namespace Rentcar.DTOs
{
    public class CreateCategoryDto : IValidatableObject
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [Range(1, int.MaxValue)]
        public decimal BasePricePerDay { get; set; }
        [Required]
        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;

        public IEnumerable<ValidationResult> Validate (ValidationContext validationContext)
        {
            if (BasePricePerDay != Math.Truncate(BasePricePerDay)) yield return new ValidationResult("Цена за сутки должна быть целым числом", new[] { "BasePricePerDay" });
        }
    }
}
