using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using MailKit.Security;
using MailKit.Net.Smtp;

namespace Consultorio.Application.Email
{
    public class EnviarEmail : IEnviarEmail
    {
        private readonly IConfiguration _configuration; //Vai lá em appsetings e pega alguma informação que você quer.
                                                        //No caso aqui, nós queremos o SMTP
        public EnviarEmail(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<bool> Enviar(string email, string assunto, string mensagem)
        {
            try
            {
                var inicializarEmail = new MimeMessage();
                inicializarEmail.From.Add(MailboxAddress.Parse(_configuration.GetSection("SMTP:UserName").Value));
                inicializarEmail.To.Add(MailboxAddress.Parse(email));
                inicializarEmail.Subject = assunto;
                inicializarEmail.Body = new TextPart(TextFormat.Html)
                {
                    Text = mensagem
                };

                using var smtp = new SmtpClient();
                await smtp.ConnectAsync(
                    _configuration.GetSection("SMTP:Host").Value,
                    int.Parse(_configuration.GetSection("SMTP:Porta").Value),
                    SecureSocketOptions.StartTls
                );

                await smtp.AuthenticateAsync(
                    _configuration.GetSection("SMTP:UserName").Value,
                    _configuration.GetSection("SMTP:Senha").Value
                );

                await smtp.SendAsync(inicializarEmail);
                await smtp.DisconnectAsync(true);

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}
