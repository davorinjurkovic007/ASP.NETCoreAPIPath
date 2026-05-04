using Microsoft.AspNetCore.Mvc;

namespace TailwindMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
