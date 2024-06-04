using Microsoft.AspNetCore.Mvc;

namespace OganiWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(int x)
        {
            return View();
        }
    }
}
