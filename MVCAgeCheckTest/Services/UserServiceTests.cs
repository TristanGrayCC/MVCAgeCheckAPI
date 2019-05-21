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

        [Fact]
        public void UserPassesAgeCheck_ReturnsFalseIfUnder18_TrueIfOver18()
        {
            var date18YearsAgo = DateTime.Now.AddYears(-18);

            var doBOver18 = date18YearsAgo.AddDays(-1);
            var doBUnder18 = date18YearsAgo.AddDays(1);

            var userOver18 = new UserDto
            {
                DateOfBirth = doBOver18
            };

            var userUnder18 = new UserDto
            {
                DateOfBirth = doBUnder18
            };

            var resultOver = _underTest.UserPassesAgeCheck(userOver18);
            var resultUnder = _underTest.UserPassesAgeCheck(userUnder18);

            Assert.True(resultOver);
            Assert.False(resultUnder);
        }

        [Fact]
        public void GetAllLoginsByUser_IfOverThreeFailedInOneHour_ReturnTrue()
        {
            var userNameToSearch = "Name";

            var listOfUserLogins = new List<DateTime>
            {
                DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now
            };

            var userDto = new UserDto
            {
                Name = userNameToSearch
            };

            var user = new User
            {
                Name = userNameToSearch
            };

            var allLogins = new List<Login>();

            foreach (var loginTime in listOfUserLogins)
            {
                allLogins.Add(new Login
                {
                    DateTime = DateTime.Now,
                    User = user
                });
            }

            _context.Setup(x => x.GetLogins).Returns(allLogins.AsQueryable());

            var result = _underTest.CheckLoginAttempts(userDto);

            Assert.True(result);
        }

        [Fact]
        public void GetAllLoginsByUser_IfThreeFailedInOneHour_ReturnFalse()
        {
            var userNameToSearch = "Name";

            var listOfUserLogins = new List<DateTime>
            {
                DateTime.Now, DateTime.Now, DateTime.Now
            };

            var userDto = new UserDto
            {
                Name = userNameToSearch
            };

            var user = new User
            {
                Name = userNameToSearch
            };

            var allLogins = new List<Login>();

            foreach (var loginTime in listOfUserLogins)
            {
                allLogins.Add(new Login
                {
                    DateTime = DateTime.Now,
                    User = user
                });
            }

            _context.Setup(x => x.GetLogins).Returns(allLogins.AsQueryable());

            var result = _underTest.CheckLoginAttempts(userDto);

            Assert.False(result);
        }

        [Fact]
        public void GetAllLoginsByUser_IfUnderThreeFailedInOneHour_ReturnFalse()
        {
            var userNameToSearch = "Name";

            var listOfUserLogins = new List<DateTime>
            {
                DateTime.Now
            };

            var userDto = new UserDto
            {
                Name = userNameToSearch
            };

            var user = new User
            {
                Name = userNameToSearch
            };

            var allLogins = new List<Login>();

            foreach (var loginTime in listOfUserLogins)
            {
                allLogins.Add(new Login
                {
                    DateTime = DateTime.Now,
                    User = user
                });
            }

            _context.Setup(x => x.GetLogins).Returns(allLogins.AsQueryable());

            var result = _underTest.CheckLoginAttempts(userDto);

            Assert.False(result);
        }

        [Fact]
        public void CreateLogin_AddsNewUserToDatabase_ReturnsTrue()
        {
            var dateTime = new DateTime(2019, 01, 01);

            var dateToSearch = new Login
            {
                DateTime = dateTime
            };

            var service = new UserService(_context.Object);
            var result = service.CreateLoginForUser(new UserDto()
            {
                Logins = new List<LoginDto>()
                    {
                        new LoginDto()
                        {
                            DateTime = dateToSearch.DateTime

                        }
                    }
            });

            Assert.True(result);
        }
    }
}
