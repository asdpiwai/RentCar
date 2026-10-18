using System.ComponentModel.DataAnnotations;

namespace Rentcar.Models.Entities
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(100)]
        public string Surname { get; set; } = string.Empty;
        [StringLength(100)]
        public string? Patronymic { get; set; }
        public DateOnly DateOfBirth { get; set; }
        [Required]
        [StringLength(16)]
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public UserAccount? UserAccount { get; set; }
        public ICollection<DriverLicense> DriverLicenses { get; set; } = new List<DriverLicense>();
        public ICollection<AdditionalDriver> AdditionalDrivers { get; set; } = new List<AdditionalDriver>();
    }
}
