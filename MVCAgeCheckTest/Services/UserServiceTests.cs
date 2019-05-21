using MVCAgeCheck;
using MVCAgeCheck.Dtos;
using MVCAgeCheck.Models;
using MVCAgeCheck.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace APITest.Services
{
    public class UserServicesTests
    {
        private readonly UserService _underTest;
        private readonly Mock<DALContext> _context;

        public UserServicesTests()
        {
            _context = new Mock<DALContext>();
            _underTest = new UserService(_context.Object);
        }

        [Fact]
        public void GetAllLoginsByUser_ReturnsOnlyCorrectLoginsAsDtos()
        {
            var doB = new DateTime(2019, 01, 01);
            var userNameToSearch = "Name";

            var listOfUserLogins = new List<DateTime>
            {
                new DateTime(2019, 01, 01), new DateTime(2019, 01, 02), new DateTime(2019, 01, 03)
            };
            var notUserListOfLogins = new List<DateTime>
            {
                new DateTime(2019, 01, 04), new DateTime(2019, 01, 05)
            };

            var user = new User
            {
                Name = userNameToSearch,
                DateOfBirth = doB
            };
            var anotherUser = new User
            {
                Name = "Not this",
                DateOfBirth = doB
            };

            var allLogins = new List<Login>();

            foreach (var loginTime in listOfUserLogins)
            {
                allLogins.Add(new Login
                {
                    DateTime = loginTime,
                    User = user
                });
            }

            foreach (var loginTime in notUserListOfLogins)
            {
                allLogins.Add(new Login
                {
                    DateTime = loginTime,
                    User = anotherUser
                });
            }

            _context.Setup(x => x.GetLogins).Returns(allLogins.AsQueryable());

            var result = _underTest.GetAllLoginsByUser(userNameToSearch).ToList();

            Assert.NotNull(result);
            Assert.Equal(typeof(LoginDto), result.First().GetType());
            Assert.Equal(listOfUserLogins.Count, result.Count);
        }
    }
}
