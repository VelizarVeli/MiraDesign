using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MiraDesign.Common.Constants;

namespace MiraDesign.Models
{
    public class Project : BaseId
    {
        public Project()
        {
            Images = new List<Image>();
        }

        [Required]
        public int Number { get; set; }

        [Required]
        [StringLength(LengthConstants.MaxLength, MinimumLength = LengthConstants.NameMinLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(LengthConstants.MaxLength, MinimumLength = LengthConstants.NameMinLength)]
        public string Subname { get; set; }

        [Required]
        public string About { get; set; }

        [Required]
        public string Image550X365 { get; set; }

        [Required]
        public string Image450X398 { get; set; }

        [Required]
        public string Image400X354 { get; set; }

        [Required]
        public string Image1280X478 { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}
