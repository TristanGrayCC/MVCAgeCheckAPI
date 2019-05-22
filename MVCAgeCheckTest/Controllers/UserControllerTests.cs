using MVCAgeCheck;
using Moq;
using Xunit;
using MVCAgeCheck.Controllers;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Mvc;

namespace MVCAgeCheckTest.Controllers
{
    public class UserControllerTests
    {
        private readonly UserController _underTest;
        private readonly Mock<DALContext> _context;
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public UserControllerTests()
        {
            _context = new Mock<DALContext>();
            _underTest = new UserController(_context.Object);
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }


        [Fact]
        public async Task GetIndex()
        {
            _underTest.ControllerContext.HttpContext = _contextMock.Object;
            var actionResult = await _underTest.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(actionResult);
            Assert.IsAssignableFrom<Order>(viewResult.ViewData.Model);
        }
    }
}
