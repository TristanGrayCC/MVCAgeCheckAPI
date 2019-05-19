using System;
using System.Collections.Generic;
using MVCAgeCheck.Dtos;
using MVCAgeCheck.Services;
using Microsoft.AspNetCore.Mvc;

namespace MVCAgeCheck.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : Controller
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
    }
}
