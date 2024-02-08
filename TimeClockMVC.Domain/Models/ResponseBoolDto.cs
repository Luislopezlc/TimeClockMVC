using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeClockMVC.Domain.Models
{
    public class ResponseBoolDto
    {
        public bool Issuccessful { get; set; }
        public bool Payload { get; set; }
        public Dictionary<string, List<string>> Errors { get; set; } = new();

    }
}
