using MVCAgeCheck.Dtos;
using MVCAgeCheck.Models;

namespace MVCAgeCheck.Services
{
    public static class LoginFactory
    {
        public static LoginDto CreateLoginDto(Login login)
        {
            return new LoginDto
            {
                DateTime = login.DateTime,
                Successful = login.Successful
            };
        }

        public static Login CreateLogin(LoginDto loginDto)
        {
            return new Login
            {
                DateTime = loginDto.DateTime,
                Successful = loginDto.Successful
            };
        }
    }
}
