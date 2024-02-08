
namespace TimeClockMVC.Domain.Models
{
    public class IncidentsIndividualReportEmployeeDto
    {
        public string InitialDate { get; set; }
        public string EndDate { get; set; }
        public EmployeeIncidentReportDto EmployeeIncidentsReport { get; set; } = new();
    }
}
