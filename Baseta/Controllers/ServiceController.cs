using Baseta.Dtos;
using Baseta.Entities;
using Baseta.Infrastructures;
using Baseta.Utils;
using Baseta.Utils.Baseta.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Security.Claims;

namespace Baseta.Controllers
{
    [Route("api/service")]
    public class ServiceController : BaseController
    {
        private readonly ILogger<ServiceController> _logger;
        public ServiceController(ApplicationDbContext applicationDbContext, ILogger<ServiceController> logger) : base(applicationDbContext)
        {
            _logger = logger;
        }
        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateServiceDto createServiceDto)
        {

            ValidationHelper.ThrowIfNullOrEmpty(createServiceDto.Name, "Service name");
            ValidationHelper.ThrowIfNullOrEmpty(createServiceDto.Description, "Service description");
            ValidationHelper.ThrowIfNullOrEmpty(createServiceDto.CategoryIds, "Service categories");

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized(Result<string>.Error("INVALID_TOKEN", "User ID not found in token"));

            var userId = int.Parse(userIdClaim.Value);

            var service = new Service
            {
                CreatedAt = DateTime.Now,
                Description = createServiceDto.Description,
                Title = createServiceDto.Name,
                UserId = userId,
            };
            await applicationDbContext.Services.AddAsync(service);
            await applicationDbContext.SaveChangesAsync();
            var serviceCategories = createServiceDto.CategoryIds.Select(e => new ServiceCategory
            {
                CategoryId = e,
                ServiceId = service.Id,
            });
            await applicationDbContext.ServicesCategories.AddRangeAsync(serviceCategories);
            await applicationDbContext.SaveChangesAsync();
            var user = await applicationDbContext.Users.FirstOrDefaultAsync(e => e.Id == userId);
            var categories =await applicationDbContext.Categories.Where(e=> createServiceDto.CategoryIds.Contains(e.Id)).ToListAsync();
            var result = new ServiceDto
            {
                Description = createServiceDto.Description,
                Title = createServiceDto.Name,
                user = UserDto.Mapper(user),
                serviceCategories = categories.Select(e => CategoryDto.Mapper(e)).ToList()
            };
            return Ok(Result<ServiceDto>.Ok("THE_SERVICE_CREATED_SUCCESSFULLY",result));


        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] int serviceId)
        {
            var result = await applicationDbContext.Services.FirstOrDefaultAsync(e => e.Id == serviceId);
            result.IsDeleted = true;
            await applicationDbContext.SaveChangesAsync();
            return Ok(Result<bool>.Ok("THE_SERVICE_IS_SELETED_SUCCESSFULLY",true));
        }
        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery]int pageSize, [FromQuery] int pageNumber)
        {
            var services= await applicationDbContext.Services
                .Include(e=>e.User)
                .Include(e=>e.serviceCategories)
                .ThenInclude(e=>e.Category).AsNoTracking().AsSplitQuery().ToListAsync();
            var result= PaginatedResult<ServiceDto>.Create( services.Select(e=> ServiceDto.Mapper(e)).ToList(),services.Count(),pageNumber,pageSize);
            _logger.LogInformation("THIS ALL THE DATA");
            return Ok(Result<PaginatedResult<ServiceDto>>.Ok("THE_DATA_RETURNED_SUCCESSFULLY", result));

        }






    }
}
