namespace VRSite.Api.Common.Configurations.Models
{
    public class MailSettings
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
    }
}