using System.Collections.Generic;
using DotNetCoreAPI.Dtos;
using DotNetCoreAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(DALContext context)
        {
            _userService = new UserService(context);
        }

        // GET api/user
        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> Get()
        {
            return _userService.GetAllUsers();
        }
    }
}
