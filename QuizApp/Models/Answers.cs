using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuizApp.Models
{
    public class Answers
    {
        public enum Status
        {
            DevamEdiyor,
            Girdi,
            Girmedi
        }
        [Key] public int AnswerID { get; set; }

        [DisplayName("Öğrenci Numarası")] public int StudentID { get; set; }

        public virtual Students Students { get; set; }
        public int QuestionID { get; set; }
        public virtual Questions Questions { get; set; }
        public int LibraryID { get; set; }
        public virtual Library Library { get; set; }
        public int ClassID { get; set; }
        public virtual Class Class { get; set; }
        public string Answer { get; set; }
        public bool Pass { get; set; }
        public string Uniqe => Enuqe.Enuq(AnswerID, Answer);
        public int TotalPoint { get; set; }
        public Status Statuss { get; set; }
        public DateTime CratedDate { get; set; }
    }
}