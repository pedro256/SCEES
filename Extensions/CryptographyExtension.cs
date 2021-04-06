using System.Security.Cryptography;
using System.Text;

namespace SCEES.Extensions
{
    public static class CryptographyExtension
    {
        public static string GerarHashMd5(string input)
        {
            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
        public static bool compararSenha(string passwordInfor,string passwordCorret){
            return GerarHashMd5(passwordInfor)==passwordCorret;
        }
    }

}