using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ADO.Services.Security
{
    internal class SCR
    {
        private static SCR instance;

        public static SCR Instance
        {
            get { if (Equals(instance, null)) instance = new SCR(); return instance; }
            private set { instance = value; }
        }

        private SCR() { }

        public string Encode(string str)
        {
            string hasPass = "DYU_%1%3%1%4";
            byte[] data = UTF8Encoding.UTF8.GetBytes(str);

            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hasPass));

                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    hasPass = Convert.ToBase64String(results, 0, results.Length);
                }
            }
            return hasPass;
        }
        public string Decryption(string str)
        {
            string hash = "admin";
            byte[] data = Convert.FromBase64String(str);

            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));

                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    str = UTF8Encoding.UTF8.GetString(results);
                }
            }
            return str;
        }
    }
}
