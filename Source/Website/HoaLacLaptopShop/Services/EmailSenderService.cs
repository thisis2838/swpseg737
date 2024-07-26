using System.Net.Mail;
using System.Net;
using System.Diagnostics;

namespace HoaLacLaptopShop.Services
{
    public interface IEmailSenderService
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
    public class EmailSenderService : IEmailSenderService
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
                var mail = "hoalaclaptopshop@gmail.com";
                var pw = "zceq sxho puti qsyb";

                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(mail, pw),
                };
                await client.SendMailAsync(new MailMessage
                (
                    from: mail,
                    to: email,
                    subject,
                    message
                )
                {
                    IsBodyHtml = true
                });
           
        }
    }
}
