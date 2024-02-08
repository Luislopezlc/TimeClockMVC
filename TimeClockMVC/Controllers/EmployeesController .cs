using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Reflection;
using System.Text.Json;
using TimeClockMVC.Domain.Models;
using TimeClockMVC.Models;

namespace TimeClockMVC.Controllers
{

    public class EmployeesController : CustomBaseController
    {
        private readonly IConfiguration configuration;

        public EmployeesController(IConfiguration configuration) : base(configuration)
        {
            this.configuration = configuration;
        }
        // GET: EmployeesController
        [HttpGet]
        public ActionResult ShowEmployees([FromQuery] PaginationDto pagination)
        {
            if (!this.IsSignIn())
            {

               return Redirect("/accounts/login");
            }
            var haveViewPermission = this.CanYouSeeTheView("ShowEmployees");

            if (haveViewPermission == null || haveViewPermission != true)
            {
                return Redirect("/accounts/WithoutPermissionToView");
            }

            ViewBag.Title = "Horarios";

            var model = new ShowEmployeesViewModel();
            model.UrlApi = this.configuration["UrlApi"];
            return View(model);
        }


        [HttpPost]
        public PartialViewResult EmployeesTable([FromBody] EmployeesPaginatedListDto request)
        {
            var model = new ShowEmployeesViewModel();
            model.Employees = request.Employees;
            model.Pagination = request.Pagination;
            return PartialView("_EmployeesTable", model);
        }
        
    }
}
