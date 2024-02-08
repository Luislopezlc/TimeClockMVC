using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TimeClockMVC.Domain.LogInGoogleDtos
{
    public class ResponseGDto
    {
        public bool Issuccessful { get; set; }
        public object Payload { get; set; }
        public Dictionary<string, List<string>> Errors { get; set; }
    }
}
