using TimeClockMVC.Domain.Models;

namespace TimeClockMVC.Models
{
    public class IncidentsTodayViewModel
    {
        public List<IncidentToday> IncidentsToday { get; set; } = new();
        public List<EmployeeWithEmailDto> Employee { get; set; } = new();
        public string UrlApi { get; set; }
        public UserDto UserDto { get; set; }

    }
}
