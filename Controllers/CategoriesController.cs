using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rentcar.Data;
using Rentcar.DTOs;
using Rentcar.Models.Entities;

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
        public async Task<ActionResult<List<ResponseCategoryDto>>> GetCategories(bool includeInactive = false)
        {
            IQueryable<Category> categoryQuery = _dbContext.Categories;
            if (includeInactive == false)
            {
                categoryQuery = categoryQuery.Where(c => c.IsActive);
            }
            var categoriesDto = await categoryQuery.Select(category => new ResponseCategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                BasePricePerDay = category.BasePricePerDay,
                Description = category.Description,
            }).ToListAsync();
            return Ok(categoriesDto);
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

        [HttpPost]
        public async Task<ActionResult<ResponseCategoryDto>> AddCategory (CreateCategoryDto categoryDto)
        {
            var category = new Category()
            {
                Name = categoryDto.Name,
                BasePricePerDay = categoryDto.BasePricePerDay,
                Description = categoryDto.Description,
                CreatedAt = DateTime.UtcNow,
            };
            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync();
            ResponseCategoryDto responseCategoryDto = new ResponseCategoryDto()
            {
                Id = category.Id,
                Name = category.Name,
                BasePricePerDay = category.BasePricePerDay,
                Description = category.Description,
            };
            return CreatedAtAction(nameof(GetCategory), new { id = responseCategoryDto.Id }, responseCategoryDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseCategoryDto>> UpdateCategory ( int id,CreateCategoryDto categoryDto)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null) return NotFound();
            category.Name = categoryDto.Name;
            category.BasePricePerDay = categoryDto.BasePricePerDay;
            category.Description = categoryDto.Description;
            await _dbContext.SaveChangesAsync();
            ResponseCategoryDto responseCategoryDto = new ResponseCategoryDto()
            {
                Id = category.Id,
                Name = category.Name,
                BasePricePerDay = category.BasePricePerDay,
                Description = category.Description,
            };
            return Ok(responseCategoryDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory (int id)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null) return NotFound();
            category.IsActive = false;
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
