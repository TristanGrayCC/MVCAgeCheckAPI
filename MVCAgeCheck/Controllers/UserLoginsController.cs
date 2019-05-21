using System.Collections.Generic;
using MVCAgeCheck.Dtos;
using MVCAgeCheck.Services;
using Microsoft.AspNetCore.Mvc;

namespace MVCAgeCheck.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginsController : Controller
    {
        private readonly UserService _userService;
        public UserLoginsController(DALContext context)
        {
            _userService = new UserService(context);
        }

        // GET api/Logins/user
        [HttpGet("{user}")]
        public ActionResult<IEnumerable<LoginDto>> Index(string user)
        {
            var logins = _userService.GetAllLoginsByUser(user);
            return View(logins);
        }
    }
}
