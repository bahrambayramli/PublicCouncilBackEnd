using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Security.Cryptography;
using System.Text;


namespace PublicCouncilBackEnd
{
    public class Crypto
    {

        //MD5----------------
        public static string MD5crypt(string Text)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(Text));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
                sBuilder.Append(data[i].ToString("x2"));
            return sBuilder.ToString();
        }


        private static bool verifyMd5Hash(string input, string hash)
        {
            string hashOfInput = MD5crypt(input);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            if (0 == comparer.Compare(hashOfInput, hash)) return true;
            else return false;
        }

        //SHA1----------------
        public static string SHA1(string Text)
        {

            SHA1 sha1 = new System.Security.Cryptography.SHA1Managed();
            byte[] sha1Bytes = System.Text.Encoding.Default.GetBytes(Text);
            byte[] cryString = sha1.ComputeHash(sha1Bytes);
            string sha1Str = string.Empty;
            for (int i = 0; i < cryString.Length; i++)
            {
                sha1Str += cryString[i].ToString("X");
            }
            return sha1Str;
        }


        //SHA256----------------
        public static string SHA256(string Text)
        {


            SHA256 sha256 = new System.Security.Cryptography.SHA256Managed();
            byte[] sha256Bytes = System.Text.Encoding.Default.GetBytes(Text);
            byte[] cryString = sha256.ComputeHash(sha256Bytes);
            string sha256Str = string.Empty;
            for (int i = 0; i < cryString.Length; i++)
            {
                sha256Str += cryString[i].ToString("X");
            }
            return sha256Str;
        }


        //SHA384----------------
        public static string SHA384(string Text)
        {


            SHA384 sha384 = new System.Security.Cryptography.SHA384Managed();
            byte[] sha384Bytes = System.Text.Encoding.Default.GetBytes(Text);
            byte[] cryString = sha384.ComputeHash(sha384Bytes);
            string sha384Str = string.Empty;
            for (int i = 0; i < cryString.Length; i++)
            {
                sha384Str += cryString[i].ToString("X");
            }
            return sha384Str;
        }



        //SHA512----------------
        public static string SHA512(string Text)
        {  
            SHA512 sha512 = new System.Security.Cryptography.SHA512Managed();
            byte[] sha512Bytes = System.Text.Encoding.Default.GetBytes(Text);
            byte[] cryString = sha512.ComputeHash(sha512Bytes);
            string sha512Str = string.Empty;
            for (int i = 0; i < cryString.Length; i++)
            {
                sha512Str += cryString[i].ToString("X");
            }
            return sha512Str;
        }


    }
}