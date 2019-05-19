using MVCAgeCheck.Dtos;
using MVCAgeCheck.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MVCAgeCheck.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserService _userService;
        public UserController(DALContext context)
        {
            _userService = new UserService(context);
        }

        // GET api/user
        [HttpGet]
        public ActionResult Login()
        {
            var user = new UserDto();
            return View(user);
        }

        [HttpPost]
        public ActionResult Login([FromBody] UserDto user)
        {
            user.Logins.Add(new LoginDto()
            {
                DateTime = DateTime.Now
            });

            var success = _userService.CreateLoginForUser(user);

            if (success)
            {
                return Redirect("/");
            }

            else
            {
                var tooManyAttempts = _userService.CheckLoginAttempts(user);
                if (tooManyAttempts)
                {
                    return Redirect("/");
                }
            }

            return Redirect("/");
        }
    }
}
