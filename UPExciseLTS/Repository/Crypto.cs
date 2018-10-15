using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace UPExciseLTS.Repository
{
    public class Crypto
    {

        private string secKey = "RNf0UGY2017SpkD2co";
        public string Encrypt(string StrEncode)
        {

            string encodedString = null;

            encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(StrEncode)));

            return (encodedString);

        }
        public string Decrypt(string StrDecode)
        {

            string decodedString = null;

            decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(StrDecode));

            return decodedString;

        }
        private byte[] key = { };
        private byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xab, 0xcd, 0xef };
        public string   sEncryptionKey = "UP#@!786";


        //public string EncryptQueryString(string strQueryString)
        //{
        //    EncryptDecryptQueryString objEDQueryString = new EncryptDecryptQueryString();
        //    return objEDQueryString.Encrypt(strQueryString, "r0b1nr0y");
        //}
        //private string DecryptQueryString(string strQueryString)
        //{
        //    EncryptDecryptQueryString objEDQueryString = new EncryptDecryptQueryString();
        //    return objEDQueryString.Decrypt(strQueryString, "r0b1nr0y");
        //}
        public string DecryptUnicode(string stringToDecrypt)
        {
            byte[] inputByteArray = new byte[stringToDecrypt.Length + 1];
            try
            {
                key = System.Text.Encoding.UTF8.GetBytes(sEncryptionKey);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(stringToDecrypt);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                System.Text.Encoding encoding = System.Text.Encoding.UTF8;
                return encoding.GetString(ms.ToArray());
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string EncryptUnicode(string stringToEncrypt)
        {
            try
            {
                key = System.Text.Encoding.UTF8.GetBytes(sEncryptionKey);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}