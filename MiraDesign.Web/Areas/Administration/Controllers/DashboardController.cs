using Microsoft.AspNetCore.Mvc;

namespace MiraDesign.Web.Areas.Administration.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}