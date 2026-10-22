using Rentcar.Models.Enums;

namespace Rentcar.DTOs
{
    public class ResponseCarDto
    {
        public int Id { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public int Mileage { get; set; }
        public CarStatus Status { get; set; }
        public int CategoryId { get; set; }
        public int? BranchId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string? BranchName { get; set; }
    }
}
