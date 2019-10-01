using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataTransferObjects.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiraDesign.Data.Data;
using MiraDesign.Web.Models;

namespace MiraDesign.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(MiraDesignContext dbContext) 
            : base(dbContext)
        {
        }

        public async Task<IActionResult> Index()
        {
            var projects = await DbContext.Projects.Select(p => new ProjectViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Image400X354 = p.Image400X354,
                SmallDescription = p.About
            }).ToListAsync();

            return View(projects);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
