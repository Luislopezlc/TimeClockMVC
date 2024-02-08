using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeClockMVC.Domain.Models
{
    public class RegisterUserDto
    {
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime? CreationDate { get; set; } = DateTime.Now;
        [Required]
        public bool? IsActive { get; set; } = true;
        [Required]
        public string EmployeeCode { get; set; }
        [Required]
        public int AreaId { get; set; }
        [Required]
        public string DepartmentId { get; set; }
        [Required]
        public bool IsLeader { get; set; }

        public List<AreasUsersDto> AreasUsers { get; set; }
    }
}
