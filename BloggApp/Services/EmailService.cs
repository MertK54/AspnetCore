using System.Net;
using System.Net.Mail;

public class EmailService
{
    public void SendVerificationCode(string email, string verificationCode)
    {
        var fromAddress = new MailAddress("kezermert@gmail.com", "Mert KEZER");
        var toAddress = new MailAddress(email);
        const string fromPassword = "urex hooo xbar isqp";
        const string subject = "Verification Code";
        string body = $"Your verification code is: {verificationCode}";

        var smtp = new SmtpClient
        {
            Host = "smtp.gmail.com",
            Port = 587,
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
        };
        
        using (var message = new MailMessage(fromAddress, toAddress)
        {
            Subject = subject,
            Body = body
        })
        {
            smtp.Send(message);
        }
    }

    public string GenerateVerificationCode()
    {
        Random random = new Random();
        return random.Next(100000, 999999).ToString();
    }
}
