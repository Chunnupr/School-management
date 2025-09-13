using SchoolManagementSystem.Core.Interfaces;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SchoolManagementSystem.Core.Services
{
    public class EncryptionService : IEncryptionService
    {
        // IMPORTANT: In a real application, the key and IV should be managed securely
        // and not hardcoded.
        private readonly byte[] _key = Encoding.UTF8.GetBytes("a1b2c3d4e5f6g7h8a1b2c3d4e5f6g7h8");
        private readonly byte[] _iv = Encoding.UTF8.GetBytes("h8g7f6e5d4c3b2a1");

        public string Encrypt(string plainText)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = _key;
                aes.IV = _iv;
                var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    using (var sw = new StreamWriter(cs))
                    {
                        sw.Write(plainText);
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        public string Decrypt(string cipherText)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = _key;
                aes.IV = _iv;
                var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (var ms = new MemoryStream(Convert.FromBase64String(cipherText)))
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                using (var sr = new StreamReader(cs))
                {
                    return sr.ReadToEnd();
                }
            }
        }
    }
}
