using TimeClockMVC.Domain.Models;

namespace TimeClockMVC.Models
{
    public class DepartmentViewModel
    {
        public List<DepartmentDto> Departments { get; set; }
        public string UrlApi { get; set; }
        public PaginationDto Pagination { get; set; }
    }
}
