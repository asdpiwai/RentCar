namespace Rentcar.DTOs
{
    public class ResponseCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal BasePricePerDay { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
