using System.Data.Entity;

namespace QuizApp.Models
{
    public class DBContext : DbContext
    {
        public DBContext() : base("QUESTIONAPP-25897")
        {
        }

        public DbSet<Class> Class { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Questions> Question { get; set; }
        public DbSet<Library> QuizLibrary { get; set; }
        public DbSet<Users> Users { get; set; }

        public DbSet<Log> Log { get; set; }

        //public DbSet<Settings> Settings { get; set; }
        public DbSet<Answers> Answers { get; set; }
        public DbSet<VideoAndArticle> VideosAndArticles { get; set; }
    }
}