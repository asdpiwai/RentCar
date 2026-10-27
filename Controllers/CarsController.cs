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
        public async Task<ActionResult<List<ResponseCarDto>>> GetCars(int? categoryId, int? branchId, bool includeInactive = false)
        {
            IQueryable<Car> carQuery = _dbContext.Cars;
            if (!includeInactive) carQuery = carQuery.Where(c => c.IsActive);
            if (categoryId != null)
            {
                carQuery = carQuery.Where(c => c.CategoryId == categoryId.Value);
            }
            if (branchId != null)
            {
                carQuery = carQuery.Where(c => c.BranchId == branchId.Value);
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

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseCarDto>> GetCar(int id)
        {
            var car = await _dbContext.Cars.Include(c => c.Category).Include(c => c.Branch).FirstOrDefaultAsync(c => c.Id == id);
            if (car == null) return NotFound();
            ResponseCarDto carDto = new ResponseCarDto()
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
                BranchName = car.Branch?.Name,
            };
            return Ok(carDto);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseCarDto>> AddCar(CreateCarDto createCarDto)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == createCarDto.CategoryId);
            if (category == null || !category.IsActive) return NotFound();
            Branch? branch = null;
            if (createCarDto.BranchId != null)
            {
                branch = await _dbContext.Branches.FirstOrDefaultAsync(b => b.Id == createCarDto.BranchId);
                if (branch == null || !branch.IsActive) return NotFound();

            }
            bool vinExists = await _dbContext.Cars.AnyAsync(c => c.VIN == createCarDto.VIN);
            if (vinExists) return Conflict("Автомобиль с таким VIN номером уже существует");
            bool licensePlateExists = await _dbContext.Cars.AnyAsync(c => c.LicensePlate == createCarDto.LicensePlate);
            if (licensePlateExists) return Conflict("Автомобиль с таким государственным номером уже существует");
            var car = new Car()
            {
                Brand = createCarDto.Brand,
                Model = createCarDto.Model,
                Year = createCarDto.Year,
                LicensePlate = createCarDto.LicensePlate,
                VIN = createCarDto.VIN,
                CategoryId = createCarDto.CategoryId,
                BranchId = createCarDto.BranchId,
                Mileage = createCarDto.Mileage,
                CreatedAt = DateTime.UtcNow,
            };
            _dbContext.Cars.Add(car);
            await _dbContext.SaveChangesAsync();
            ResponseCarDto responseCarDto = new ResponseCarDto()
            {
                Id = car.Id,
                Brand = car.Brand,
                Model = car.Model,
                Year = car.Year,
                Mileage = car.Mileage,
                Status = car.Status,
                CategoryId = car.CategoryId,
                BranchId = car.BranchId,
                CategoryName = category.Name,
                BranchName = branch != null ? branch.Name : null,
            };
            return CreatedAtAction(nameof(GetCar), new { Id = car.Id }, responseCarDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseCarDto>> UpdateCar (int id, CreateCarDto createCarDto)
        {
            var car = await _dbContext.Cars.FirstOrDefaultAsync(c => c.Id == id);
            if (car == null) return NotFound();
            var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == createCarDto.CategoryId);
            if (category == null || !category.IsActive) return NotFound();
            Branch? branch = null;
            if (createCarDto.BranchId != null)
            {
                branch = await _dbContext.Branches.FirstOrDefaultAsync(b => b.Id == createCarDto.BranchId);
                if (branch == null || !branch.IsActive) return NotFound();

            }
            bool vinExists = await _dbContext.Cars.AnyAsync(c => c.VIN == createCarDto.VIN && c.Id != id);
            if (vinExists) return Conflict("Автомобиль с таким VIN номером уже существует");
            bool licensePlateExists = await _dbContext.Cars.AnyAsync(c => c.LicensePlate == createCarDto.LicensePlate && c.Id != id);
            if (licensePlateExists) return Conflict("Автомобиль с таким государственным номером уже существует");
            if (createCarDto.Mileage < car.Mileage) return Conflict("Пробег не может уменьшиться");
            car.Brand = createCarDto.Brand;
            car.Model = createCarDto.Model;
            car.Year = createCarDto.Year;
            car.LicensePlate = createCarDto.LicensePlate;
            car.VIN = createCarDto.VIN;
            car.CategoryId = createCarDto.CategoryId;
            car.BranchId = createCarDto.BranchId;
            car.Mileage = createCarDto.Mileage;
            await _dbContext.SaveChangesAsync();
            ResponseCarDto responseCarDto = new ResponseCarDto()
            {
                Id = car.Id,
                Brand = car.Brand,
                Model = car.Model,
                Year = car.Year,
                Mileage = car.Mileage,
                Status = car.Status,
                CategoryId = car.CategoryId,
                BranchId = car.BranchId,
                CategoryName = category.Name,
                BranchName = branch == null ? null : branch.Name,
            };
            return Ok(responseCarDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar (int id)
        {
            var car = await _dbContext.Cars.FirstOrDefaultAsync(c => c.Id == id);
            if (car == null) return NotFound();
            car.IsActive = false;
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
