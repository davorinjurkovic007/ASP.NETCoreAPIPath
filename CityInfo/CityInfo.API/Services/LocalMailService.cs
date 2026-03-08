namespace CityInfo.API.Services
{
    public class LocalMailService : IMailService
    {
        private string _mailTo = string.Empty;
        private string _mailFrom = string.Empty;

        private string _zajebancija = string.Empty;

        public LocalMailService(IConfiguration configuration)
        {
            _mailTo = configuration["mailSettings:mailToAddress"]!;
            _mailFrom = configuration["mailSettings:mailFromAddress"]!;

            _zajebancija = configuration["zajebancijaSettings:zajebancijaToAddress"]!;
        }

        public void Send(string subject, string message)
        {
            // send mail - output to console window
            Console.WriteLine($"mail from {_mailFrom} to {_mailTo}, with {nameof(LocalMailService)}.");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Message: {message}");

            Console.WriteLine($"Zajebancia adresa: {_zajebancija}");
        }
    }
}
