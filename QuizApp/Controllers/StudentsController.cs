using System.Linq;
using System.Net;
using System.Web.Mvc;
using QuizApp.Models;
using QuizApp.Models.Addons;

namespace QuizApp.Controllers
{
    public class StudentsController : Controller
    {
        private readonly DBContext db = new DBContext();

        public StudentsController()
        {
            StudentLogin.IsStudentLogin();
        }

        // GET: Students
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult ExamList()
        {
            return View(ListingExam.ListExam());
        }

        public ActionResult StudentProfile()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            StudentLogin.UserSignOut();
            return RedirectToRoute("LogIn/Admin");
        }

        public ActionResult Articles()
        {
            return View(db.VideosAndArticles.Where(x => x.Type == VideoAndArticle.Types.Article).ToList());
        }

        public ActionResult Videos()
        {
            return View(db.VideosAndArticles.Where(x => x.Type == VideoAndArticle.Types.Video).ToList());
        }

        public ActionResult ArticlesShow(int ID)
        {
            if (ID == 0) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var VideosAndArticleses = db.VideosAndArticles.Find(ID);
            if (VideosAndArticleses == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            return View(VideosAndArticleses);
        }

        public ActionResult Exam()
        {
            return View();
        }
    }
}