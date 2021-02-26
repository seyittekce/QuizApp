using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuizApp.Models
{
    public class Students
    {
        public enum LoginType
        {
            Normal,
            Facebook,
            Google
        }

        [Key] public int StudentID { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Ad")]
        public string FirsName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Soyad")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Şifre")]
        public string Password { get; set; }

        [DataType(DataType.EmailAddress)]
        [DisplayName("E-mail Adresi")]
        public string Mail { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Telefon Numarası")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Oluşturulduğu Tarih")]
        public DateTime CratedDate { get; set; }

        public bool Verified { get; set; }
        public LoginType? Type { get; set; }
        public string Uniqe => Enuqe.Enuq(StudentID, LastName);
    }
}