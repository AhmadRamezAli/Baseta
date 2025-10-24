    using Baseta.Dtos;
    using Baseta.Entities;
    using Baseta.Infrastructures;
    using Baseta.Utils;
    using Baseta.Utils.Baseta.Utils;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Security.Claims;

    namespace Baseta.Controllers
    {
        [Route("api/job")]
        public class JobController : BaseController
        {
            private readonly ILogger<JobController>_logger;
            public JobController(ApplicationDbContext applicationDbContext, ILogger<JobController> logger) : base(applicationDbContext)
            {
                _logger = logger;   
            }
            [HttpPost("get-all")]
            public async Task<IActionResult> GetAll([FromQuery]int pageSize, [FromQuery] int pageNumber)
            {
                var jobs=await applicationDbContext.Jobs
                    .Include(e=>e.JobCategories)
                    .ThenInclude(e=>e.category)
                    .Include(e=>e.User)
                    .Include(e=>e.JobTypes)
                    .ThenInclude(e=>e.Type)
                    .Include(e=>e.Location)
                    .ThenInclude(e=>e.governarate)
                    .AsNoTracking() 
                    .AsSplitQuery()
                    .ToListAsync();

                var result = jobs.Select(e=> JobDto.Mapper(e)).ToList();
            
                return Ok(Result<PaginatedResult<JobDto>>.Ok("DATA_RETURNED_SUCCESSFULLY",PaginatedResult<JobDto>.Create(result, jobs.Count(),pageNumber,pageSize)));

            }
        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateJobDto createJobDto)
        {
            Console.WriteLine("==================================");
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
                if (userIdClaim == null)
                    return Unauthorized(Result<string>.Error("INVALID_TOKEN", "User ID not found in token"));

                var userId = int.Parse(userIdClaim.Value);


                ValidationHelper.ThrowIfNullOrEmpty(createJobDto.Name, "Job name");
                ValidationHelper.ThrowIfNullOrEmpty(createJobDto.Description, "Job description");
                ValidationHelper.ThrowIfNullOrEmpty(createJobDto.Location, "Location name");
                ValidationHelper.ThrowIfLessThanOrEqualToZero(createJobDto.GovernarateId, "Governarate ID");
                ValidationHelper.ThrowIfLessThanOrEqualToZero(createJobDto.Salary, "Salary");
                ValidationHelper.ThrowIfNullOrEmpty(createJobDto.JobTypeIds, "Job types");
                ValidationHelper.ThrowIfNullOrEmpty(createJobDto.CategoryIds, "Categories");
    
                var location = new Location
                {
                    CreatedAt = DateTime.Now,
                    GovernarateId = createJobDto.GovernarateId,
                    Name = createJobDto.Location,
                };
                await applicationDbContext.Locations.AddAsync(location);
                await applicationDbContext.SaveChangesAsync();

                var job = new Job
                {
                    UserId = userId,
                    Description = createJobDto.Description,
                    CreatedAt = DateTime.Now,
                    Features = createJobDto.Features,
                    Name = createJobDto.Name,
                    Requirements = createJobDto.Requirements,
                    Salary = createJobDto.Salary,
                    ExperenceRequirement = createJobDto.ExperenceRequirement,
                    LocationId = location.Id

                };
                await applicationDbContext.Jobs.AddAsync(job);
                await applicationDbContext.SaveChangesAsync();
                var categories = await applicationDbContext.Categories.Where(e=> createJobDto.CategoryIds.Contains(e.Id)).ToListAsync();

            var types = await applicationDbContext.Types.Where(e => createJobDto.JobTypeIds.Contains(e.Id)).ToListAsync();
            var jobCategories = categories.Select(e => new JobCategory
            {
                JobId = job.Id,
                CategoryId = e.Id,
                category = e
            }).ToList();
            var jobTypes= types.Select(e=> new JobType
            {
                JobId= job.Id,
                TypeId= e.Id,
                Type =e
            }).ToList();
                var user= await applicationDbContext.Users.FirstOrDefaultAsync(e=>e.Id==userId);
                await applicationDbContext.JobCategories.AddRangeAsync(jobCategories);
                await applicationDbContext.JobTypes.AddRangeAsync(jobTypes);
                await applicationDbContext.SaveChangesAsync();
                var result = new JobDto
                {
                    Description = createJobDto.Description,
                    Name = createJobDto.Name,
                    Features = createJobDto.Features,
                    ExperenceRequirement = createJobDto.ExperenceRequirement,
                    Requirements = createJobDto.Requirements,
                    Salary = createJobDto.Salary,
                    UserId = userId,
                    UserName = user.FirstName + " " + user.LastName,
                    LocationId = location.Id,
                    Id = job.Id,
                    LocationName = location.Name,
                    Categories = jobCategories.Select(e => CategoryDto.Mapper(e.category)).ToList(),
                    Types=jobTypes.Select(e=> TypeDto.Mapper(e.Type)).ToList()
                };
                return Ok(Result<JobDto>.Ok("JOB_CREATED_SUCCESSFULLY", result));

            }

            [HttpPost("get")]
            public async Task<IActionResult> Get([FromBody] SearchFilterDto searchFilter, [FromQuery] int pageSize,[FromQuery] int pageNumber )
            {
                if (searchFilter.TypeIds == null)
                {
                    var types = await applicationDbContext.Types.ToListAsync();
                    searchFilter.TypeIds = types.Select(e=>e.Id).ToList();
                }
            
                if (searchFilter.CategoryIds == null)
                {
                    var categories = await applicationDbContext.Categories.ToListAsync();
                    searchFilter.CategoryIds =categories.Select(e => e.Id).ToList();

                }
                if (searchFilter.GovernarateIds == null)
                {
                    var governarates = await applicationDbContext.Governarates.ToListAsync();
                    searchFilter.GovernarateIds = governarates.Select(e => e.Id).ToList();
                }
                var result =await applicationDbContext.Jobs
                    .Include(e => e.JobCategories)
                    .ThenInclude(e=>e.category)
                    .Where(e => e.JobCategories.Any(e => searchFilter.CategoryIds.Contains(e.CategoryId)))
                    .Include(e => e.JobTypes)
                    .ThenInclude(e=>e.Type)
                    .Where(e => e.JobTypes.Any(e => searchFilter.TypeIds.Contains(e.TypeId)))
                    .Include(e => e.Location)
                    .ThenInclude(e=>e.governarate)
                    .Include(e=>e.User)
                    .AsSplitQuery()
                    .AsNoTracking()
                    .Where(e=>searchFilter.GovernarateIds.Contains( e.Location.GovernarateId)).ToListAsync();

                var jobDto = result.Select(e => new JobDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    Features = e.Features,
                    ExperenceRequirement = e.ExperenceRequirement,
                    Requirements = e.Requirements,
                    Salary = e.Salary,
                    UserId = e.UserId,
                    UserName = e.User.FirstName + " " + e.User.LastName,
                    LocationId = e.Location.Id,
                    LocationName = e.Location.Name,
                    Categories = e.JobCategories.Select(v => CategoryDto.Mapper(v.category)).ToList(),
                    Types=e.JobTypes.Select(v=> TypeDto.Mapper(v.Type)).ToList()
                });
                var paginatedResult = PaginatedResult<JobDto>.Create(jobDto, jobDto.Count(), pageNumber, pageSize);
                return Ok(Result<PaginatedResult<JobDto>>.Ok("THE_DATA_RETURNED_SUCCESSFULLY",paginatedResult));

            }


        }
    }
