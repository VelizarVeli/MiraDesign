using System.Collections.Generic;

namespace MiraDesign.Models
{
   public class Project
    {
        public Project()
        {
            Images = new List<Image>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string About { get; set; }

        public string Image550X365 { get; set; }

        public string Image450X398 { get; set; }

        public string Image400X354 { get; set; }

        public string Image1280X478 { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}
