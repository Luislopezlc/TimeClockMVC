using Microsoft.AspNetCore.Mvc;
using TimeClockMVC.Domain.Models;
using TimeClockMVC.Models;

namespace TimeClockMVC.Controllers
{
    public class DepartmentController : CustomBaseController
    {
        private readonly IConfiguration configuration;
        public DepartmentController(IConfiguration configuration) : base(configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        public ActionResult departments()
        {
            if (!this.IsSignIn())
            {

                return Redirect("/accounts/login");
            }

            var haveViewPermission = this.CanYouSeeTheView("departments");

            if (haveViewPermission == null || haveViewPermission != true)
            {
                return Redirect("/accounts/WithoutPermissionToView");
            }

            ViewBag.Title = "Departamentos";

            var model = new DepartmentViewModel();
            model.UrlApi = this.configuration["UrlApi"];
            return View(model);
        }

        [HttpPost]
        public PartialViewResult DepartmentsTable([FromBody] DepartmentViewModel request)
        {
            return PartialView("_DepartamentsTable", request);
        }
    }
}
