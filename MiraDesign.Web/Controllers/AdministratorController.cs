using System.Threading.Tasks;
using DataTransferObjects.BindingModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiraDesign.Data.Data;
using MiraDesign.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MiraDesign.Web.Controllers
{
    [Authorize]
    public class AdministratorController : BaseController
    {
        public AdministratorController(MiraDesignContext dbContext)
            : base(dbContext)
        {
        }
        public IActionResult AddProject()
        {
            return View("AddProject");
        }

        [HttpPost]
        public async Task<IActionResult> AddProjectPost(AdminProjectBindingModel model)
        {
            var project = new Project
            {
                About = model.About,
                Name = model.Name,
                Number = model.Number,
                Subname = model.Subname,
                Image1280X478 = model.Image1280X478,
                Image400X354 = model.Image400X354,
                Image450X398 = model.Image450X398,
                Image550X365 = model.Image550X365
            };
            await DbContext.Projects.AddAsync(project);
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
            var projectDto = new EditProjectBindingModel
            {
                Id = project.Id,
                Number = project.Number,
                Name = project.Name,
                Subname = project.Subname,
                About = project.About,
                Image550X365 = project.Image550X365,
                Image450X398 = project.Image450X398,
                Image400X354 = project.Image400X354,
                Image1280X478 = project.Image1280X478,
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
        public async Task<IActionResult> ProjectEdit(int id, EditProjectBindingModel incomingModel)
        {
            if (!ModelState.IsValid)
            {
                RedirectToAction("Details", "Projects", id);
            }

            var model = DbContext.Projects.FirstOrDefault(i => i.Id == id);

            model.Image1280X478 = incomingModel.Image1280X478;
            model.Image400X354 = incomingModel.Image400X354;
            model.Image450X398 = incomingModel.Image450X398;
            model.Image550X365 = incomingModel.Image550X365;
            model.Images = incomingModel.Images;
            model.Name = incomingModel.Name;
            model.Number = incomingModel.Number;
            model.Subname = incomingModel.Subname;
            model.About = incomingModel.About;

            DbContext.Projects.Update(model);
            await DbContext.SaveChangesAsync();

            return RedirectToAction("Details", "Projects", new { id});
        }
    }
}