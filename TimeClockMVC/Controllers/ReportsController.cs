using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Reflection;
using System.Text.Json;
using TimeClockMVC.Domain.Models;
using TimeClockMVC.Models;

namespace TimeClockMVC.Controllers
{
    public class ReportsController : CustomBaseController
    {
        private readonly IConfiguration configuration;
        public ReportsController(IConfiguration configuration) : base(configuration)
        {
            this.configuration = configuration;
        }


        [HttpGet]
        public ActionResult Incidents([FromQuery] string InitialDate, [FromQuery] string EndDate)
        {
            if (!this.IsSignIn())
            {

                return Redirect("/accounts/login");
            }

            var haveViewPermission = this.CanYouSeeTheView("Incidents");

            if (haveViewPermission == null || haveViewPermission != true)
            {
                return Redirect("/accounts/WithoutPermissionToView");
            }

            ViewBag.Title = "Incidencias";

            var model = new IncidentReportsViewModel();
            model.UrlApi = this.configuration["UrlApi"];
            return View(model);
        }

        [HttpGet]
        public ActionResult AutomaticEmails([FromQuery] string InitialDate, [FromQuery] string EndDate)
        {
            if (!this.IsSignIn())
            {

                return Redirect("/accounts/login");
            }

            var haveViewPermission = this.CanYouSeeTheView("AutomaticEmails");

            if (haveViewPermission == null || haveViewPermission != true)
            {
                return Redirect("/accounts/WithoutPermissionToView");
            }

            ViewBag.Title = "Correos";

            var model = new AutomaticEmailsViewModel();
            model.UrlApi = this.configuration["UrlApi"];
            model.ApiKey = this.configuration["ApiKey"];
            return View(model);
        }

        [HttpPost]
        public PartialViewResult IncidentsReportTable([FromBody] IncidentReportsViewModel request)
        {
            
            return PartialView("_IncidentsReportTable", request);
        }

        [HttpGet]
        public ActionResult IndividualReport()
        {

            if (!this.IsSignIn())
            {

                return Redirect("/accounts/login");
            }
            ViewBag.Title = "Dashboard";

            var model = new IndividualReportViewModel();
            model.UrlApi = this.configuration["UrlApi"];
            return View(model);
        }

        [HttpPost]
        public PartialViewResult IndividualReportTable([FromBody] IncidentsIndividualReportEmployeeDto request)
        {
            var model = new IndividualReportViewModel();
            model.IncidentReport = request;
            return PartialView("_IndividualReportTable", model);
        }
    }
}
