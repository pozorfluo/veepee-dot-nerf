using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace VeepeeDotNerf.Controllers
{
    public class LandingPageController : Controller
    {
        // GET: /LandingPage/
        public IActionResult Index(string name, int ID = 1)
        {
            // return "This is my default action...";
            // return HtmlEncoder.Default.Encode(
            //     $"Hello {name}, ID: {ID}");
            ViewData["msg"] = "Hello " + name;
            ViewData["id"] = ID;
            return View();
        }

        // GET: /LandingPage/Welcome/ 
        public IActionResult Welcome()
        {
            // return "This is the Welcome action method...";
           return View();
        }
    }
}