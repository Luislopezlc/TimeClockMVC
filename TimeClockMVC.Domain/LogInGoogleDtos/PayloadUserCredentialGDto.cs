using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeClockMVC.Domain.LogInGoogleDtos
{
    public class PayloadUserCredentialGDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
