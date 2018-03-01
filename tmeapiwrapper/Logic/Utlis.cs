using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace tmeapiwrapper.Logic
{
    public static class Utlis
    {
        public static string CreateToken(string message, string secret)
        {
       
            var encoding = new ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(secret);
            byte[] messageBytes = encoding.GetBytes(message);
            
            using (var hmacsha1 = new  HMACSHA1(keyByte))
            {
                byte[] hashmessage = hmacsha1.ComputeHash(messageBytes);
                return Convert.ToBase64String(hashmessage);
            }
        }

        public static string UrlEncode(string value)
        {
            return WebUtility.UrlEncode(value);
        }

        public static string UrlDecode(string value)
        {
            return WebUtility.UrlDecode(value);
        }
    }
}
