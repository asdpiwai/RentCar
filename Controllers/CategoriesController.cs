using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rentcar.Data;
using Rentcar.DTOs;

namespace Rentcar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly RentcarDbContext _dbContext;
        public CategoriesController(RentcarDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<ActionResult<List<ResponseCategoryDto>>> GetCategories()
        {
            var categoryDtos = await _dbContext.Categories
                .Select(category => new ResponseCategoryDto
                {
                    Id = category.Id,
                    Name = category.Name,
                    BasePricePerDay = category.BasePricePerDay,
                    Description = category.Description,
                })
                .ToListAsync();
            return Ok(categoryDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseCategoryDto>> GetCategory(int id)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null) return NotFound();
            ResponseCategoryDto categoryDto = new ResponseCategoryDto()
            {
                Id = category.Id,
                Name = category.Name,
                BasePricePerDay = category.BasePricePerDay,
                Description = category.Description,
            };
            return Ok(categoryDto);
        }

    }
}
