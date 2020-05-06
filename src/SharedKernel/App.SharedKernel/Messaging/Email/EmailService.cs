using App.SharedKernel.Exception;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace App.SharedKernel.Messaging.Email
{
    public class EmailService: IEmailService
    {
        public async Task SendAsync(EmailParam model)
        {
            try
            {
                model.Validate();
                var client = new SendGridClient(GlobalConfig.EmailConfig.SendGridApiKey);
                var from = new EmailAddress(GlobalConfig.EmailConfig.FromEmail, GlobalConfig.EmailConfig.FromName);
                var tos = model.SendTo;

                var subject = model.Subject;
                var htmlContent = model.Body;
                var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, tos, subject, "", htmlContent, false);
                var result = await client.SendEmailAsync(msg);
            }
            catch (System.Exception e)
            {
                throw new MessageException(e);
            }

        }
    }
}
