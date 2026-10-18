using Rentcar.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Rentcar.Models.Entities
{
    public class UserAccount
    {
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(254)]
        public string Email { get; set; } = string.Empty;
        [Required]
        [StringLength(1000)]
        public string PasswordHash { get; set; } = string.Empty;
        public bool IsBlocked { get; set; } = false;
        [StringLength(100)]
        public string? BlockReason { get; set; }
        public DateTime CreatedAt { get; set; }
        public TypeRole Role { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; } = null!;
    }
}
