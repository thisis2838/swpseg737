using System.Net.Mail;
using System.Net;

namespace HoaLacLaptopShop.Services
{
    public interface IEmailSenderService
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
    public class EmailSenderService : IEmailSenderService
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var mail = "hoalaclaptopshop@gmail.com";
            var pw = "chjnurjjktnqpnyh";

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(mail, pw),
            };
            return client.SendMailAsync(new MailMessage
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
