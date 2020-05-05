using System.Threading.Tasks;

namespace App.SharedKernel.Messaging.Email
{
    public interface IEmailService
    {
        Task SendAsync(EmailParam model);
    }
}
