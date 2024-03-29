﻿using Microsoft.AspNetCore.Http;
using MiraDesign.Common.Constants;
using System.ComponentModel.DataAnnotations;

namespace DataTransferObjects.BindingModels
{
    public class AddImagesInGalleryBindingModel
    {
        [Required]
        public IFormFile Link { get; set; }

        [Required]
        [StringLength(LengthConstants.MaxLength, MinimumLength = LengthConstants.NameMinLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(LengthConstants.MaxLength, MinimumLength = LengthConstants.NameMinLength)]
        public string About { get; set; }

        public int Id { get; set; }
    }
}
