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
            public async Task<ActionResult<List<ResponseCarDto>>> GetCar(int? categoryId, int? branchId)
            {
                IQueryable<Car> carQuery =  _dbContext.Cars;
                if (categoryId != null)
                {
                    carQuery = carQuery.Where(c => c.CategoryId  == categoryId.Value);
                }
                if (branchId != null)
                {
                    carQuery = carQuery.Where(c =>  c.BranchId == branchId.Value);
                }
                var tmpCarDTO = carQuery.Select(car => new ResponseCarDto
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
                });
                var carDTO = await tmpCarDTO.ToListAsync();
                return Ok(carDTO);
        }
    }
}
