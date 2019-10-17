using System.Collections.Generic;
using MiraDesign.Common.ViewModels;

namespace DataTransferObjects.ViewModels
{
    public class HomeViewModel
    {
        public ICollection<ProjectViewModel> Projects { get; set; }
        public EmailMessage Message { get; set; }
    }
}
