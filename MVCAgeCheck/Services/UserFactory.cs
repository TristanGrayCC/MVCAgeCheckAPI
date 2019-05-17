using MVCAgeCheck.Dtos;
using MVCAgeCheck.Models;

namespace MVCAgeCheck.Services
{
    public static class UserFactory
    {
        public static UserDto CreateUserDto(User user)
        {
            return new UserDto
            {
                Name = user.Name,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth
            };
        }

        public static User CreateUser(UserDto user)
        {
            return new User
            {
                Name = user.Name,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth
            };
        }
    }
}
