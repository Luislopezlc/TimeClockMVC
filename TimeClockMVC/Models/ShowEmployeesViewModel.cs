using TimeClockMVC.Domain.Models;

namespace TimeClockMVC.Models
{
    public class ShowEmployeesViewModel
    {
        public List<EmployeeWithEmailDto> Employees { get; set; } = new();

        public PaginationDto Pagination { get; set; }
        public string UrlApi { get; set; }
    }
}
