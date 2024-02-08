using Microsoft.AspNetCore.Mvc;
using System.Security;
using TimeClockMVC.Domain.Models;
using TimeClockMVC.Models;

namespace TimeClockMVC.Controllers
{
    public class AreaController : CustomBaseController
    {
        private readonly IConfiguration configuration;
        public AreaController(IConfiguration configuration) : base(configuration)
        {
            this.configuration = configuration;
        }
        [HttpGet]
        public ActionResult areas()
        {
            if (!this.IsSignIn())
            {

                return Redirect("/accounts/login");
            }

            var haveViewPermission = this.CanYouSeeTheView("areas");

            if (haveViewPermission == null || haveViewPermission != true)
            {
                return Redirect("/accounts/WithoutPermissionToView");
            }

            ViewBag.Title = "Areas";

            var model = new AreaViewModel();
            model.UrlApi = this.configuration["UrlApi"];
            return View(model);
        }

        [HttpPost]
        public PartialViewResult AreasTable([FromBody] AreaViewModel request)
        {
            return PartialView("_AreasTable", request);
        }
    }
}
