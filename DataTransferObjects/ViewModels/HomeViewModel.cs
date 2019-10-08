using System.Collections.Generic;

namespace DataTransferObjects.ViewModels
{
    public class HomeViewModel
    {
        public ICollection<ProjectViewModel> Projects { get; set; }
        public ICollection<FrontGalleryViewModel> Gallery { get; set; }
    }
}
