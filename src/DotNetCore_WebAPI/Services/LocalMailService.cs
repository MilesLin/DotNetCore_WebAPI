using DotNetCore_WebAPI.Models;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace DotNetCore_WebAPI.Services
{
    public class LocalMailService : IMailService
    {
        private IOptions<MailSettings> _options;

        public LocalMailService(IOptions<MailSettings> options)
        {
            _options = options;
        }

        public void Send(string subject, string message)
        {
            // send mail - output to debug window
            Debug.WriteLine($"Mail from {_options.Value.MailFromAddress} to {_options.Value.MailToAddress}, with LocalMailService.");
            Debug.WriteLine($"Subject: {subject}");
            Debug.WriteLine($"Message: {message}");
        }
    }
}