using Xunit;
using MVCAgeCheck.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace MVCAgeCheckTest.Controllers
{
    public class AgeVerificationErrorControllerTests
    {
        private readonly AgeVerificationErrorController _underTest;

        public AgeVerificationErrorControllerTests()
        {
            _underTest = new AgeVerificationErrorController();
        }


        [Fact]
        public void GetIndex()
        {
            var actionResult = _underTest.Index();

            Assert.IsType<ViewResult>(actionResult);
        }
    }
}
