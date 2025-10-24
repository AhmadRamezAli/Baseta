using Baseta.Infrastructures;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Baseta.Controllers
{
    [ApiController]
    public class BaseController : Controller
    {
        protected readonly ApplicationDbContext applicationDbContext;

        public BaseController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
    }
}
