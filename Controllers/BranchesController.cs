using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet]
        public async Task<ActionResult<List<ResponseBranchDto>>> GetBranches (bool includeInactive = false)
        {
            IQueryable<Branch> branchQuery = _dbContext.Branches;
            if (!includeInactive ) branchQuery = branchQuery.Where(b => b.IsActive);
            var branchDto = await branchQuery.Select(branch => new ResponseBranchDto
            {
                Id = branch.Id,
                Name = branch.Name,
                Address = branch.Address,
                Capacity = branch.Capacity,
            }).ToListAsync();
            return Ok(branchDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseBranchDto>> GetBranch(int id)
        {
            var branch = await _dbContext.Branches.FirstOrDefaultAsync(b => b.Id == id);
            if (branch == null) return NotFound();
            ResponseBranchDto branchDto = new ResponseBranchDto()
            {
                Id = branch.Id,
                Name = branch.Name,
                Address = branch.Address,
                Capacity = branch.Capacity,
            };
            return Ok(branchDto);
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
                Capacity= branch.Capacity,
            };
            return CreatedAtAction(nameof(GetBranch), new { id = responseBranchDto.Id }, responseBranchDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseBranchDto>> UpdateBranch (int id, CreateBranchDto createBranchDto)
        {
            var branch = await _dbContext.Branches.FirstOrDefaultAsync(b => b.Id == id);
            if (branch == null) return NotFound();
            branch.Name = createBranchDto.Name;
            branch.Address = createBranchDto.Address;
            branch.Capacity = createBranchDto.Capacity;
            await _dbContext.SaveChangesAsync();
            ResponseBranchDto responseBranchDto = new ResponseBranchDto()
            {
                Id = branch.Id,
                Name = branch.Name,
                Address = branch.Address,
                Capacity = branch.Capacity,
            };
            return Ok(responseBranchDto);
        }

    }
}
