using MVCAgeCheck.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVCAgeCheck.Services
{
    public class UserService
    {
        private readonly DALContext _dalContext;

        public UserService(DALContext context)
        {
            _dalContext = context;
        }

        public bool CreateLoginForUser(UserDto user)
        {
            var existingUser = _dalContext.GetUserByNameAndEmail(user.Name, user.Email);

            var successful = UserPassesAgeCheck(user);

            if (existingUser == null)
            {
                user.Logins.Single().Successful = successful;
                _dalContext.Users.Add(UserFactory.CreateUser(user));
            }

            else
            {
                var login = LoginFactory.CreateLogin(user.Logins.Single());
                login.User = existingUser;
                login.Successful = successful;
                _dalContext.Logins.Add(login);
            }

            _dalContext.SaveChanges();

            if (successful)
                return true;

            return false;
        }

        public bool CheckLoginAttempts(UserDto user)
        {
            var userLogins = GetAllLoginsByUser(user);

            var failedLoginsInLastHour = userLogins.Where(x => x.DateTime >= DateTime.Now.AddHours(-1) && !x.Successful);

            if (failedLoginsInLastHour.Count() > 3)
                return true;

            return false;
        }

        public IEnumerable<LoginDto> GetAllLoginsByUser(UserDto user)
        {
            return _dalContext.GetLogins.Where(x => x.User.Name == user.Name && x.User.Email == user.Email).Select(x => LoginFactory.CreateLoginDto(x));
        }

        public bool UserPassesAgeCheck(UserDto user)
        {
            var dateOfBirth = user.DateOfBirth;
            var dateOfBirthFor18 = DateTime.Now.AddYears(-18);

            return dateOfBirth <= dateOfBirthFor18;
        }
    }
}
