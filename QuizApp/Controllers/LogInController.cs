using System;
using System.Web.Mvc;
using QuizApp.Models;
using QuizApp.Models.Addons;

namespace QuizApp.Controllers
{
    public class LogInController : Controller
    {
        private readonly DBContext db = new DBContext();

        // GET: LogIn
        public ActionResult Admin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Admin(string username, string password)
        {
            var LoginUp = LoginOps.Login(username, password);
            if (LoginUp)
            {
                Session["login"] = "true";
                return RedirectToAction("Index", "Home");
            }

            TempData["LoginError"] = "Şifre veya kullanıcı adı yanlış";
            return RedirectToAction("Admin", "LogIn");
        }

        public ActionResult Student()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Student(string Mail, string password)
        {
            var LoginUp = StudentLogin.StudentsLogin(Mail, password);
            if (LoginUp)
            {
                Session["login"] = "true";
                return RedirectToAction("Home", "Students");
            }

            TempData["LoginError"] = "Şifre veya kullanıcı adı yanlış";
            return RedirectToAction("Student", "LogIn");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(string name, string lastname, string mail, string phone, string password,
            Students students)
        {
            if (StudentLogin.IsExist(mail))
            {
                students.Password = MD5.MD5eDonustur(password);
                students.FirsName = name;
                students.LastName = lastname;
                students.Mail = mail;
                students.PhoneNumber = phone;
                students.CratedDate = DateTime.Now;
                students.Verified = false;
                students.Type = Students.LoginType.Normal;
                db.Students.Add(students);
                db.SaveChanges();
                return RedirectToAction("Admin", "LogIn");
            }

            ViewBag.hata = true;
            return View();
        }

        public JsonResult IsExist(string mail)
        {
            var Exist = StudentLogin.IsExist(mail);
            return Json(Exist, JsonRequestBehavior.AllowGet);
        }
    }
}