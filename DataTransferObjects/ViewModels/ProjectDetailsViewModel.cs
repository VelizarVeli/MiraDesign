
using System.Collections.Generic;
using MiraDesign.Models;

namespace DataTransferObjects.ViewModels
{
    public class ProjectDetailsViewModel
    {
        public int  Id { get; set; }

        public string Name { get; set; }

        public string Subname { get; set; }

        public string About { get; set; }

        public string Image1280X478 { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}
