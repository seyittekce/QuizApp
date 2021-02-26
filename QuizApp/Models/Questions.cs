using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuizApp.Models
{
    public class Questions
    {
        public enum QuestionsTypes
        {
            Multiple,
            Truefalse,
            Shrots,
            File,
            Paragraph
        }

        [Key] public int QuestionID { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Soru")]
        public string Question { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Cevap")]
        public string Answers { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Açıklama")]
        public string Explanation { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Soru Tipi")]
        public QuestionsTypes Type { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Oluşturulma Tarihi")]
        public DateTime CratedDate { get; set; }

        public string True_Answers { get; set; }
        public string Uniqe => Enuqe.Enuq(QuestionID, Question);
    }
}