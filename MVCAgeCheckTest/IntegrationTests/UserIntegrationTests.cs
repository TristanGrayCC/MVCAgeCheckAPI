using MVCAgeCheck;
using Xunit;
using MVCAgeCheck.Controllers;
using Microsoft.AspNetCore.Mvc;
using MVCAgeCheck.Dtos;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVCAgeCheckTest.Controllers
{
    public class UserIntegrationTests : IDisposable
    {
        private readonly UserController _userController;
        private readonly UserLoginsController _userLoginsController;
        private readonly DALContext _context;
        private const string user = "User name";

        public UserIntegrationTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DALContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MVCAgeCheckDB;Trusted_Connection=True;");
            _context = new DALContext(optionsBuilder.Options);
            _userController = new UserController(_context);
            _userLoginsController = new UserLoginsController(_context);
        }


        [Fact]
        public void Login_Success_RedirectsToUserLoginPage_SavesToDatabase_WithLoginDetails()
        {
            var email = "User email";

            var userDto = new UserDto()
            {
                Name = user,
                Email = email,
                DateOfBirth = new DateTime(1990, 09, 09)
            };

            var actionResult = _userController.Login(userDto);

            var actionName = "Index";
            var controllerName = "UserLogins";

            var viewResult = Assert.IsType<RedirectToActionResult>(actionResult);
            Assert.Equal(actionName, viewResult.ActionName);
            Assert.Equal(controllerName, viewResult.ControllerName);
            Assert.Equal(user, viewResult.RouteValues["user"]);
            Assert.Equal(email, viewResult.RouteValues["email"]);

            var loginActionResult = _userLoginsController.Index(userDto.Name, userDto.Email);
            var model = Assert.IsAssignableFrom<IEnumerable<LoginDto>>(((ViewResult)loginActionResult).ViewData.Model);
            Assert.Single(model);
            Assert.IsAssignableFrom<IEnumerable<LoginDto>>(model);
            Assert.True(model.Single().Successful);
            Assert.Equal(DateTime.Now.Date, (model.Single()).DateTime.Date);
        }

        public void Dispose()
        {
            var loginSaved = _context.Logins.Single(x => x.User.Name == user);
            _context.Logins.Remove(loginSaved);

            var userSaved = _context.Users.Single(x => x.Name == user);
            _context.Users.Remove(userSaved);

            _context.SaveChanges();
        }
    }
}
