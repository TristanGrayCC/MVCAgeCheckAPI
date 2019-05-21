using System.Collections.Generic;
using MVCAgeCheck.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MVCAgeCheck.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LockoutController : Controller
    {
        // GET api/Lockout
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}
