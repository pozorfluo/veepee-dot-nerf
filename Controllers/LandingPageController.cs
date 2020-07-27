using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace veepee_dot_nerf.Controllers
{
    public class LandingPageController : Controller
    {
        // 
        // GET: /LandingPage/

        public string Index()
        {
            return "This is my default action...";
        }

        // 
        // GET: /LandingPage/Welcome/ 
        public IActionResult Welcome()
        {
            // return "This is the Welcome action method...";
           return View();
        }
    }
}