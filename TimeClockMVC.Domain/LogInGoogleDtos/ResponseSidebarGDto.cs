using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeClockMVC.Domain.Models;

namespace TimeClockMVC.Domain.LogInGoogleDtos
{
    public class ResponseSidebarGDto
    {
        public bool Issuccessful { get; set; }
        public List<SidebarDto> Payload { get; set; }
        public Dictionary<string, List<string>> Errors { get; set; } = new();
    }
}
