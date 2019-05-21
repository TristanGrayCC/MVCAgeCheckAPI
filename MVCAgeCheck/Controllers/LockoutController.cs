using System.Collections.Generic;
using MVCAgeCheck.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MVCAgeCheck.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LockoutController : Controller
    {
        // GET api/Logins/user
        [HttpGet("{user}")]
        public ActionResult<IEnumerable<LoginDto>> Index()
        {
            return View();
        }
    }
}
