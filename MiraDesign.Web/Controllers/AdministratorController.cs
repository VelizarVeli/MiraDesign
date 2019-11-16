using System.Threading.Tasks;
using DataTransferObjects.BindingModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiraDesign.Data.Data;
using MiraDesign.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using MiraDesign.Common.Extensions;

namespace MiraDesign.Web.Controllers
{
    [Authorize]
    public class AdministratorController : BaseController
    {
        private readonly ICloudinaryService _cloudinaryService;

        public AdministratorController(MiraDesignContext dbContext, ICloudinaryService cloudinaryService)
            : base(dbContext)
        {
            _cloudinaryService = cloudinaryService;
        }
        public IActionResult AddProject()
        {
            return View("AddProject");
        }

        [HttpPost]
        public async Task<IActionResult> AddProjectPost(AdminProjectBindingModel model)
        {
            string pictureUrl1280X478 = await _cloudinaryService.UploadPictureAsync(
                model.Image1280X478,
                model.Name);

            string pictureUrl400X354 = await _cloudinaryService.UploadPictureAsync(
                model.Image400X354,
                model.Name);

            string pictureUrl450X398 = await _cloudinaryService.UploadPictureAsync(
                model.Image450X398,
                model.Name);

            string pictureUrl550X365 = await _cloudinaryService.UploadPictureAsync(
                model.Image550X365,
                model.Name);

            //var images = new HashSet<Image>();
            //foreach (var imageDTO in model.Images.Split(new[] { '}' }, StringSplitOptions.RemoveEmptyEntries))
            //{
            //    var property = imageDTO.Split(new[] { '$' }, StringSplitOptions.RemoveEmptyEntries);
            //    if (property.Length == 3)
            //    {
            //        var image = new Image()
            //        {
            //            Name = property[0],
            //            About = property[1],
            //            Link = property[2]
            //        };
            //    }
            //}

            var project = new Project
            {
                About = model.About,
                Name = model.Name,
                Number = model.Number,
                Subname = model.Subname,
                Image1280X478 = pictureUrl1280X478,
                Image400X354 = pictureUrl400X354,
                Image450X398 = pictureUrl450X398,
                Image550X365 = pictureUrl550X365,
            };
            await DbContext.Projects.AddAsync(project);
            await DbContext.SaveChangesAsync();
            int id = project.Id;
            return RedirectToAction("AddImagesInGallery", new { id });
        }

        public IActionResult AddImagesInGallery(int id)
        {
            ViewBag.Id = id;

            return View("AddImagesInGallery");
        }

        [HttpPost]
        public async Task<IActionResult> AddImagesInGalleryPost(IEnumerable<AddImagesInGalleryBindingModel> model, int id)
        {
            var checkId = id;
            var images = new List<Image>();
            
            foreach (var image in model)
            {
                //string picture = await _cloudinaryService.UploadPictureAsync(
                //    image.Link,
                //    image.Name);
                var pic = new Image
                {
                    Link = "",
                    Name = image.Name,
                    About = image.About,
                    ProjectId = id
                };

                images.Add(pic);
            }
                                 
            await DbContext.Images.AddRangeAsync(images);
            await DbContext.SaveChangesAsync();
            return RedirectToAction("AddProject");
        }

        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = DbContext.Projects.SingleOrDefault(e => e.Id == id);
            if (project != null)
            {
                DbContext.Projects.Remove(project);
                await DbContext.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> EditProject(int id)
        {
            var project = await DbContext.Projects.Include(a => a.Images).SingleOrDefaultAsync(i => i.Id == id);
            var projectDto = new ProjectBindingModel
            {
                ProjectModel = new EditProjectBindingModel
                {
                    Id = project.Id,
                    Number = project.Number,
                    Name = project.Name,
                    Subname = project.Subname,
                    About = project.About,
                    //Image550X365 = project.Image550X365,
                    //Image450X398 = project.Image450X398,
                    //Image400X354 = project.Image400X354,
                    //Image1280X478 = project.Image1280X478,
                },
                Images = project.Images.Select(i => new Image
                {
                    Name = i.Name,
                    About = i.About,
                    Link = i.Link
                }).ToList()
            };

            return View("EditProject", projectDto);
        }

        [HttpPost]
        public async Task<IActionResult> ProjectEdit(int id, ProjectBindingModel incomingModel)
        {
            if (!ModelState.IsValid)
            {
                RedirectToAction("Details", "Projects", id);
            }

            var model = DbContext.Projects.FirstOrDefault(i => i.Id == id);

            //model.Image1280X478 = incomingModel.ProjectModel.Image1280X478;
            //model.Image400X354 = incomingModel.ProjectModel.Image400X354;
            //model.Image450X398 = incomingModel.ProjectModel.Image450X398;
            //model.Image550X365 = incomingModel.ProjectModel.Image550X365;
            model.Images = incomingModel.Images;

            DbContext.Projects.Update(model);
            await DbContext.SaveChangesAsync();

            return RedirectToAction("Details", "Projects", new { id });
        }
    }
}