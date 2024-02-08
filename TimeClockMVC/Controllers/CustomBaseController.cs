using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text.Json;
using TimeClockMVC.Domain.LogInGoogleDtos;
using TimeClockMVC.Domain.Models;
using TimeClockMVC.Models;

namespace TimeClockMVC.Controllers
{
    public class CustomBaseController : Controller
    {
        private readonly IConfiguration configuration;
        public readonly RestClient client;
        public readonly JsonSerializerOptions options;

        public CustomBaseController(IConfiguration configuration)
        {
            this.configuration = configuration;
            var urlApi = this.configuration["UrlApi"];
            this.client = new RestClient(urlApi);

            this.options = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNameCaseInsensitive = true
            };
        }

        public void SaveToken(string token, DateTime expiration)
        {
            HttpContext.Session.SetString("Token", token);
            HttpContext.Session.SetString("Expiration", expiration.ToString());
            //var sidebar = SaveSidebar();
            //HttpContext.Session.SetString("Sidebar", sidebar);
            var user = GetUser();
            HttpContext.Session.SetString("User", user);

        }

        public void SaveSidebar(List<SidebarDto> sidebar)
        {
            var jsonSidebar = JsonSerializer.Serialize(sidebar);
            HttpContext.Session.SetString("Sidebar", jsonSidebar);
        }

        public string GetUser()
        {
            var userRequest = new RestRequest("Users", Method.Get);
            var token = this.GetToken();
            userRequest.AddHeader("Authorization", "Bearer " + token.ToString());
          
            RestResponse responseUser =  client.Execute(userRequest);

            var userJson = string.Empty;

            if (responseUser.IsSuccessful)
            {
                 
                var dataUser = JsonSerializer.Deserialize<ResponseUserDto>(responseUser.Content, this.options);
                

                userJson = JsonSerializer.Serialize(dataUser.Payload, this.options);
            }

           
            return userJson;
        }


        public string GetToken() 
        {
            var token = HttpContext.Session.GetString("Token");
            var expiration = HttpContext.Session.GetString("Expiration");

            CheckExpiration(token, expiration);
            //var dateExpiration = Convert.ToDateTime(expiration);

            //TimeSpan timeLeft = dateExpiration - DateTime.Now;

            //int totalMinutes = (int)timeLeft.TotalMinutes;

            //if (totalMinutes < 3)//si le faltan 3 minutos al token para que expire pedimos otro token
            //{
            //    RevewToken(token);
            //}

            return token;
        }

        public bool? CanYouSeeTheView(string viewName)
        {
            var request = new RestRequest("Authorization/GetViewPermission", Method.Get);
            request.AddHeader("Authorization", "Bearer " + this.GetToken());
            request.AddQueryParameter("viewName", viewName);
            RestResponse response =  client.Execute(request);
            if (response.IsSuccessful)
            {
                var responseDto = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBoolDto>(response.Content);
                return responseDto.Payload;
            }
            else
            {
                return null;
            }

        }

        public bool IsSignIn() 
        {
            
            var token = HttpContext.Session?.GetString("Token");
            var expiration = HttpContext.Session?.GetString("Expiration");
            if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(expiration))
            {
                return false;
            }

           if(CheckExpiration(token, expiration))
            {
                return false;
            }

            return true;
        }


        private void RevewToken(string token)
        {
            //este metodo deberia funcionar como la renovacion de un token 
            //aun no se como implementarlo
            //var request = new RestRequest("Accounts/RenewToken", Method.Get);
            //request.AddHeader("Authorization", "Bearer " + token);
            //RestResponse response = await client.ExecuteAsync(request);

            //if (response.IsSuccessful)
            //{
            //    // La petición fue exitosa, puedes obtener los datos de la respuesta
            //    var data = JsonSerializer.Deserialize<TokenDto>(response.Content, this.options);
            //    HttpContext.Session.Remove("Token");
            //    HttpContext.Session.Remove("Expiration");
            //    HttpContext.Session.SetString("Token", data.Token);
            //    HttpContext.Session.SetString("Expiration", data.Expiration.ToString());

            //}
            //else
            //{
            //    AbandonSession();
            //}
            AbandonSession();
        }

        public void AbandonSession()
        {
            HttpContext.Session.Clear();
        }

        //revisa la expiracion del token si necesita renovarse devuelve un true
        private bool CheckExpiration(string token, string expiration)
        {
            var dateExpiration = Convert.ToDateTime(expiration);

            TimeSpan timeLeft = dateExpiration - DateTime.Now;

            int totalMinutes = (int)timeLeft.TotalMinutes;

            if (totalMinutes < 1)//si le faltan 1 minuto al token para que expire pedimos otro token
            {
                 RevewToken(token);
                 return true;
            }
            else
            {
                return false;
            }
        }

        
    }
}
