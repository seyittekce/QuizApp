using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuizApp.Models
{
    public class Library
    {
        [Key] public int LibraryID { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Kütüphane Adı")]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Sorular")]
        public string Questions { get; set; }

        public virtual Questions Quiz { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName("Oluşturulma Tarihi")]
        public DateTime CratedDate { get; set; }

        public string[] Question { get; set; }

        [DisplayName("Yorum")] public string Comment { get; set; }

        public string Uniqe => Enuqe.Enuq(LibraryID, Name);
    }
}