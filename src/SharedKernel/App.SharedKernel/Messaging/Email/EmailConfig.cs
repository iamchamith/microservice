namespace App.SharedKernel.Messaging.Email
{
    public class EmailConfig
    {
        public string SendGridApiKey { get; set; }
        public string FromEmail { get; set; }
        public string FromName { get; set; }

        public EmailConfig(string apikey, string fromEmail, string fromName)
        {
            SendGridApiKey = apikey;
            FromEmail = fromEmail;
            FromName = fromName;
        }
    }
}
