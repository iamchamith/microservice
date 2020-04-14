using Microsoft.AspNetCore.Mvc;

namespace Amazon.Order.Web.Controllers
{
    public class HomeController : OrderControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}