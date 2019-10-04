using System.Linq;
using System.Threading.Tasks;
using DataTransferObjects.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiraDesign.Data.Data;

namespace MiraDesign.Web.Controllers
{
    public class ProjectsController : BaseController

    {
        public ProjectsController(MiraDesignContext dbContext) 
            : base(dbContext)
        {
        }

        public async Task<IActionResult> Details(int id)
        {
            var project = await DbContext
                .Projects
                .Include(i => i.Images)
                .SingleOrDefaultAsync(i => i.Id == id);

            var projectModel = new ProjectDetailsViewModel
            {
                Id = project.Id,
                About = project.About,
                Images = project.Images.ToList(),
                Name = project.Name,
                Image1280X478 = project.Image1280X478
            };

            return View(projectModel);
        }
    }
}