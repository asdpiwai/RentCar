using System.ComponentModel.DataAnnotations;

namespace Rentcar.DTOs
{
    public class CreateBookingDto : IValidatableObject 
    {
        public int CarId { get; set; }
        public int ReceivingBranchId { get; set; }
        public int ReturnBranchId { get; set; }
        public DateTimeOffset RentalStart { get; set; }
        public DateTimeOffset RentalEnd { get; set; }

        public IEnumerable<ValidationResult> Validate (ValidationContext validationContext)
        {
            if (RentalEnd <= RentalStart) yield return new ValidationResult("Конец аренды должен быть строго позже её начала", new[] { "RentalStart", "RentalEnd" });
            if (RentalStart <= DateTimeOffset.UtcNow) yield return new ValidationResult("Начало аренды должно быть в будущем", new[] { "RentalStart" });
        }
    }
}
