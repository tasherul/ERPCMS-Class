using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ECMS
{
    public class Encrypt
    {
        private string hash = "P!@sH05";
        public string EncryptCode { set { hash = value; } }
        private string Encrypt_String(string Text)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(Text);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transfrom = tripDes.CreateEncryptor();
                    byte[] results = transfrom.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(results, 0, results.Length);
                }
            }
        }
        public string HashCode(string Text)
        {
            return Encrypt_String(Text);
        }
        public void Encrypt_Code_Changer(string Encrypt_Code_Fram)
        {
            hash = Encrypt_Code_Fram;
        }
    }
}
