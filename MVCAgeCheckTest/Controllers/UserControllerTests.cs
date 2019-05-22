using MVCAgeCheck;
using Moq;
using Xunit;
using MVCAgeCheck.Controllers;
using Microsoft.AspNetCore.Mvc;
using MVCAgeCheck.Dtos;
using System;
using MVCAgeCheck.Models;
using System.Linq;

namespace MVCAgeCheckTest.Controllers
{
    public class UserControllerTests
    {
        private readonly UserController _underTest;
        private readonly Mock<DALContext> _context;

        public UserControllerTests()
        {
            _context = new Mock<DALContext>();
            _underTest = new UserController(_context.Object);
        }


        [Fact]
        public void GetIndex()
        {
            var actionResult = _underTest.Index();

            var viewResult = Assert.IsType<ViewResult>(actionResult);
            Assert.IsType<UserDto>(viewResult.ViewData.Model);
        }

        [Fact]
        public void Login_Success_RedirectsToUserLoginPage_WithValidUserDetails()
        {
            var name = "User name";
            var email = "User email";

            var userDto = new UserDto()
            {
                Name = name,
                Email = email
            };

            var actionResult = _underTest.Login(userDto);

            var actionName = "Index";
            var controllerName = "UserLogins";

            var viewResult = Assert.IsType<RedirectToActionResult>(actionResult);
            Assert.Equal(actionName, viewResult.ActionName);
            Assert.Equal(controllerName, viewResult.ControllerName);
            Assert.Equal(name, viewResult.RouteValues["user"]);
            Assert.Equal(email, viewResult.RouteValues["email"]);
        }

        [Fact]
        public void Login_LockoutError_RedirectsToLockoutPage()
        {
            var name = "User name";
            var email = "User email";

            var userDto = new UserDto()
            {
                Name = name,
                Email = email
            };

            var user = new User()
            {
                Name = name,
                Email = email
            };
            
            _context.Setup(x => x.GetLogins).Returns(new Login[]
            {
                new Login(){ DateTime = DateTime.Now, User = user, Successful = false },
                new Login(){ DateTime = DateTime.Now, User = user, Successful = false },
                new Login(){ DateTime = DateTime.Now, User = user, Successful = false },
                new Login(){ DateTime = DateTime.Now, User = user, Successful = false }
            }.AsQueryable);

            var actionResult = _underTest.Login(userDto);
            
            var actionName = "Index";
            var controllerName = "Lockout";

            var viewResult = Assert.IsType<RedirectToActionResult>(actionResult);
            Assert.Equal(actionName, viewResult.ActionName);
            Assert.Equal(controllerName, viewResult.ControllerName);
        }

        [Fact]
        public void Login_LockoutError_RedirectsToAgeVerificationErrorPage()
        {
            var user = new UserDto()
            {
                DateOfBirth = DateTime.Now
            };
            var actionResult = _underTest.Login(user);

            var actionName = "Index";
            var controllerName = "AgeVerificationError";

            var viewResult = Assert.IsType<RedirectToActionResult>(actionResult);
            Assert.Equal(actionName, viewResult.ActionName);
            Assert.Equal(controllerName, viewResult.ControllerName);
        }
    }
}
