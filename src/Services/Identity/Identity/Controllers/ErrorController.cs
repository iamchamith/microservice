using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers
{
    [Route("error")]
    public class ErrorController : Controller
    {
        [Route("500")]
        public IActionResult _500()
        {
            return View();
        }
        [Route("404")]
        public IActionResult _404()
        {
            return View();
        }
        [Route("403")]
        public IActionResult _403()
        {
            return View();
        }
    }
}
