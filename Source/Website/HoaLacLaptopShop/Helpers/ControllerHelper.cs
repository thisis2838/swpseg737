using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NuGet.Packaging;
using System.Security.Cryptography;
using System.Text;

namespace HoaLacLaptopShop.Helpers
{
    public static class ControllerHelper
    {
        public static void AddError(this Controller controller, params string[] error)
        {
            var errors = controller.TempData["Error"] as ICollection<string> ?? new List<string>();
            errors.AddRange(error);
            controller.TempData["Error"] = errors;
        }
        public static void AddWarning(this Controller controller, params string[] warning)
        {
            var warnings = controller.TempData["Warning"] as ICollection<string> ?? new List<string>();
            warnings.AddRange(warning);
            controller.TempData["Warning"] = warnings;
        }
        public static void AddMessage(this Controller controller, params string[] message)
        {
            var messages = controller.TempData["Message"] as ICollection<string> ?? new List<string>();
            messages.AddRange(message);
            controller.TempData["Message"] = messages;
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
