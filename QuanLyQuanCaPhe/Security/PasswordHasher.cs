using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCaPhe.Security
{
    class PasswordHasher
    {
        public static string Md5(string s)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(s);
                byte[] hash = md5.ComputeHash(bytes);

                StringBuilder result = new StringBuilder();
                foreach (byte b in hash)
                {
                    result.Append(b.ToString("x2")); // Tương đương với Integer.toHexString + 0 padding
                }

                return result.ToString();
            }
        }
    }
}
