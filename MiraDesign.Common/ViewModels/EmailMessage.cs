using System.ComponentModel.DataAnnotations;

namespace MiraDesign.Common.ViewModels
{
    public class EmailMessage : IEmailMessage
    {
        [Required]
        [MinLength(3, ErrorMessage = "{0} must be more than or equal to {1} characters")]
        [Display(Prompt = "Вашето име")]
        public string Name { get; set; }

        [Required]
        [Display(Prompt = "Вашият имейл")]
        public string Email { get; set; }

        [Display(Prompt = "Тема")]
        public string Subject { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Message should be more than or equal to {1} characters")]
        [Display(Prompt = "Текст")]
        public string Content { get; set; }
    }
}
