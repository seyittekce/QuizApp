using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuizApp.Models
{
    public class Users
    {
        [Key] public int Userid { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Ad")]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Soyad")]
        public string LastName { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Kullanıcı Adı")]
        public string NickName { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Şifre")]
        public string Password { get; set; }

        [DataType(DataType.EmailAddress)]
        [DisplayName("E-mail Adresi")]
        public string Email { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Etkisiz")]
        public bool Disable { get; set; }

        [DataType(DataType.PhoneNumber)]
        [DisplayName("Telefon Numarası")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName("Oluşturulduğu Tarih")]
        public DateTime CratedDate { get; set; }

        public bool First { get; set; }
        public string Uniqe => Enuqe.Enuq(Userid, Name);
    }
}