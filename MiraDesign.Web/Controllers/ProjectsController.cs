using Microsoft.AspNetCore.Mvc;

namespace MiraDesign.Web.Controllers
{
    public class ProjectsController : Controller
    {
        public IActionResult Details()
        {
            return View();
        }
    }
}