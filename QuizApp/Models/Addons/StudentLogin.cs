using System;
using System.Linq;
using System.Web;

namespace QuizApp.Models.Addons
{
    public class StudentLogin
    {
        private static readonly DBContext db = new DBContext();

        public static Students GetLoginStudent
        {
            get
            {
                var ID = Convert.ToInt32(HttpContext.Current.Session["StudentLogin"]);
                if (ID == 0)
                {
                    if (!HttpContext.Current.Response.IsRequestBeingRedirected)
                        HttpContext.Current.Response.Redirect("~/LogIn/Students", true);
                    return null;
                }

                return db.Students.Find(ID);
            }
        }

        public static bool StudentsLogin(string Name, string password)
        {
            var sifreli = MD5.MD5eDonustur(password);
            var GetUser = db.Students.FirstOrDefault(x => x.Mail == Name && x.Password == sifreli);
            if (GetUser == null)
            {
                return false;
            }

            HttpContext.Current.Session["StudentLogin"] = GetUser.StudentID;
            return true;
        }

        public static bool IsExist(string Name)
        {
            var GetUser = db.Students.FirstOrDefault(x => x.Mail == Name);
            if (GetUser == null)
                return true;
            return false;
        }

        public static void UserSignOut()
        {
            HttpContext.Current.Session["StudentLogin"] = 0;
            HttpContext.Current.Response.Redirect("~/LogIn/Student", true);
            var log = new Logger(new StandartLog());
            log.LogEkle("Öğrenci Çıkış Yaptı");
        }

        public static void IsStudentLogin()
        {
            var login = Convert.ToInt32(HttpContext.Current.Session["StudentLogin"]);
            if (login == 0) HttpContext.Current.Response.Redirect("~/LogIn/Student", true);
        }
    }
}