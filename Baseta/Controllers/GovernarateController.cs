using Baseta.Dtos;
using Baseta.Infrastructures;
using Baseta.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Baseta.Controllers
{
    [Route("api/governarate")]
    public class GovernarateController : BaseController
    {
        public GovernarateController(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            Console.WriteLine("sdrgndslkfjgnds;fjn");
            var res= await applicationDbContext.Governarates.ToListAsync();
            var result=res.Select(e=> new GovernarateDto
            {
                Id = e.Id,
                Name = e.Name,
            }) .ToList();
            return Ok(Result<List<GovernarateDto>>.Ok("THE_DATA_RETURNED_SUCCESSFULLY", result));


        }

    }
}
