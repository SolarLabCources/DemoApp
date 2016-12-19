using DataAccessLayer;
using System.Linq;
using System.Web.Mvc;

namespace MvcAdmin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var ctx = DemoContext.Create();
            var test = ctx.Posts.ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}