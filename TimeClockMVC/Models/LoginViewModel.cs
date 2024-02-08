using TimeClockMVC.Domain.Models;

namespace TimeClockMVC.Models
{
    public class LoginViewModel
    {
        public string MessageError { get; set; }
        public string UrlApi { get; set; }
        public List<SidebarDto> Sidebar { get; set; }
    }
}
