using Baseta.Entities;

namespace Baseta.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public static UserDto Mapper(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                FullName = user.FirstName + "  " + user.LastName,
            };
        }
    }
}
