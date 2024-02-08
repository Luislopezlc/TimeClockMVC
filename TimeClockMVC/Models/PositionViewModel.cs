using TimeClockMVC.Domain.Models;

namespace TimeClockMVC.Models
{
    public class PositionViewModel
    {
        public List<PositionDto> positions { get; set; }
        public string UrlApi { get; set; }
        public PaginationDto Pagination { get; set; }

    }
}
