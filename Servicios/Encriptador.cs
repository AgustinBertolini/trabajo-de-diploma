using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Servicios
{
    public static class Encriptador
    {
        public static string CreateHash(string value)
        {
                var md5 = new MD5CryptoServiceProvider();
                var md5data = md5.ComputeHash(Encoding.ASCII.GetBytes(value));
                return (new ASCIIEncoding()).GetString(md5data);
        }
    }
}
