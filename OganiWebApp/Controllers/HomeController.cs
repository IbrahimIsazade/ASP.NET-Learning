using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using OganiWebApp.Models.Contexts;
using OganiWebApp.Models.Entities;
using System.Diagnostics;

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

        [HttpPost]
        public async Task<IActionResult> Subscribe(string email)
        {
            var person = await db.Subscribers.FirstOrDefaultAsync(u => u.Email == email);

            if (person is not null)
            {
                return Json(new
                {
                    error = true,
                    message = "Artiq abune olmusunuz"
                });
            }

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
    }
}
