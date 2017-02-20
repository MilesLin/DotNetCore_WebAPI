using DotNetCore_WebAPI.Models;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace DotNetCore_WebAPI.Services
{
    public class CloudMailService : IMailService
    {
        private IOptions<MailSettings> _options;

        public CloudMailService(IOptions<MailSettings> options)
        {
            _options = options;
        }

        public void Send(string subject, string message)
        {
            // send mail - output to debug window
            Debug.WriteLine($"Mail from {_options.Value.MailFromAddress} to {_options.Value.MailToAddress}, with CloudMailService.");
            Debug.WriteLine($"Subject: {subject}");
            Debug.WriteLine($"Message: {message}");
        }
    }
}