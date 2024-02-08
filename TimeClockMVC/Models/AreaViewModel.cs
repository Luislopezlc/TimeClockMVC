using TimeClockMVC.Domain.Models;

namespace TimeClockMVC.Models
{
    public class AreaViewModel
    {
        public List<AreaDto> Areas { get; set; }
        public string UrlApi { get; set; }
        public PaginationDto Pagination { get; set; }
    }
}
