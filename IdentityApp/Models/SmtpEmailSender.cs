using System.Net;
using System.Net.Mail;
using IdentityApp.Models;

public class SmtpEmailSender : IEMailSender
{
    private readonly string _host;
    private readonly int _port;
    private readonly bool _enableSSL;
    private readonly string _username;
    private readonly string _password;

    public SmtpEmailSender(string host, int port, bool enableSSL, string username, string password)
    {
        _host = host;
        _port = port;
        _enableSSL = enableSSL;
        _username = username;
        _password = password;
    }

    public Task SendEmailAsync(string email, string subject, string message)
    {
        var client = new SmtpClient(_host, _port)
        {
            Credentials = new NetworkCredential(_username, _password), // Eğer API anahtarı kullanıyorsanız burada username yerine API anahtarını kullanın.
            EnableSsl = _enableSSL
        };

        return client.SendMailAsync(new MailMessage(_username, email, subject, message));
    }
}