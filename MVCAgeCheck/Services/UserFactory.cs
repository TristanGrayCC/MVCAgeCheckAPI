using MVCAgeCheck.Dtos;
using MVCAgeCheck.Models;
using System.Collections.Generic;
using System.Linq;

namespace MVCAgeCheck.Services
{
    public static class UserFactory
    {
        public static User CreateUser(UserDto userDto)
        {
            var user = new User
            {
                Name = userDto.Name,
                Email = userDto.Email,
                DateOfBirth = userDto.DateOfBirth
            };

            if (userDto.Logins?.Count > 0)
            {
                user.Logins = new List<Login>();
                foreach (var loginDto in userDto.Logins)
                {
                    var login = LoginFactory.CreateLogin(loginDto);
                    user.Logins.Add(login);
                }
            }

            return user;
        }
    }
}
