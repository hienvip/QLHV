using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class Encryption
    {
        public static string Encrypt(string _input)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                string hash = GetMd5Hash(md5Hash, _input);
                return hash;
            }
        }


        public static string MyEncrypt(string _input)
        {
            //abc -> 48,49,50 :48+0+(49%2);49+1+(50%2)...
            char[] char_input = _input.ToCharArray();
            var input_withIndex = char_input.Select((val, ind) => new { val, ind }).ToArray();
            var char_input_encrypted = input_withIndex.Select(c => c.val + c.ind + (input_withIndex.Length > c.ind + 1 ? input_withIndex[c.ind + 1].val % 2 : 0)).Select(c => (char)c).ToArray();
            string resval = new string(char_input_encrypted);
            return resval;

        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}
