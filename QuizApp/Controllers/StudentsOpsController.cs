using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using QuizApp.Models;
using QuizApp.Models.Addons;

namespace QuizApp.Controllers
{
    public class StudentsOpsController : Controller
    {
        private readonly DBContext db = new DBContext();

        public StudentsOpsController()
        {
            LoginOps.IsUserLogin();
        }

        // GET: StudentsOps
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        [HttpPost]
        public ActionResult Index(int StudentID)
        {
            var Find = db.Students.Find(StudentID);
            if (Find != null)
            {
                Find.Verified = true;
                db.SaveChanges();
            }

            return View(db.Students.ToList());
        }

        // GET: StudentsOps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var students = db.Students.Find(id);
            if (students == null) return HttpNotFound();
            return View(students);
        }

        // GET: StudentsOps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var students = db.Students.Find(id);
            foreach (var item in db.Class.ToList())
                if (item != null)
                    if (item.Students != null)
                    {
                        var Array1 = item.Students.Split('|').ToArray();
                        var list = new List<string>(Array1);
                        for (var i = 0; i < list.Count(); i++)
                            if (list[i] != null)
                            {
                                var ID = Convert.ToInt32(list[i]);
                                if (ID == id) list.RemoveAt(i);
                            }

                        item.Students = string.Join("|", list);
                        db.SaveChanges();
                    }

            if (students == null) return HttpNotFound();
            db.Students.Remove(students);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: StudentsOps/Delete/5


        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}