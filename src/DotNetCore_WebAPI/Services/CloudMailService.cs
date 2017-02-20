using System.Diagnostics;

namespace DotNetCore_WebAPI.Services
{
    public class CloudMailService : IMailService
    {
        private string _mailTo = "mailSettings:mailToAddress";
        private string _mailFrom = "mailSettings:mailFromAddress";

        public void Send(string subject, string message)
        {
            // send mail - output to debug window
            Debug.WriteLine($"Mail from {_mailFrom} to {_mailTo}, with CloudMailService.");
            Debug.WriteLine($"Subject: {subject}");
            Debug.WriteLine($"Message: {message}");
        }
    }
}