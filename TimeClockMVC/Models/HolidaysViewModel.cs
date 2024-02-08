using TimeClockMVC.Domain.Models;

namespace TimeClockMVC.Models
{
    public class HolidaysViewModel
    {
        public PaginationDto Pagination { get; set; }
        public List<GetHolidaysDto> Holidays { get; set; }
        public string UrlApi { get; set; }
    }
}
