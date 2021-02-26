using System.Linq;
using System.Net;
using System.Web.Mvc;
using QuizApp.Models;

namespace QuizApp.Controllers
{
    public class LogController : Controller
    {
        private readonly DBContext dB = new DBContext();

        // GET: Log
        public ActionResult Logs()
        {
            return View(dB.Log.ToList());
        }

        public ActionResult Details(int id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var log = dB.Log.Find(id);
            if (log == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            return View(log);
        }
    }
}