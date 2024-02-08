using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TimeClockMVC.Domain.Models
{
    public class ResponseDto
    {
        public bool Issuccessful { get; set; }
        public object Payload { get; set; }
        public Dictionary<string, List<string>> Errors { get; set; } = new();
        
    }
}
