using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using InterviewChallenge.API.Context;

namespace InterviewChallenge.API.Controllers
{
    [ApiController]
    [Route("api/authenticate")]
    public class AuthenticationController : Controller
    {
        private readonly DBContext dBContext;
        public AuthenticationController(DBContext db)
        {
            this.dBContext = db;
        }


        //[HttpPost]
        //[Route("{login}")]
        //public async Task<IActionResult> Login(LoginRequest request)
        //{
        //}


        //private bool ValidateLoginRequst(LoginRequest request)
        //{
        //}
    }
}
