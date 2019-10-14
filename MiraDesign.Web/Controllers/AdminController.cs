using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MiraDesign.Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        public IActionResult AddProject()
        {
            return View();
        }
    }
}