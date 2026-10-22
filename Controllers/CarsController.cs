using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rentcar.Data;
using Rentcar.DTOs;
using Rentcar.Models.Entities;

namespace Rentcar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly RentcarDbContext _dbContext;
        public CarsController(RentcarDbContext dbContext)
        { 
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<ResponseCarDto>>> GetCar()
        {
            var carDTOs = await _dbContext.Cars
                .Select(car => new ResponseCarDto
                {
                    Id = car.Id,
                    Brand = car.Brand,
                    Model = car.Model,
                    Year = car.Year,
                    Mileage = car.Mileage,
                    Status = car.Status,
                    CategoryId = car.CategoryId,
                    BranchId = car.BranchId,
                    CategoryName = car.Category.Name,
                    BranchName = car.Branch != null ? car.Branch.Name : null,
                })
                .ToListAsync();
            return Ok(carDTOs);
        }
    }
}
