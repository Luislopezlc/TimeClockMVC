using Microsoft.AspNetCore.Mvc;
using TimeClockMVC.Domain.Models;
using TimeClockMVC.Models;

namespace TimeClockMVC.Controllers
{
    public class BusinessStructureController : CustomBaseController
    {
        private readonly IConfiguration configuration;
        public BusinessStructureController(IConfiguration configuration) : base(configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        public ActionResult positions()
        {
            if (!this.IsSignIn())
            {

                return Redirect("/accounts/login");
            }

            var haveViewPermission = this.CanYouSeeTheView("positions");

            if (haveViewPermission == null || haveViewPermission != true)
            {
                return Redirect("/accounts/WithoutPermissionToView");
            }

            ViewBag.Title = "Puestos";

            var model = new PositionViewModel();
            model.UrlApi = this.configuration["UrlApi"];
            return View(model);
        }

        [HttpPost]
        public PartialViewResult PositionsTable([FromBody] PositionViewModel request)
        {
            return PartialView("_PositionsTable", request);
        }

    }
}
