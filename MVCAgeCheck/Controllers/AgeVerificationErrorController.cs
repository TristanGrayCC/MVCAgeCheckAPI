using System.Collections.Generic;
using MVCAgeCheck.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MVCAgeCheck.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgeVerificationErrorController : Controller
    {
        // GET api/AgeVerificationError
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}
