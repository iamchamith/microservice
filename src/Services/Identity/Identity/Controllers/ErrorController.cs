using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Identity.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }
        public IActionResult _500()
        {
            try
            {
                var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
                _logger.LogError($"The path {exceptionDetails.Path} thew an exception " +
                    $"{exceptionDetails.Error}");
                return View();
            }
            catch (System.Exception e)
            {

                throw;
            }
    
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
