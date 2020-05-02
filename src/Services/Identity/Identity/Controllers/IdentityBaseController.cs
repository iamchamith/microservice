using App.SharedKernel.Extension;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Identity.Controllers
{
    public class IdentityBaseController : Controller
    {
        protected IActionResult RenderErrorView(int statusCode)
        {
            switch (statusCode)
            {
                case 401:
                    return View("_401");
                default:
                    return View("_401");
            }
        }
        protected (int, object) ActionResultFilter(IActionResult actionResult)
        {

            var resultOk = actionResult as OkObjectResult;
            if (!resultOk.IsNull())
            {
                return (200, resultOk.Value);
            }
            var resultOke = actionResult as OkResult;
            if (!resultOke.IsNull())
            {
                return (200, "success");
            }
            var resultBad = actionResult as BadRequestObjectResult;
            if (!resultBad.IsNull())
            {
                return (400, resultBad.Value);
            }
            var resultUnAuthorized = actionResult as UnauthorizedObjectResult;
            if (!resultUnAuthorized.IsNull())
            {
                return (401, resultUnAuthorized.Value);
            }
            return (500, resultBad.Value);
        }
        [HttpGet]
        public IActionResult _401()
        {
            return View("_401");
        }
    }
}
