using Baseta.Dtos;
using Baseta.Infrastructures;
using Baseta.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Baseta.Controllers
{

        [Route("api/category")]
        public class CategoryController : BaseController
        {
            private readonly ILogger<CategoryController> _logger;

            public CategoryController(ApplicationDbContext applicationDbContext, ILogger<CategoryController> logger) : base(applicationDbContext)
            {
                _logger = logger;
            }


            [HttpGet("get-all")]
            public async Task<IActionResult> GetAll()
            {
            Console.WriteLine("DFGHJKLGHJKL:");
                var response= await applicationDbContext.Categories
                    .AsNoTracking()
                    .AsSplitQuery()
                    .ToListAsync();
                var result = response.Select(e => new CategoryDto
                {
                    Id = e.Id,
                    Name = e.Name,
                }).ToList();
                return Ok(Result<List<CategoryDto>>.Ok("THE_DATA_RETURNED_SUCCESSFULLY",result));

            }

        //[HttpGet("get-by-id")]
        //public async Task<IActionResult> GetById([FromQuery] int id ,pag)
        //{
        //    var response= await applicationDbContext.Jobs
        //        .Include(e=>e.JobCategories)
        //        .ThenInclude(e=>e.category)
        //        .Where(e=>e.JobCategories.Any(v=>v.CategoryId==id))
        //        .Include(e=>e.JobTypes)
        //        .ThenInclude(e=>e.Type)
        //        .Include(e=>e.User)
        //        .AsNoTracking()
        //        .AsSplitQuery()
        //        .ToListAsync();
        //    var jobDto = response.Select(e => new JobDto
        //    {
        //        Id = e.Id,
        //        Name = e.Name,
        //        Description = e.Description,
        //        Features = e.Features,
        //        ExperenceRequirement = e.ExperenceRequirement,
        //        Requirements = e.Requirements,
        //        Salary = e.Salary,
        //        UserId = e.UserId,
        //        UserName = e.User.FirstName + " " + e.User.LastName,
        //        LocationId = e.Location.Id,
        //        LocationName = e.Location.Name,
        //        Categories = e.JobCategories.Select(v => CategoryDto.Mapper(v.category)).ToList(),
        //        Types = e.JobTypes.Select(v => TypeDto.Mapper(v.Type)).ToList()
        //    });
        //    var paginatedResult = PaginatedResult<JobDto>.Create(jobDto, jobDto.Count(), pageNumber, pageSize);
        //    return Ok(Result<PaginatedResult<JobDto>>.Ok("THE_DATA_RETURNED_SUCCESSFULLY", paginatedResult));


        
    }
}
