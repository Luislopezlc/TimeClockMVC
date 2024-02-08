using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeClockMVC.Domain.Models
{
    public class ResponseErrorDto
    {
        public string Message { get; set; } = string.Empty;
        public List<string> Messages { get; set; } = new List<string>();
    }
}
