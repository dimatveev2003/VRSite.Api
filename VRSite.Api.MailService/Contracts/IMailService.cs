using System.Threading.Tasks;
using VRSite.Api.MailService.Models;

namespace VRSite.Api.MailService.Contracts
{
    public interface IMailService
    {
        Task SendRegistrationMail(UserModel model);

        Task SendOrderCreatedMailToManager(UserModel user, CreatedOrderModel model);
    }
}