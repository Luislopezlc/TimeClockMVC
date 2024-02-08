using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;

using RestSharp;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text.Json;
using TimeClockMVC.Domain.LogInGoogleDtos;
using TimeClockMVC.Domain.Models;
using TimeClockMVC.Models;

namespace TimeClockMVC.Controllers
{
    public class AccountsController : CustomBaseController
    {
        private readonly IConfiguration configuration;

        public AccountsController(IConfiguration configuration) : base(configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.Title = "Iniciar sesión";
            var model = new LoginViewModel();
            model.UrlApi = this.configuration["UrlApi"];
            return View(model);
        }

        [HttpPost]
        public ActionResult LoginSavetoken([FromBody]TokenDto tokenDto)
        {
            var response = new ResponseDto();

            if (tokenDto != null)
            {
                try
                {
                    response.Issuccessful = true;
                    this.SaveToken(tokenDto.Token, tokenDto.Expiration);
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    response.Errors.Add("Internal Server error",  new List<string> { ex.InnerException.Message });
                    response.Issuccessful = false;
                    return BadRequest(response);
                }
            }
            else 
            {
                response.Errors.Add("Token", new List<string> { "No se pudo guardar el token" });
                response.Issuccessful = false;
                return BadRequest(response);
            }

        }

        [HttpPost]
        public IActionResult LoginSaveSidebar([FromBody] List<SidebarDto> sidebar)
        {
            var response = new ResponseDto();

            if (sidebar != null)
            {
                try
                {
                    response.Issuccessful = true;
                    this.SaveSidebar(sidebar);

                    var sidebarView = sidebar.FirstOrDefault().SidebarSecondaries.FirstOrDefault();

                    return Ok(sidebarView);
                }
                catch (Exception ex)
                {
                    response.Errors.Add("Internal Server error", new List<string> { ex.InnerException.Message });
                    response.Issuccessful = false;
                    return BadRequest(response);
                }
            }
            else
            {
                response.Errors.Add("Sidebar", new List<string> { "No se pudo guardar el token" });
                response.Issuccessful = false;
                return BadRequest(response);
            }

        }

        public async Task LoginGoogle()
        {
            AuthenticationProperties authenticationProperties = new AuthenticationProperties();
            authenticationProperties.RedirectUri = "/Accounts/GoogleResponse";

            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme,authenticationProperties);
        }

        public async Task<IActionResult> GoogleResponse() {

            var model = new LoginViewModel();

            var user = User;
            try
            {
                if (user.Identity.IsAuthenticated)
                {
                    var userData = new UserCredentialsGoogleDto()
                    {
                        GivenName = user.FindFirst(ClaimTypes.GivenName)?.Value,
                        Surname = user.FindFirst(ClaimTypes.Surname)?.Value,
                        Email = user.FindFirst(ClaimTypes.Email)?.Value,
                    };

                    var request = new RestRequest("Accounts/LogInGoogle", Method.Post);
                    request.AddBody(userData);

                    RestResponse response = await client.ExecuteAsync(request);
                    IncidentsTodayViewModel modelIndex = new IncidentsTodayViewModel();

                    if (response.IsSuccessful)
                    {
                        var dataToken = Newtonsoft.Json.JsonConvert.DeserializeObject<UserCredentialGDto>(response.Content);

                        this.SaveToken(dataToken.Payload.Token, dataToken.Payload.Expiration);
                        var sidebar = await this.GetSidebarsG(dataToken.Payload.Token);
                        if (sidebar != null && sidebar.Issuccessful)
                        {
                            this.SaveSidebar(sidebar.Payload);
                            var view = sidebar.Payload.FirstOrDefault().SidebarSecondaries.FirstOrDefault();
                            return RedirectToAction(view.Action,view.Controller);
                        }
                        else
                        {
                            model.MessageError = sidebar.Errors.FirstOrDefault().Value.FirstOrDefault();
                            return View("Login", model);
                        }
                       
                    }
                    else
                    {
                        var dataContent = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseGDto>(response.Content);
                        model.MessageError = dataContent.Errors.FirstOrDefault().Value.FirstOrDefault();
                    }

                    return View("Login", model);
                }
                else
                {
                    model.MessageError = "La cuenta con la que ha intentado acceder no es válida";
                    return View("Login", model);
                }
            }
            catch (Exception ex)
            {
                model.MessageError = "Error interno del servidor, intente mas tarde";
                return View("Login", model);
            }
            
        }



        private async Task<ResponseSidebarGDto> GetSidebarsG(string token)
        {
            var responseDto = new ResponseSidebarGDto();
            var request = new RestRequest("Authorization", Method.Get);
            request.AddHeader("Authorization", "Bearer " + token);
            RestResponse response = await client.ExecuteAsync(request);
            var sidebar = new List<SidebarDto>();
            if (response.IsSuccessful)
            {
                var responseSidebar = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseGDto> (response.Content);

                if (responseSidebar.Issuccessful)
                {
                    var sidebarDto = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseSidebarGDto>(response.Content);
                    responseDto.Issuccessful = true;
                    responseDto.Payload = sidebarDto.Payload;
                    return responseDto;
                }
                else 
                {
                    responseDto.Issuccessful = false;
                    responseDto.Errors = responseSidebar.Errors;
                    return responseDto;
                }

            }
            else
            {
                var responseSidebar = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseGDto>(response.Content);
                responseDto.Issuccessful = false;
                responseDto.Errors = responseSidebar.Errors;

                return responseDto;
            }

        }



        public IActionResult LogoutGoogle()
        {
            HttpContext.SignOutAsync(GoogleDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Accounts");   
        }

        [HttpPost]
        public IActionResult Logout() 
        {
            this.AbandonSession();
           return RedirectToAction("login", "accounts");
        }

        [HttpGet]
        public IActionResult LogoutWithoutReturnLogin()
        {
            this.AbandonSession();
            return Ok();
        }

        [HttpGet]
        public ActionResult WithoutPermissionToView()
        {
            return View("403");
        }


    }
}
