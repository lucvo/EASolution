/*
 * Name:
 * Author: Gautam G Gosavi
 * Purpose:For password encryption and deletion using the secret key, did search in forums on internet
 * Date: 2009/6/1
 * 
 * Modification history
 * Sr No.   Date         ModifiedBy           Desc
 * 
 * */
namespace EASolution.Infrastructure.Security
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// The crypto engine.
    /// </summary>
    public class CryptoEngine
    {
        /// <summary>
        /// The security key.
        /// </summary>
        private const string SecurityKey = "a$ak9#a)!@";

        /// <summary>
        /// Encrypt a string using dual encryption method. Return a encrypted cipher Text
        /// </summary>
        /// <param name="toEncrypt">string to be encrypted</param>
        /// <param name="useHashing">use hashing? send to for extra security</param>
        /// <returns>Return a encrypted cipher Text</returns>
        public static string Encrypt(string toEncrypt, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);


            string key = SecurityKey;

            if (useHashing)
            {
                //if defined use hashcode of the key.
                var hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            var tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            var transform = tdes.CreateEncryptor();
            byte[] resultArray = transform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        /// <summary>
        /// DeCrypt a string using dual encryption method. Return a decrypted clear string
        /// </summary>
        /// <param name="cipherString">encrypt string</param>
        /// <param name="useHashing">Did you use hashing to encrypt this data? pass true is yes</param>
        /// <returns>decrypt string result</returns>
        public static string Decrypt(string cipherString, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(cipherString);


            string key = SecurityKey;

            if (useHashing)
            {
                var hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            var tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            tdes.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
    }
}
