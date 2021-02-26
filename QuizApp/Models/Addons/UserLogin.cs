using System;
using System.Linq;
using System.Web;

namespace QuizApp.Models.Addons
{
    public class LoginOps
    {
        private static readonly DBContext db = new DBContext();

        public static Users GetLoginUser
        {
            get
            {
                int? ID = Convert.ToInt32(HttpContext.Current.Session["AdminLogin"]);
                if (ID == 0)
                {
                    if (!HttpContext.Current.Response.IsRequestBeingRedirected)
                        HttpContext.Current.Response.Redirect("~/LogIn/Admin", true);
                    return null;
                }

                return db.Users.Find(ID);
            }
        }

        public static void IsUserLogin()
        {
            var login = Convert.ToInt32(HttpContext.Current.Session["AdminLogin"]);
            if (login == 0)
                if (!HttpContext.Current.Response.IsRequestBeingRedirected)
                    HttpContext.Current.Response.Redirect("~/LogIn/Admin", true);
        }

        public static bool Login(string UserName, string Password)
        {
            var Passwords = MD5.MD5eDonustur(Password);
            var Exist = db.Users.FirstOrDefault(x => x.NickName == UserName && x.Password == Passwords);
            if (Exist != null && Exist.Disable == false)
            {
                HttpContext.Current.Session["AdminLogin"] = Exist.Userid;
                var log = new Logger(new StandartLog());
                log.LogEkle("Giriş Yaptı");
                return true;
            }

            return false;
        }

        public static void SignOut()
        {
            var log = new Logger(new StandartLog());
            log.LogEkle("Çıkış Yaptı");
            HttpContext.Current.Session["AdminLogin"] = 0;
            HttpContext.Current.Response.Redirect("~/LogIn/Admin", true);
        }

        public static void CreateFirstUser()
        {
            if (db.Users.Count() == 0)
            {
                var users = new Users
                {
                    Name = "Admin",
                    LastName = "",
                    NickName = "Admin",
                    Password = MD5.MD5eDonustur("admin"),
                    Disable = true
                };
                db.Users.Add(users);
                db.SaveChanges();
            }
        }

        public static bool IsExist(string NickName)
        {
            var bul = db.Users.FirstOrDefault(x => x.NickName == NickName);
            if (bul == null)
                return true;
            return false;
        }
    }
}