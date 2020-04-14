using Microsoft.AspNetCore.Mvc;

namespace Amazon.Items.Web.Controllers
{
    public class HomeController : ItemsControllerBase
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