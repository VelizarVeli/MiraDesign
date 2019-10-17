using Microsoft.AspNetCore.Mvc;
using MiraDesign.Common.ViewModels;
using MiraDesign.Web.Mails.Contracts;

namespace MiraDesign.Web.Controllers
{
    public class MailController : Controller
    {
        private readonly IEmailService _emailService;

        public MailController(IEmailService emailService)
        {
            ViewData["Message"] = "Your contact page.";
            _emailService = emailService;
        }

        [HttpPost]
        public IActionResult SendMessage(EmailMessage message)
        {
            _emailService.Send(message);
            return RedirectToAction("Index", "Home");
        }
    }
}