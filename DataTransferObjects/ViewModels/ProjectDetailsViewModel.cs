using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using MiraDesign.Models;

namespace DataTransferObjects.ViewModels
{
    public class ProjectDetailsViewModel
    {
        public int  Id { get; set; }

        public string Name { get; set; }

        public string Subname { get; set; }

        public string About { get; set; }

        public IFormFile Image1280X478 { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}
