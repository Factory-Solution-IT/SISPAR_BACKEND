using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Common.Helpers
{
    public static class StringHelper
    {
        public static string Encrypt(this string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return "";

            texto += "|cf27eb87-1204-407e-b76c-7a865832f85B";
            var md5 = System.Security.Cryptography.MD5.Create();
            var data = md5.ComputeHash(Encoding.GetEncoding(0).GetBytes(texto));
            var sbString = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
                sbString.Append(data[i].ToString("x2"));
            return sbString.ToString();
        }
    }
}
