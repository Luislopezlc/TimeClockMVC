using TimeClockMVC.Domain.Models;

namespace TimeClockMVC.Models
{
    public class IncidentReportsViewModel
    {
        public string InitialDate { get; set; }
        public string EndDate { get; set; }
        public List<EmployeeIncidentReportDto> Employees { get; set; } = new();
        public PaginationDto Pagination { get; set; }
        public string UrlApi { get; set; }
    }
}
