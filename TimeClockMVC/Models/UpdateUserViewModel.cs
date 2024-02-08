using TimeClockMVC.Domain.Models;

namespace TimeClockMVC.Models
{
    public class UpdateUserViewModel
    {
        public string Empcode { get; set; }
        public string UrlApi { get; set; }
        public RegisterUserDto User { get; set; }
    }
}
