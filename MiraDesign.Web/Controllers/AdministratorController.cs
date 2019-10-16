using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiraDesign.Data.Data;

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

        //[Authorize]
        //[HttpPost]
        //public async Task<IActionResult> AddExpenditurePost(ExpenditureModalBindingModel model)
        //{
        //    await _accountService.AddExpenditure(model, _user.GetUserId(User));
        //    return RedirectToAction("Index", "Home");
        //}
    }
}