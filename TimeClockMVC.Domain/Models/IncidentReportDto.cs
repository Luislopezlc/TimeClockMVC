using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeClockMVC.Domain.Models
{
    public class IncidentReportDto
    {
        public string InitialDate { get; set; }
        public string EndDate { get; set; }
        public List<EmployeeIncidentReportDto> Employees { get; set; } = new();
    }
}
