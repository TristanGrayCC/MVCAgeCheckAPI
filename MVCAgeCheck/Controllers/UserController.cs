using MVCAgeCheck.Dtos;
using MVCAgeCheck.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
        public ActionResult Login([FromForm] UserDto user)
        {
            user.Logins = new List<LoginDto>()
            {
                new LoginDto()
                {
                    DateTime = DateTime.Now
                }
            };

            var success = _userService.CreateLoginForUser(user);

            if (success)
            {
                return RedirectToAction("Index", "UserLogins", new { user = user.Name });
            }

            else
            {
                var tooManyAttempts = _userService.CheckLoginAttempts(user);
                if (tooManyAttempts)
                {
                    return Redirect("/api/LockOut");
                }
            }

            return Redirect("/api/AgeVerificationError");
        }
    }
}
