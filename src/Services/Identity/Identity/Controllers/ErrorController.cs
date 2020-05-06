using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult _500()
        {
            return View();
        }
        public IActionResult _404()
        {
            return View();
        }
        public IActionResult _403()
        {
            return View();
        }
    }
}
