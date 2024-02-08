using TimeClockMVC.Domain.Models;

namespace TimeClockMVC.Models
{
    public class RegisterUserViewModel
    {
        public List<UserDto> registerUser { get; set; }
        public string UrlApi { get; set; }
        public PaginationDto Pagination { get; set; }
    }
}
