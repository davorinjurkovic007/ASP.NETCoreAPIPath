namespace FreeBlling.Web
{
    public interface IEmailService
    {
        void SendMail(string to, string from, string subject, string body);
    }
}
