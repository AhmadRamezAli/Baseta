using Baseta.Entities;

namespace Baseta.Dtos
{
    public class RegisterUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public List<ContactInfoDto> contactInfoDtos{get;set;}
    }
}
