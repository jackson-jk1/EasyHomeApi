using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helpers
{
    public abstract class EncryptHelper
    {
        private static readonly string key = Environment.GetEnvironmentVariable("Key");
        public static string Encrypt(string password)
        {
            byte[] iv = new byte[16];
            byte[] array;
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using (MemoryStream ms = new MemoryStream())
                {

                    using (CryptoStream cryptoSteam = new CryptoStream((Stream)ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter writer = new StreamWriter((Stream)cryptoSteam))
                        {
                            writer.Write(password);
                        }
                        array = ms.ToArray();

                    }
                }
            }
            return Convert.ToBase64String(array);
        }


        public static string Decrypt(string password)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(password);
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                using (MemoryStream ms = new MemoryStream(buffer))
                {

                    using (CryptoStream cryptoSteam = new CryptoStream((Stream)ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader((Stream)cryptoSteam))
                        {
                            return reader.ReadToEnd();
                        }
                     
                    }
                }
            }
        }
    }
}

