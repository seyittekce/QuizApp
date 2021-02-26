using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuizApp.Models;
using QuizApp.Models.Addons;

namespace QuizApp.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly DBContext db = new DBContext();

        public QuestionsController()
        {
            LoginOps.IsUserLogin();
        }

        // GET: Questions
        public ActionResult Index()
        {
            return PartialView(db.Question.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Questions asking, string[] fields, string trueanswer, string multiple,
            string MultipleQuestion, string Multipleexp, string truefalse, string trueQuestion, string options,
            string trueexp, string shoranswers, string shortQuestion, string shortAnswer, string shortExplan,
            string File, string FileQuestion, HttpPostedFileBase FileUpload, string paragraph, string Parag)
        {
            if (ModelState.IsValid)
            {
                //asking.CratedDate = DateTime.Now;
                if (multiple != null)
                {
                    var ekel = string.Join("|", fields);
                    asking.True_Answers = trueanswer;
                    asking.Type = Questions.QuestionsTypes.Multiple;
                    asking.Question = MultipleQuestion;
                    asking.Explanation = Multipleexp;
                    asking.Answers = ekel;
                    db.Question.Add(asking);
                    db.SaveChanges();
                }

                if (truefalse != null)
                {
                    asking.Type = Questions.QuestionsTypes.Truefalse;
                    asking.Question = trueQuestion;
                    asking.Explanation = trueexp;
                    asking.Answers = options;
                    db.Question.Add(asking);
                    db.SaveChanges();
                }

                if (shoranswers != null)
                {
                    asking.Type = Questions.QuestionsTypes.Shrots;
                    asking.Question = shortQuestion;
                    asking.Explanation = shortExplan;
                    asking.Answers = shortAnswer;
                    db.Question.Add(asking);
                    db.SaveChanges();
                }

                if (File != null)
                {
                    asking.Type = Questions.QuestionsTypes.File;
                    asking.Question = FileQuestion;
                    asking.Explanation = "";
                    var files = DateTime.Now.ToShortDateString() + FileUpload.FileName;
                    var path = Path.Combine(Server.MapPath("~/Document"), files);
                    FileUpload.SaveAs(path);
                    asking.Answers = files;
                    db.Question.Add(asking);
                    db.SaveChanges();
                }

                if (Parag != null)
                {
                    asking.Type = Questions.QuestionsTypes.Paragraph;
                    asking.Question = paragraph;
                    asking.Explanation = "";
                    asking.Answers = "";
                    db.Question.Add(asking);
                    db.SaveChanges();
                }

                var log = new Logger(new StandartLog());
                log.LogEkle("Soru Ekledi");
                return Redirect("/Questions/Index");
            }

            return View();
        }

        // GET: Questions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var questions = db.Question.Find(id);
            foreach (var item in db.QuizLibrary.ToList())
                if (item != null)
                    if (item.Questions != null)
                    {
                        var Array1 = item.Questions.Split('|').ToArray();
                        var list = new List<string>(Array1);
                        for (var i = 0; i < list.Count(); i++)
                            if (list[i] != null)
                            {
                                var ID = Convert.ToInt32(list[i]);
                                if (ID == id) list.RemoveAt(i);
                            }

                        item.Questions = string.Join("|", list);
                        db.SaveChanges();
                    }

            if (questions == null) return HttpNotFound();
            db.Question.Remove(questions);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Questions/Delete/5
        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}