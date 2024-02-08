using Microsoft.AspNetCore.Mvc;
using TimeClockMVC.Models;

namespace TimeClockMVC.Controllers
{
    public class HolidaysController : CustomBaseController
    {
        private readonly IConfiguration configuration;
        public HolidaysController(IConfiguration configuration) : base(configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (!this.IsSignIn())
            {

                return Redirect("/accounts/login");
            }

            var haveViewPermission = this.CanYouSeeTheView("Index");

            if (haveViewPermission == null || haveViewPermission != true)
            {
                return Redirect("/accounts/WithoutPermissionToView");
            }

            ViewBag.Title = "Días inhábiles";
            var model = new HolidaysViewModel();
            model.UrlApi = this.configuration["UrlApi"];
            return View(model);
        }


        [HttpPost]
        public PartialViewResult HolidaysTable([FromBody] HolidaysViewModel request)
        {
            return PartialView("_HolidaysTable", request);
        }
    }
}
