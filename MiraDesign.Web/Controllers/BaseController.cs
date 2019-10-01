using Microsoft.AspNetCore.Mvc;
using MiraDesign.Data.Data;

namespace MiraDesign.Web.Controllers
{
    public class BaseController : Controller
    {
        protected MiraDesignContext DbContext { get; }

        protected BaseController(MiraDesignContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
