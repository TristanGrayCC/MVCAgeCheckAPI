using MVCAgeCheck;
using MVCAgeCheck.Dtos;
using MVCAgeCheck.Models;
using MVCAgeCheck.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MVCAgeCheckTest.DatabaseTests
{
    public class DatabaseTest
    {
        [Fact]
        public void CreateLogin_AddsToDatabase()
        {
            var options = new DbContextOptionsBuilder<DALContext>()
                .UseInMemoryDatabase(databaseName: "CreateLoginAddsToDatabase")
                .Options;

            var dateTime = new DateTime(2019, 01, 01);

            var dateToSearch = new Login
            {
                DateTime = dateTime
            };

            using (var context = new DALContext(options))
            {
                var service = new UserService(context);
                service.CreateLoginForUser(new UserDto()
                {
                    Logins = new List<LoginDto>()
                    {
                        new LoginDto()
                        {
                            DateTime = dateToSearch.DateTime
                        }
                    }
                });
            }

            using (var context = new DALContext(options))
            {
                Assert.Equal(1, context.Logins.Count());
                Assert.Equal(dateTime, context.Logins.Single().DateTime);
            }
        }

        [Fact]
        public void GetAllLoginsByUser_ReturnsLoginsForUser()
        {
            var options = new DbContextOptionsBuilder<DALContext>()
                .UseInMemoryDatabase(databaseName: "GetAllLoginsByUser")
                .Options;

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

            using (var context = new DALContext(options))
            {
                context.Users.Add(user);
                context.Users.Add(anotherUser);

                foreach (var login in allLogins)
                {
                    context.Logins.Add(login);
                }
                context.SaveChanges();
            }

            using (var context = new DALContext(options))
            {
                var service = new UserService(context);
                var result = service.GetAllLoginsByUser(userNameToSearch);
                Assert.Equal(3, result.Count());
            }
        }
    }
}
