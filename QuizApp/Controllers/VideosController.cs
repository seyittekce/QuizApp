using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using QuizApp.Models;
using QuizApp.Models.Addons;

namespace QuizApp.Controllers
{
    public class VideosController : Controller
    {
        private readonly DBContext db = new DBContext();

        public VideosController()
        {
            LoginOps.IsUserLogin();
        }

        // GET: Videos
        public ActionResult Videos()
        {
            return View(db.VideosAndArticles.Where(x => x.Type == VideoAndArticle.Types.Video).ToList());
        }

        public ActionResult CreateVideo()
        {
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult CreateVideo(VideoAndArticle videoAndArticle)
        {
            videoAndArticle.CratedDate = DateTime.Now;
            videoAndArticle.Yazar = LoginOps.GetLoginUser.Name + " " + LoginOps.GetLoginUser.LastName;
            videoAndArticle.Type = VideoAndArticle.Types.Video;
            db.VideosAndArticles.Add(videoAndArticle);
            db.SaveChanges();
            return RedirectToAction("Videos");
        }

        public ActionResult VideoDetails(int ID)
        {
            if (ID == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var articles = db.VideosAndArticles.Find(ID);
            if (articles == null) return HttpNotFound();
            return View(articles);
        }

        public ActionResult Delete(int ID)
        {
            if (ID == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var articles = db.VideosAndArticles.Find(ID);
            db.VideosAndArticles.Remove(articles);
            db.SaveChanges();
            if (articles == null) return HttpNotFound();
            return RedirectToAction("Videos");
        }
    }
}