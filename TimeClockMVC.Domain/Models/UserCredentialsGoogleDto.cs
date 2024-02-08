using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeClockMVC.Domain.Models
{
    public class UserCredentialsGoogleDto
    {
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }
}
