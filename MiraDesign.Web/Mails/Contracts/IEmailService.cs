using MiraDesign.Common.ViewModels;

namespace MiraDesign.Web.Mails.Contracts
{
    public interface IEmailService
    {
        void Send(IEmailMessage emailMessage);
    }
}
