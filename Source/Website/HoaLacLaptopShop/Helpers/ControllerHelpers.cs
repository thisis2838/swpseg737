using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Cryptography;
using System.Text;

namespace HoaLacLaptopShop.Helpers
{
    public static class ControllerHelpers
    {
        public static void SetError(this Controller controller, string error)
        {
            controller.TempData["Error"] = error;
        }

        public static void SetMessage(this Controller controller, string message)
        {
            controller.TempData["Message"] = message;
        }
        public static string ToMd5Hash(string password)
        {
            using (var md5 = MD5.Create())
            {
                byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sb.Append(data[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}
