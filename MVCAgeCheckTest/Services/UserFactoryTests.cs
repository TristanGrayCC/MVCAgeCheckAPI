using MVCAgeCheck.Dtos;
using MVCAgeCheck.Models;
using MVCAgeCheck.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MVCAgeCheckTest.Services
{
    public class USerFactoryTests
    {
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

        [Fact]
        public void CreateUserWithLogin_CreatesValidDbObjectWithLoginDbo()
        {
            var name = "new user";
            var doB = new DateTime(2019, 01, 01);
            var email = "email address";
            var loginDate = new DateTime(2019, 10, 10);
            var login = new LoginDto()
            {
                DateTime = loginDate
            };

            var userDto = new UserDto
            {
                Name = name,
                Email = email,
                DateOfBirth = doB,
                Logins = new List<LoginDto>()
                {
                    login
                }
            };

            var dbModel = UserFactory.CreateUser(userDto);

            Assert.NotNull(dbModel.Logins);
            Assert.Equal(typeof(Login), dbModel.Logins.Single().GetType());
            Assert.Equal(loginDate, dbModel.Logins.Single().DateTime);
        }
    }
}
