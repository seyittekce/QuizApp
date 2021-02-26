using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using QuizApp.Models;

namespace QuizApp.Controllers
{
    public class LibrariesController : Controller
    {
        private readonly DBContext db = new DBContext();

        // GET: Libraries
        public ActionResult Index()
        {
            return View(db.QuizLibrary.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Libraries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LibraryID,Name,Questions,CratedDate,Comment")]
            Library library, string[] Question)
        {
            if (ModelState.IsValid)
            {
                library.Questions = string.Join("|", Question);
                library.CratedDate = DateTime.Now;
                db.QuizLibrary.Add(library);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(library);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var library = db.QuizLibrary.Find(id);
            library.Question = library.Questions.Split('|').ToArray();
            if (library == null) return HttpNotFound();
            return View(library);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LibraryID,Name,Questions,CratedDate,Comment")]
            Library library, string[] Question)
        {
            if (ModelState.IsValid)
            {
                library.Questions = string.Join("|", Question);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(library);
        }

        // GET: Libraries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var library = db.QuizLibrary.Find(id);
            foreach (var item in db.Class.ToList())
                if (item != null)
                    if (item.QuizLib != null)
                    {
                        var Array1 = item.QuizLib.Split('|').ToArray();
                        var list = new List<string>(Array1);
                        for (var i = 0; i < list.Count(); i++)
                            if (list[i] != null)
                            {
                                var ID = Convert.ToInt32(list[i]);
                                if (ID == id) list.RemoveAt(i);
                            }

                        item.QuizLib = string.Join("|", list);
                        db.SaveChanges();
                    }

            if (library == null) return HttpNotFound();
            db.QuizLibrary.Remove(library);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Libraries/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}