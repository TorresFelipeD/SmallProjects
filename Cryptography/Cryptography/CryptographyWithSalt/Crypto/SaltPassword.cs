using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyWithSalt.Crypto
{
    public class SaltPassword
    {
        public string CreateSalt(int size = 20)
        {
            var rng = new RNGCryptoServiceProvider();
            var buff = new byte[size];
            rng.GetBytes(buff);
//            return Convert.ToBase64String(buff);
            string salt = Convert.ToBase64String(buff);

            byte[] bytes = Encoding.UTF8.GetBytes(salt);
            SHA256Managed sHA256ManagedString = new SHA256Managed();
            byte[] hash = sHA256ManagedString.ComputeHash(bytes);
            return ByteArraytoHexString(hash);
        }

        public string GenerateSHA256Hash(string input, string salt)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input + salt);
            SHA256Managed sHA256ManagedString = new SHA256Managed();
            byte[] hash = sHA256ManagedString.ComputeHash(bytes);
            return ByteArraytoHexString(hash);
        }

        private string ByteArraytoHexString(byte[] hash)
        {
            StringBuilder hex = new StringBuilder(hash.Length * 2);
            foreach (byte item in hash)
            {
                hex.AppendFormat("{0:x2}", item);
            }
            return hex.ToString();
        }
    }
}
