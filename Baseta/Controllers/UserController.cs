using Microsoft.AspNetCore.Mvc;
using Baseta.Infrastructures;
using Baseta.Dtos;
using Baseta.Entities;
using Baseta.Utils;
using Baseta.JWT;
using Baseta.Utils.Baseta.Utils;

namespace Baseta.Controllers
{
    [Route("api/user")]
    public class UserController : BaseController
    {
        private readonly JwtService jwtService;
        private readonly ILogger<UserController> logger;

        public UserController(ApplicationDbContext applicationDbContext, JwtService jwt1, ILogger<UserController> logger) : base(applicationDbContext)
        {
            this.jwtService = jwt1;
            this.logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto registerUser,CancellationToken cancellationToken )
        {

            ValidationHelper.ThrowIfNullOrEmpty(registerUser.FirstName, "First name");
            ValidationHelper.ThrowIfNullOrEmpty(registerUser.LastName, "Last name");
            ValidationHelper.ThrowIfNullOrEmpty(registerUser.PhoneNumber, "Phone number");
            ValidationHelper.ThrowIfNullOrEmpty(registerUser.Password, "Password");
            ValidationHelper.ThrowIfNullOrEmpty(registerUser.contactInfoDtos, "Contact information");

            var user = new User
                {
                    LastName = registerUser.LastName,
                    FirstName = registerUser.FirstName,
                    IsDeleted = false,
                    CreatedAt = DateTime.UtcNow,
                    Password = SHA256PasswordHasher.Hash(registerUser.Password),
                    PhoneNumber = registerUser.PhoneNumber,
                    UpdatedAt = null
                };
                await applicationDbContext.Users.AddAsync(user);
                await applicationDbContext.SaveChangesAsync();

                var contactInfos = registerUser.contactInfoDtos.Select(e=> new ContactInfo
                {
                    UserId=user.Id,
                    CreatedAt=DateTime.UtcNow,
                    Type = e.Type,
                    Value = e.Value
                });
                await applicationDbContext.Contacts.AddRangeAsync(contactInfos);
                await applicationDbContext.SaveChangesAsync();
                var token = jwtService.GenerateToken(user.Id,user.PhoneNumber);

                return Ok(Result<object>.Ok( "THE_USER_REGISTERED_CORRECTLY",   token ));
            
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginUserDto loginUser,CancellationToken cancellationToken) 
        {
            ValidationHelper.ThrowIfNullOrEmpty(loginUser.PhoneNumber, "Phone number");
            ValidationHelper.ThrowIfNullOrEmpty(loginUser.Password, "Password");
            Console.WriteLine("sdfsdfsfdsfssdf;skdmfs;dlmvsdvdf");
            Console.WriteLine(loginUser.PhoneNumber);
            Console.WriteLine(loginUser.Password);
            var user = applicationDbContext.Users.FirstOrDefault(e => e.PhoneNumber == loginUser.PhoneNumber);
            if (user == null)
            {
                return Ok( Result<string>.Error("ERROR_IN_PHONE_NUMBER_OR_PASSWORD",""));

            }
            if (user.Password != SHA256PasswordHasher.Hash(loginUser.Password))
            {
                return  Ok(Result<string>.Error("ERROR_IN_PHONE_NUMBER_OR_PASSWORD",""));
            }


            var token = jwtService.GenerateToken(user.Id, user.PhoneNumber);
            Console.WriteLine(token);
            return Ok(Result<string>.Ok("THE_USER_LOGIN_CORRECTLY", token));
        }
    }
}
