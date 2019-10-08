using System.ComponentModel.DataAnnotations;
using MiraDesign.Common.Constants;

namespace MiraDesign.Models
{
    public class Image : BaseId
    {
        [Required]
        public string Link { get; set; }

        [Required]
        [StringLength(LengthConstants.MaxLength, MinimumLength = LengthConstants.NameMinLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(LengthConstants.MaxLength, MinimumLength = LengthConstants.NameMinLength)]
        public string About { get; set; }

        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}
