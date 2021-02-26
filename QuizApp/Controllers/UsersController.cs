using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using QuizApp.Models;
using QuizApp.Models.Addons;

namespace QuizApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly DBContext db = new DBContext();

        public UsersController()
        {
            LoginOps.IsUserLogin();
        }

        public Users GetUser(int? ID)
        {
            var users = db.Users.Find(ID);
            users.Password = "";
            return users;
        }

        // GET: Users
        public ActionResult Index()
        {
            return PartialView(db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var users = db.Users.Find(id);
            if (users == null) return HttpNotFound();
            return Json(GetUser(id), JsonRequestBehavior.AllowGet);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return PartialView();
            
        }

        // POST: Users/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "ID,Name,LastName,NickName,Password,Email,Disable,PhoneNumber,CratedDate,First")]
            Users users)
        {
            if (ModelState.IsValid)
            {
                if (LoginOps.IsExist(users.NickName))
                {
                    users.Password = MD5.MD5eDonustur(users.Password);
                    users.CratedDate = DateTime.Now;
                    users.First = false;
                    users.Disable = false;
                    db.Users.Add(users);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.hata = true;
                return View(users);
            }

            return View(users);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var users = db.Users.Find(id);
            if (users == null) return HttpNotFound();
            return PartialView(users);
        }

        // POST: Users/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "ID,Name,LastName,NickName,Password,Email,Disable,PhoneNumber,CratedDate,First")]
            Users users)
        {
            if (ModelState.IsValid)
            {
                users.First = true;
                db.Users.Attach(users);
                db.Entry(users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(users);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var users = db.Users.Find(id);
            if (users == null) return HttpNotFound();
            db.Users.Remove(users);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Users/Delete/5
        public ActionResult UserProfile()
        {
            return PartialView(LoginOps.GetLoginUser);
        }

        public ActionResult UserSettings()
        {
            return PartialView(LoginOps.GetLoginUser);
        }

        [HttpPost]
        public ActionResult UserSettings(Users users)
        {
            if (users.Password == null) users.Password = LoginOps.GetLoginUser.Password;
            users.Password = MD5.MD5eDonustur(users.Password);
            db.SaveChanges();
            return RedirectToAction("Profile");
        }

        public ActionResult LogOut()
        {
            LoginOps.SignOut();
            return RedirectToRoute("LogIn/Admin");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}