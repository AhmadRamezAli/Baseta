using Baseta.Dtos;
using Baseta.Infrastructures;
using Baseta.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Baseta.Controllers
{
    [Route("api/type")]
    public class TypeController : BaseController
    {
        public TypeController(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            Console.WriteLine("sdgfd;sklfmgsdflmbzd;lfkm");
            var res= await applicationDbContext.Types.ToListAsync();
            var result= res.Select(e=> new TypeDto
            {
                
                Id = e.Id,
                Name = e.Name, 
            }).ToList();
            return Ok(Result<List<TypeDto>>.Ok("THE_DATA_RETURNED_SUCCESSFULLY", result));


        }
    }
}
