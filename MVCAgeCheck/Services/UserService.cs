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

            if (existingUser == null)
                _dalContext.Users.Add(UserFactory.CreateUser(user));

            else
            {
                var login = LoginFactory.CreateLogin(user.Logins.Single());
                login.User = existingUser;
                _dalContext.Logins.Add(login);
            }


            if (UserIsUnder18(user))
                return false;

            return true;
        }

        public bool CheckLoginAttempts(UserDto user)
        {
            var userLogins = GetAllLoginsByUser(user.Name);

            var loginsInLastHour = userLogins.Where(x => x.DateTime <= DateTime.Now.AddHours(-1));

            if (loginsInLastHour.Count() > 3)
                return true;

            return false;
        }

        public List<LoginDto> GetAllLoginsByUser(string user)
        {
            return _dalContext.GetLogins.Where(x => x.User.Name == user).Select(x => LoginFactory.CreateLoginDto(x)).ToList();
        }

        public bool UserIsUnder18(UserDto user)
        {
            var dateOfBirth = user.DateOfBirth;
            var dateOfBirthFor18 = DateTime.Now.AddYears(-18);

            return dateOfBirth <= dateOfBirthFor18;
        }
    }
}
