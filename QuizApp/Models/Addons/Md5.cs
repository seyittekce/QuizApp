using System;
using System.Security.Cryptography;
using System.Text;

namespace QuizApp.Models.Addons
{
    public class MD5
    {
        public static string MD5eDonustur(string metin)
        {
            var pwd = new MD5CryptoServiceProvider();
            return Sifrele(metin, pwd);
        }

        private static string Sifrele(string metin, HashAlgorithm alg)
        {
            var byteDegeri = Encoding.UTF8.GetBytes(metin);
            var sifreliByte = alg.ComputeHash(byteDegeri);
            return Convert.ToBase64String(sifreliByte);
        }
    }
}