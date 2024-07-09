using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NuGet.Packaging;
using System.Security.Cryptography;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HoaLacLaptopShop.Helpers
{
    public enum NotificationType
    {
        Message,
        Warning,
        Error
    }

    public static class ControllerHelper
    {
        public static void AddNotifications(this ITempDataDictionary temp, NotificationType type, params string[] newNotifs)
        {
            var notifs = temp[type.ToString()] as ICollection<string> ?? new List<string>();
            notifs.AddRange(newNotifs);
            temp[type.ToString()] = notifs;
        }
        public static void AddError(this Controller controller, params string[] errors)
        {
            controller.TempData.AddNotifications(NotificationType.Error, errors);
        }
        public static void AddWarning(this Controller controller, params string[] warnings)
        {
            controller.TempData.AddNotifications(NotificationType.Warning, warnings);
        }
        public static void AddMessage(this Controller controller, params string[] messages)
        {
            controller.TempData.AddNotifications(NotificationType.Message, messages);
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
