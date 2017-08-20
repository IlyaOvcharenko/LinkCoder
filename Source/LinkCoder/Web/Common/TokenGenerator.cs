using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Web.Common
{
    public class TokenGenerator
    {
        private const string _alg = "lXbLrthcOj";

        public static string GenerateToken(string username)
        {
            string hash = username;
            string hashLeft = "";
            string hashRight = "";
            using (HMAC hmac = new HMACSHA256(Encoding.UTF8.GetBytes(_alg))) 
            {
                hmac.ComputeHash(Encoding.UTF8.GetBytes(hash));
                hashLeft = Convert.ToBase64String(hmac.Hash);
                hashRight = string.Join(":", new string[] {username});
            }
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Join(":", hashLeft, hashRight)));
        }


        public static bool IsTokenValid(string token)
        {
            var userName = GetUserNameFromToken(token);
            string computedToken = GenerateToken(userName);
            return string.Equals(token, computedToken);
        }

        public static string GetUserNameFromToken(string token)
        {
            string key = Encoding.UTF8.GetString(Convert.FromBase64String(token));

            string[] parts = key.Split(new char[] {':'});

            return parts.Length > 1 ? parts[1] : string.Empty;
        }
    }
}