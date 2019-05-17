using System.Collections.Generic;
using MVCAgeCheck.Dtos;
using MVCAgeCheck.Services;
using Microsoft.AspNetCore.Mvc;

namespace MVCAgeCheck.Controllers
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
