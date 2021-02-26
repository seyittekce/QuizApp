using System.Web.Mvc;
using QuizApp.Models.Addons;

namespace QuizApp.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            LoginOps.IsUserLogin();
        }

        public ActionResult Index()
        {
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