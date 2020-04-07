using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ECMS
{
    public class Decrypt
    {
        private string hash = "P!@sH05";
        public string DecryptCode { set { hash = value; } }
        private string Decrypt_String(string Text)
        {
            try
            {
                byte[] data = Convert.FromBase64String(Text);
                using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                {
                    byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                    using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                    {
                        ICryptoTransform transfrom = tripDes.CreateDecryptor();
                        byte[] results = transfrom.TransformFinalBlock(data, 0, data.Length);
                        return UTF8Encoding.UTF8.GetString(results);
                    }
                }
            }
            catch (Exception)
            {
                return "error";
            }
        }
        public string GetDecryptHashCode(string Text)
        {
            return Decrypt_String(Text);
        }
        public void Decrypt_Code_Changer(string Decrypt_Code_Fram)//Change any code to fram
        {
            hash = Decrypt_Code_Fram;
        }
    }
}
