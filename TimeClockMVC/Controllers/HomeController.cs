using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json;
using TimeClockMVC.Domain.Models;
using TimeClockMVC.Models;

namespace TimeClockMVC.Controllers
{
    public class HomeController : CustomBaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration configuration;
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration): base(configuration)
        {
            _logger = logger;
            this.configuration = configuration;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            if (!this.IsSignIn())
            {
                return Redirect("/accounts/login");
            }

            ViewBag.Title = "Dashboard";

            var model = new IncidentsTodayViewModel();

            model.UrlApi = this.configuration["UrlApi"];

            return View(model);
        }

        [HttpPost]
        public PartialViewResult DashboardCards([FromBody] IncidentsTodayViewModel request)
        {
            return PartialView("_DashboardCards", request);
        }


    }
}