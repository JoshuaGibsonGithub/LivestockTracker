using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace PROG2_Livestock
{
    public class hashClass
    {
        public static string hashPassword(string password)
        {
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();

            byte[] passwordByte = Encoding.ASCII.GetBytes(password);
            byte[] encryptedByte = sha1.ComputeHash(passwordByte);

            return Convert.ToBase64String(encryptedByte);
        }
    }
}