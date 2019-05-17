using DotNetCoreAPI.Dtos;
using DotNetCoreAPI.Models;
using DotNetCoreAPI.Services;
using System;
using Xunit;

namespace APITest.Services
{
    public class USerFactoryTests
    {
        [Fact]
        public void CreateUserDto_CreatesValidDto()
        {
            var name = "new user";
            var doB = new DateTime(2019, 01, 01);
            var email = "email address";

            var user = new User
            {
                Name = name,
                Email = email,
                DateOfBirth = doB
            };

            var dto = UserFactory.CreateUserDto(user);

            Assert.NotNull(dto);
            Assert.Equal(name, dto.Name);
            Assert.Equal(doB, dto.DateOfBirth);
            Assert.Equal(email, dto.Email);
        }

        [Fact]
        public void CreateUser_CreatesValidDbObject()
        {
            var name = "new user";
            var doB = new DateTime(2019, 01, 01);
            var email = "email address";

            var userDto = new UserDto
            {
                Name = name,
                Email = email,
                DateOfBirth = doB
            };

            var dbModel = UserFactory.CreateUser(userDto);

            Assert.NotNull(dbModel);
            Assert.Equal(name, dbModel.Name);
            Assert.Equal(doB, dbModel.DateOfBirth);
            Assert.Equal(email, dbModel.Email);
        }
    }
}
