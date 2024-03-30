using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Consultorio.Web.Helper
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(string toEmail, string subject, string message);
    }

    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> SendEmailAsync(string toEmail, string subject, string message)
        {
            try
            {
                var smtpSettings = _configuration.GetSection("SmtpSettings");

                using (var client = new SmtpClient())
                {
                    client.Host = smtpSettings["Server"];
                    client.Port = int.Parse(smtpSettings["Port"]);
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(smtpSettings["Username"], smtpSettings["Password"]);
                    client.EnableSsl = true;

                    using (var emailMessage = new MailMessage())
                    {
                        emailMessage.To.Add(new MailAddress(toEmail));
                        emailMessage.Subject = subject;
                        emailMessage.Body = message;
                        emailMessage.From = new MailAddress(smtpSettings["Username"]);

                        await client.SendMailAsync(emailMessage);
                    }
                }
                return true;
            }
            catch 
            { 
                return false;
            }
                
        }
    }
}
