using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuizApp.Models
{
    public class VideoAndArticle
    {
        public enum Types
        {
            Video,
            Article
        }

        [Key] public int ID { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Başlık")]
        public string Baslik { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Makale")]
        public string Yazilar { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName("Oluşturulan Zaman")]
        public DateTime CratedDate { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Yazar")]
        public string Yazar { get; set; }

        [DisplayName("Video Linki (Sadece Youtube)")]
        public string Link { get; set; }

        public Types? Type { get; set; }
    }
}