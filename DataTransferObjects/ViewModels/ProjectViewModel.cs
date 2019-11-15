using Microsoft.AspNetCore.Http;

namespace DataTransferObjects.ViewModels
{
    public class ProjectViewModel
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public string Name { get; set; }

        public IFormFile Image400X354 { get; set; }

        public string SmallDescription { get; set; }

        public string Subname { get; set; }
    }
}
