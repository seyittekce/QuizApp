using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using QuizApp.Models;
using QuizApp.Models.Addons;

namespace QuizApp.Controllers
{
    public class ClassController : Controller
    {
        private readonly DBContext db = new DBContext();

        public ClassController()
        {
            LoginOps.IsUserLogin();
        }

        // GET: Class
        public ActionResult Index()
        {
            return View(db.Class.ToList());
        }

        public ActionResult CreateClass()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateClass(Class classes, string[] Student1, string[] Library1)
        {
            if (ModelState.IsValid)
            {
                classes.Students = string.Join("|", Student1);
                classes.QuizLib = string.Join("|", Library1);
                classes.CratedDate = DateTime.Now;
                db.Class.Add(classes);
                db.SaveChanges();
                var log = new Logger(new StandartLog());
                log.LogEkle(classes.Name + " eklendi");
            }

            return View();
        }

        public ActionResult Details(int id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var Classes = db.Class.Find(id);
            if (Classes == null) return HttpNotFound();
            return View(Classes);
        }

        public ActionResult Delete(int id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var Classes = db.Class.Find(id);
            if (Classes == null) return HttpNotFound();
            db.Class.Remove(Classes);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}