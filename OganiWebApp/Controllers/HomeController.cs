using Microsoft.AspNetCore.Mvc;
using OganiWebApp.Models.Contexts;
using OganiWebApp.Models.Entities;

namespace OganiWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext db;

        public HomeController(DataContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string email)
        {
            var subscriber = new Subscriber
            {
                Email = email
            };

            db.Subscribers.Add(subscriber);
            db.SaveChanges();

            return Json(new
            {
                error = false,
                message = "Abune Oldunuz"
            });
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]  
        public IActionResult Contact(string fullName, string email, string message)
        {
            var post = new ContactPost { 
                FullName = fullName, 
                Email = email, 
                Message = message,
                CreatedAt = DateTime.Now
            };

            db.ContactPosts.Add(post);
            db.SaveChanges();

            return Json( new { 
                error=false,
                message="5 is gunu erzinde size cavab edeceyik" 
            });
        }
    }
}
