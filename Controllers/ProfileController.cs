using Microsoft.AspNetCore.Mvc;

namespace teamWcrh.Controllers
{
    public class ProfileController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
    }
}