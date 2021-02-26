using System;

namespace QuizApp.Models
{
    public class Log
    {
        public enum LogType
        {
            Standart,
            Error
        }

        public int ID { get; set; }
        public string Action { get; set; }
        public DateTime Date { get; set; }
        public LogType? Type { get; set; }
    }
}