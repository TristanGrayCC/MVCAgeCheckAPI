using MVCAgeCheck.Dtos;
using MVCAgeCheck.Models;
using MVCAgeCheck.Services;
using System;
using Xunit;

namespace APITest.Services
{
    public class LoginFactoryTests
    {
        [Fact]
        public void CreateLoginDto_CreatesValidDto()
        {
            var userName = "User";
            var user = new User
            {
                Name = userName
            };
            var dateTime = new DateTime(2019, 01, 01);

            var login = new Login
            {
                DateTime = dateTime,
                User = user
            };

            var dto = LoginFactory.CreateLoginDto(login);

            Assert.NotNull(dto);
            Assert.Equal(dateTime, dto.DateTime);
        }

        [Fact]
        public void CreateLogin_CreatesValidModel()
        {
            var dateTime = new DateTime(2019, 01, 01);

            var login = new LoginDto
            {
                DateTime = dateTime
            };

            var dto = LoginFactory.CreateLogin(login);

            Assert.NotNull(dto);
            Assert.Equal(dateTime, dto.DateTime);
        }
    }
}
