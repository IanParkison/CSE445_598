using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace EncryptionService
{
    public class EncryptionOperation
    {
        private string stringKey = "-KaPdSgVkXp2s5v8y/B?E(H+MbQeThWm";
        private string stringIV = "fTjWnZr4u7x!A%D*";
        private byte[] key;
        private byte[] iv;
        private const int size = 256;
        RijndaelManaged rijndael = new RijndaelManaged();

        public string encrypt(string clearText)
        {
            //put keys in byte arrays
            key = Encoding.Default.GetBytes(stringKey);
            iv = Encoding.Default.GetBytes(stringIV);

            byte[] bytes;

            ICryptoTransform encryptor = rijndael.CreateEncryptor(key, iv);
            //do encryption
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(clearText);
                    }
                    bytes = msEncrypt.ToArray();
                }
            }
            return Convert.ToBase64String(bytes);
        }

        public string decrypt(string cipherText)
        {
            //put keys in byte arrays
            key = Encoding.Default.GetBytes(stringKey);
            iv = Encoding.Default.GetBytes(stringIV);
            //byte[] cipherBytes = Encoding.Default.GetBytes(cipherText);
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            //do dycryption
            ICryptoTransform decryptor = rijndael.CreateDecryptor(key, iv);
            using (MemoryStream msDecrypt = new MemoryStream(cipherBytes))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }
    }
}