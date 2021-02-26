using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using QuizApp.Models;
using QuizApp.Models.Addons;

namespace QuizApp.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly DBContext _db = new DBContext();

        public ArticlesController()
        {
            LoginOps.IsUserLogin();
        }

        // GET: Articles
        [HttpGet]
        public ActionResult Articles()
        {
            return View(_db.VideosAndArticles.Where(x => x.Type == VideoAndArticle.Types.Article).ToList());
        }

        public ActionResult CreateArticles()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult CreateArticle(VideoAndArticle Articles)
        {
            Articles.CratedDate = DateTime.Now;
            Articles.Yazar = LoginOps.GetLoginUser.Name + " " + LoginOps.GetLoginUser.LastName;
            Articles.Type = VideoAndArticle.Types.Article;
            _db.VideosAndArticles.Add(Articles);
            _db.SaveChanges();
            return RedirectToAction("Articles");
        }

        public ActionResult ArticlesDetails(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var articles = _db.VideosAndArticles.Find(id);
            if (articles == null) return HttpNotFound();
            return View(articles);
        }

        public ActionResult Delete(int id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var articles = _db.VideosAndArticles.Find(id);
            _db.VideosAndArticles.Remove(articles);
            _db.SaveChanges();
            if (articles == null) return HttpNotFound();
            return RedirectToAction("Articles");
        }

        public ActionResult Videos()
        {
            return View(_db.VideosAndArticles.Where(x => x.Type == VideoAndArticle.Types.Video).ToList());
        }
    }
}