using System;
using System.Linq;

namespace QuizApp.Models.Addons
{
    public interface ILogger
    {
        void Logger(string Action);
    }

    public class Logger
    {
        public ILogger _logger;

        public Logger(ILogger log)
        {
            _logger = log;
        }

        public void LogEkle(string Action)
        {
            _logger.Logger(Action);
        }
    }

    public class StandartLog : ILogger
    {
        private readonly DBContext db = new DBContext();

        public StandartLog()
        {
            var LogCount = db.Log.Count();
            if (LogCount >= 1000) db.Database.ExecuteSqlCommand("TRUNCATE TABLE [Log]");
        }

        public void Logger(string Action)
        {
            var log = new Log
            {
                Action = Action,
                Date = DateTime.Now,
                Type = Log.LogType.Standart
            };
            db.Log.Add(log);
            db.SaveChanges();
        }
    }

    public class ErrorLogger : ILogger
    {
        private readonly DBContext db = new DBContext();

        public ErrorLogger()
        {
            var LogCount = db.Log.Count();
            if (LogCount >= 1000) db.Database.ExecuteSqlCommand("TRUNCATE TABLE [Log]");
        }

        public void Logger(string Action)
        {
            var log = new Log
            {
                Action = Action,
                Date = DateTime.Now,
                Type = Log.LogType.Error
            };
            db.Log.Add(log);
            db.SaveChanges();
        }
    }
}