using Google.Apis.Util.Store;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace Consultorio.Application.Email
{


    public class SeedEmail : ISeedEmail
    {
        private readonly IConfiguration _configuration;

        public SeedEmail(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> Seed(string email, string subject, string mensage)
        {
            try
            {
                string applicationName = "Gerenciador Gmail";
                string[] scopes = { GmailService.Scope.GmailSend };

                UserCredential credential;
                using (var stream = new FileStream("credentialEmail.json", FileMode.Open, FileAccess.Read))
                {
                    string credPath = "tokenEmail.json";
                    credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                            GoogleClientSecrets.FromStream(stream).Secrets,
                            scopes,
                            "user",
                            CancellationToken.None,
                            new FileDataStore(credPath, true)
                    );
                }

                // Create Gmail API service
                var service = new GmailService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = applicationName
                });

                // Create a new message
                var gmailMessage = new Message
                {
                    Raw = Base64UrlEncode(CreateMessage(email, subject, mensage))
                };

                // Send the email
                var result = await service.Users.Messages.Send(gmailMessage, "me").ExecuteAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private string CreateMessage(string email, string assunto, string mensagem)
        {
            var msg = new StringBuilder();
            msg.AppendLine("From: Consultório Médico <abimaelnagato@gmail.com>");
            msg.AppendLine("To: Teste <" + email + ">");
            msg.AppendLine("Subject: " + Encoding.UTF8.GetBytes(assunto));
            msg.AppendLine("Content-Type: text/html; charset=utf-8");
            msg.AppendLine();
            msg.AppendLine(mensagem);

            return msg.ToString();
        }

        private static string Base64UrlEncode(string input)
        {
            var inputBytes = Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(inputBytes)
                .Replace('+', '-')
                .Replace('/', '_')
                .Replace("=", "");
        }

    }
}


