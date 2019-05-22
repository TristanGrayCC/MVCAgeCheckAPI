using Xunit;
using MVCAgeCheck.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace MVCAgeCheckTest.Controllers
{
    public class LockoutControllerTests
    {
        private readonly LockoutController _underTest;

        public LockoutControllerTests()
        {
            _underTest = new LockoutController();
        }


        [Fact]
        public void GetIndex()
        {
            var actionResult = _underTest.Index();

            Assert.IsType<ViewResult>(actionResult);
        }
    }
}
