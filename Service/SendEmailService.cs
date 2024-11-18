using IALClient.config;
using IALClient.Service.CustomException;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace IALClient.Service;

public class SendEmailService(IOptions<GmailSettings> gmailSettings)
{

    
    public void SendEmail(string subject, string body, string to)
    {

        var gmailSettingsValue = gmailSettings.Value;


        try
        {

            var fromEmail = gmailSettingsValue.Username!;
            var password = gmailSettingsValue.Password!;

            var message = new MailMessage
            {
                From = new MailAddress(fromEmail!),
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            };

            message.To.Add(to);


            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = gmailSettingsValue.Port,
                Credentials = new NetworkCredential(fromEmail, password),
                EnableSsl = true
            };

            smtpClient.Send(message);

        }
        catch (Exception e)
        {
            throw new SendEmailException("Erro ao enviar e-mail: " + e);
        }


    }

}
