using Microsoft.AspNetCore.Mvc;

namespace InterviewChallenge.API.Controllers
{
    public class BakingSchedulesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
