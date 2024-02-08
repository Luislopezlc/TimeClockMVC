using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TimeClockMVC.Domain.Models
{
    public class ResponseUserDto
    {
        public bool Issuccessful { get; set; }
        public UserDto Payload { get; set; }
       
        [JsonIgnore]
        public int Status { get; set; } = 200;
    }
}
