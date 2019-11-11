using MiraDesign.Models;
using System.Collections.Generic;

namespace DataTransferObjects.BindingModels
{
    public class ProjectBindingModel
    {
        public EditProjectBindingModel ProjectModel { get; set; }
        public ICollection<Image> Images { get; set; }
    }
}
