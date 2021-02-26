using System;

namespace QuizApp.Models
{
    public class Enuqe
    {
        public static string Enuq(int ID, string Name)
        {
            var rastgele = new Random();
            var harfler = "ABCDEFGHIJKLMNOPRSTUVYZabcdefgğhijklmnoprsştuvyz123456789" + Convert.ToChar(ID) + Name;
            var uret = "";
            for (var i = 0; i < 10; i++) uret += harfler[rastgele.Next(harfler.Length)];
            return uret;
        }
    }
}