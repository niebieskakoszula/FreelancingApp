using Microsoft.AspNetCore.Mvc;

namespace FreelancingApp.WebApp.Controllers
{
    [Route("[controller]")]
    public class AppUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
