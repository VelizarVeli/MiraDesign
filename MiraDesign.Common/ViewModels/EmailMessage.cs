using System.ComponentModel.DataAnnotations;

namespace MiraDesign.Common.ViewModels
{
    public class EmailMessage : IEmailMessage
    {
        [Required(ErrorMessage = "Трябва да попълните това поле, за да може да изпратите съобщението")]
        [EmailAddress(ErrorMessage = "Невалиден имейл адрес")]
        [Display(Prompt = "Вашият имейл")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Трябва да попълните това поле, за да може да изпратите съобщението")]
        [MinLength(3, ErrorMessage = "Името трябва да има поне {1} символа")]
        [Display(Prompt = "Вашето име")]
        public string Name { get; set; }

        [Display(Prompt = "Тема")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Трябва да попълните това поле, за да може да изпратите съобщението")]
        [MinLength(3, ErrorMessage = "Съобщението трябва да има поне {1} символа")]
        [Display(Prompt = "Текст")]
        public string Content { get; set; }
    }
}
