using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MiraDesign.Common.Constants;
using MiraDesign.Models;

namespace DataTransferObjects.BindingModels
{
    public class AdminProjectBindingModel
    {
        public AdminProjectBindingModel()
        {
            Images = new List<Image>();
        }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
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
        [Display(Name = "Image 550 x 365")]
        public string Image550X365 { get; set; }

        [Required]
        [Display(Name = "Image 450 x 398")]
        public string Image450X398 { get; set; }

        [Required]
        [Display(Name = "Image 400 x 354")]
        public string Image400X354 { get; set; }

        [Required]
        [Display(Name = "Image 1280 x 478")]
        public string Image1280X478 { get; set; }

        public ICollection<Image> Images { get; set; }

    }
}
