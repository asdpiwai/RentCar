using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rentcar.Data;
using Rentcar.DTOs;
using Rentcar.Models.Entities;

namespace Rentcar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private readonly RentcarDbContext _dbContext;
        public BranchesController(RentcarDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseBranchDto>> AddBranch (CreateBranchDto createBranchDto)
        {
            var branch = new Branch()
            {
                Capacity = createBranchDto.Capacity,
                Name = createBranchDto.Name,
                Address = createBranchDto.Address,
                CreatedAt = DateTime.UtcNow,
            };
            _dbContext.Branches.Add(branch);
            await _dbContext.SaveChangesAsync();
            ResponseBranchDto responseBranchDto = new ResponseBranchDto()
            {
                Id = branch.Id,
                Name = branch.Name,
                Address = branch.Address,
            };
            return CreatedAtAction()
        }


    }
}
