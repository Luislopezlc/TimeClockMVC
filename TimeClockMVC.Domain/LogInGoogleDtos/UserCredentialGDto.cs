using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeClockMVC.Domain.LogInGoogleDtos
{
    public class UserCredentialGDto
    {
        public bool Issuccessful { get; set; }
        public PayloadUserCredentialGDto Payload { get; set; }
        public Dictionary<string, List<string>> Errors { get; set; } = new();
    }
}
