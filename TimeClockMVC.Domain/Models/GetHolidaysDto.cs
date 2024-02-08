using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeClockMVC.Domain.Models
{
    public class GetHolidaysDto
    {
        public int Id { get; set; }
        public string Day { get; set; }
        public bool IsPartial { get; set; }
        public string CheckIn { get; set; }
        public string CheckOut { get; set; }
        public bool IsActive { get; set; }
        public List<string> Departments { get; set; } = new List<string>();
    }
}
