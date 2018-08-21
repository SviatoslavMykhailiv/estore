using Microsoft.AspNetCore.Mvc;

namespace estore.web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}