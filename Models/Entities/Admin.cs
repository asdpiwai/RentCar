using System.ComponentModel.DataAnnotations;

namespace Rentcar.Models.Entities
{
    public class Admin
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
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        [Required]
        [StringLength(16)]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        [StringLength(1000)]
        public string PasswordHash { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }
    }
}
