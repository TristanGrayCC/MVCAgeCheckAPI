using MVCAgeCheck;
using Moq;
using Xunit;
using MVCAgeCheck.Controllers;
using Microsoft.AspNetCore.Mvc;
using MVCAgeCheck.Dtos;

namespace MVCAgeCheckTest.Controllers
{
    public class UserLoginsControllerTests
    {
        private readonly UserLoginsController _underTest;
        private readonly Mock<DALContext> _context;

        public UserLoginsControllerTests()
        {
            _context = new Mock<DALContext>();
            _underTest = new UserLoginsController(_context.Object);
        }


        [Fact]
        public void GetIndex()
        {
            var userDto = new UserDto();

            var actionResult = _underTest.Index(userDto);

            var viewResult = Assert.IsType<ViewResult>(actionResult);
            Assert.IsType<LoginDto>(viewResult.ViewData.Model);
        }
    }
}
