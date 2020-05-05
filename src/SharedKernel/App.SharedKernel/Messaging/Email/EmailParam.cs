using App.SharedKernel.Exception;
using App.SharedKernel.Extension;
using SendGrid.Helpers.Mail;
using System.Collections.Generic;
using System.Linq;

namespace App.SharedKernel.Messaging.Email
{
    public class EmailParam
    {
        public List<EmailAddress> SendTo { get; private set; } = new List<EmailAddress>();
        public string Subject { get; private set; }
        public string Body { get; private set; }
        public string Regards { get; private set; } = "Team Amazon.com";

        public EmailParam(string subject, string regards = "Team Amazon.com")
        {
            if (string.IsNullOrEmpty(subject))
                throw new MessageException("Email message must have subject.".MakeThisRedable());
            Subject = subject.Trim();
            Regards = regards.Trim();
        }
        public EmailParam SetBody(string body)
        {
            if (string.IsNullOrEmpty(body))
                throw new MessageException("Email message content cannot be null or empty".MakeThisRedable());
            Body = EmailTemplate.GenarateBody(SendTo.Count.Is(1) ? SendTo.First().Name : "There", body, Regards);
            return this;
        }
        public EmailParam SetBody(params string[] list)
        {
            if (list.IsNull())
                throw new MessageException("Email message content cannot be null or empty".MakeThisRedable());
            var body = string.Join(' ', list).Trim();
            if (string.IsNullOrEmpty(body))
                throw new MessageException("Email message content cannot be null or empty".MakeThisRedable());
            Body = EmailTemplate.GenarateBody(SendTo.Count.Is(1) ? SendTo.First().Name : "There", body, Regards);
            return this;
        }
        public EmailParam AddSendTo(string email, string name = "There")
        {
            if (!email.IsValidEmail())
                return this;
            email = email.TrimAndToLower();
            if (SendTo.IsNull())
                SendTo = new List<EmailAddress>();

            if (SendTo.Any(p => p.Email.Equals(email, System.StringComparison.InvariantCultureIgnoreCase)))
                return this;
            SendTo.Add(new EmailAddress(email, name));
            return this;
        }

        public void Validate()
        {
            if (SendTo.IsNullOrZero())
                throw new MessageException("Email message must have send to contacts".MakeThisRedable());
        }
    }
}
