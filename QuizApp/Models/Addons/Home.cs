using System.Collections.Generic;
using System.Linq;

namespace QuizApp.Models.Addons
{
    public class HomeInfo
    {
        private readonly DBContext db = new DBContext();

        public List<Students> GetNonRegisteredUser()
        {
            return db.Students.Where(x => x.Verified == false).ToList();
        }
    }
}