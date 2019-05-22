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

        // GET api/Logins/user/email
        [HttpGet("{user}/{email}")]
        public ActionResult Index(string user, string email)
        {
            var logins = _userService.GetAllLoginsByUser(user, email);
            return View(logins);
        }
    }
}
