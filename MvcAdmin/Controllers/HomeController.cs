using System.Web.Mvc;
using BusinessLogic.Abstraction;
using BusinessLogic.Objects;

namespace MvcAdmin.Controllers
{
    public class HomeController : Controller
    {
        private IPostManager _postManager;
        public HomeController(IPostManager postManager)
        {
            _postManager = postManager;
        }

        public ActionResult Index()
        {
            _postManager.AddPost(new AddPostDto
            {
                Title = "Новый пост",
                Description = "Описание поста"
            });

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