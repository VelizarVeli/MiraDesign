using System.Threading.Tasks;
using DataTransferObjects.BindingModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiraDesign.Data.Data;
using MiraDesign.Models;
using System.Linq;

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

            return RedirectToAction("Home", "Index");
        }
    }
}