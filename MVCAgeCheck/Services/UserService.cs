using DotNetCoreAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetCoreAPI.Services
{
    public class UserService
    {
        private readonly DALContext _dalContext;
        private const string success = "Success";
        private const string failure = "Failed";

        public UserService(DALContext context)
        {
            _dalContext = context;
        }

        public string DeleteUser(string name)
        {
            var User = _dalContext.GetUsers.Single(x => x.Name == name);
            try
            {
                _dalContext.RemoveUser(User);
                _dalContext.SaveChanges();
                return success;
            }
            catch
            {
                return failure;
            }
        }

        public string CreateUser(UserDto UserDto)
        {
            var User = UserFactory.CreateUser(UserDto);

            try
            {
                _dalContext.AddUser(User);
                _dalContext.SaveChanges();
                return success;
            }
            catch
            {
                return failure;
            }
        }

        public string DeleteLogin(string name, DateTime date)
        {
            var login = _dalContext.GetLogins.Single(x => x.User.Name == name && x.DateTime == date);
            try
            {
                _dalContext.RemoveLogin(login);
                _dalContext.SaveChanges();
                return success;
            }
            catch
            {
                return failure;
            }
        }

        public string CreateLogin(LoginDto loginDto)
        {
            var login = LoginFactory.CreateLogin(loginDto);

            try
            {
                _dalContext.AddLogin(login);
                _dalContext.SaveChanges();
                return success;
            }
            catch
            {
                return failure;
            }
        }

        public List<UserDto> GetAllUsers()
        {
            return _dalContext.GetUsers.Select(x => UserFactory.CreateUserDto(x)).ToList();
        }

        public List<LoginDto> GetAllLoginsByUser(string user)
        {
            return _dalContext.GetLogins.Where(x => x.User.Name == user).Select(x => LoginFactory.CreateLoginDto(x)).ToList();
        }
    }
}
