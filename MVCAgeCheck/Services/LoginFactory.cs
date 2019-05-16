using DotNetCoreAPI.Dtos;
using DotNetCoreAPI.Models;

namespace DotNetCoreAPI.Services
{
    public static class LoginFactory
    {
        public static LoginDto CreateLoginDto(Login login)
        {
            return new LoginDto
            {
                DateTime = login.DateTime
            };
        }

        public static Login CreateLogin(LoginDto loginDto)
        {
            return new Login
            {
                DateTime = loginDto.DateTime
            };
        }
    }
}
