using System.ComponentModel.DataAnnotations;

namespace Rentcar.DTOs
{
    public class CreateBranchDto
    {
        [Range(1, int.MaxValue)]
        public int Capacity { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(1000)]
        public string Address { get; set; } = string.Empty;
    }
}
