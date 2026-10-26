using System.ComponentModel.DataAnnotations;

namespace Rentcar.DTOs
{
    public class CreateCarDto
    {
        [Required]
        [StringLength(20)]
        public string Brand { get; set; } = string.Empty;
        [Required]
        [StringLength(20)]
        public string Model { get; set; } = string.Empty;
        [Range(1990, int.MaxValue)]
        public int Year { get; set; }
        [Required]
        [StringLength(10)]
        public string LicensePlate { get; set; } = string.Empty;
        [Required]
        [StringLength(17, MinimumLength = 17)]
        public string VIN { get; set; } = string.Empty;
        [Range (1, int.MaxValue)]
        public int CategoryId { get; set; }
        [Range(1, int.MaxValue)]
        public int? BranchId { get; set; }
        [Range(0, int.MaxValue)]
        public int Mileage { get; set; }
    }
}
