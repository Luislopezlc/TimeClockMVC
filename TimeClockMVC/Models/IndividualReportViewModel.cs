using TimeClockMVC.Domain.Models;

namespace TimeClockMVC.Models
{
    public class IndividualReportViewModel
    {
        public string UrlApi { get; set; }

        public IncidentsIndividualReportEmployeeDto IncidentReport { get; set; }
    }
}
