using DotNetCoreAPI.Dtos;
using DotNetCoreAPI.Models;

namespace DotNetCoreAPI.Services
{
    public static class UserFactory
    {
        public static UserDto CreateUserDto(User user)
        {
            return new UserDto
            {
                Name = user.Name,
                Email = user.Email
            };
        }

        public static User CreateUser(UserDto user)
        {
            return new User
            {
                Name = user.Name,
                Email = user.Email
            };
        }
    }
}
