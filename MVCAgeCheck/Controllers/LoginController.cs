using System;
using System.Collections.Generic;
using DotNetCoreAPI.Dtos;
using DotNetCoreAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly UserService _userService;
        public LoginsController(DALContext context)
        {
            _userService = new UserService(context);
        }

        // GET api/Logins/categories
        [HttpGet("{user}")]
        public ActionResult<IEnumerable<LoginDto>> Get(string user)
        {
            return _userService.GetAllLoginsByUser(user);
        }

        // POST api/Logins
        [HttpPost]
        public void Post([FromBody] DateTime date)
        {
            var newLogin = new LoginDto
            {
                DateTime = date
            };
            _userService.CreateLogin(newLogin);
        }

        // DELETE api/Logins/name
        [HttpDelete("{name}")]
        public void Delete(string name, DateTime date)
        {
            _userService.DeleteLogin(name, date);
        }
    }
}
