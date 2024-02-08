using Microsoft.AspNetCore.Mvc;
using TimeClockMVC.Domain.Models;
using TimeClockMVC.Models;

namespace TimeClockMVC.Controllers
{
    public class UsersController : CustomBaseController
    {
        private readonly IConfiguration configuration;
        public UsersController(IConfiguration configuration) : base(configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        public ActionResult ConsultUsers()
        {
            if (!this.IsSignIn())
            {

                return Redirect("/accounts/login");
            }

            var haveViewPermission = this.CanYouSeeTheView("ConsultUsers");

            if (haveViewPermission == null || haveViewPermission != true)
            {
                return Redirect("/accounts/WithoutPermissionToView");
            }

            ViewBag.Title = "Usuarios";

            var model = new RegisterUserViewModel();
            model.UrlApi = this.configuration["UrlApi"];
            return View(model);
        }

        [HttpPost]
        public PartialViewResult UsersTable([FromBody] List<UserDto> request)
        {
            var model = new RegisterUserViewModel();
            model.registerUser = request;
            return PartialView("_UsersTable", model);
        }

        [HttpGet]
        public ActionResult UpdateUsers([FromQuery] string empcode)
        {
            if (!this.IsSignIn())
            {

                return Redirect("/accounts/login");
            }
            ViewBag.Title = "Update-Usuarios";

            var model = new UpdateUserViewModel();
            model.Empcode = empcode;
            model.UrlApi = this.configuration["UrlApi"];
            return View(model);
        }

        [HttpPost]
        public PartialViewResult AreaUsersTable([FromBody] RegisterUserDto request)
        {
            var model = new UpdateUserViewModel();
            model.UrlApi = this.configuration["UrlApi"];
            model.User = request;
            return PartialView("_AreasUsersTable", model);
        }

    }
}
