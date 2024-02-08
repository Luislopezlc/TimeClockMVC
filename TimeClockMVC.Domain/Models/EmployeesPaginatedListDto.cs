using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeClockMVC.Domain.Models
{
    public class EmployeesPaginatedListDto
    {
        public List<EmployeeWithEmailDto> Employees { get; set; } = new();

        public PaginationDto Pagination { get; set; }
    }
}
