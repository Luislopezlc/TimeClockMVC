using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeClockMVC.Domain.Models
{
    public class Personnel_SchedulesDto
    {
        [Required(ErrorMessage = "El campo codigo de empleado es requerido")]
        public string EmployeeCode { get; set; }
        [Required(ErrorMessage = "El campo hora de entrada es requerido")]
        public string CheckInTime { get; set; }
        [Required(ErrorMessage = "El campo hora de salida es requerido"),]
        public string CheckOutTime { get; set; }
        [Required(ErrorMessage = "El campo dia es requerido"),]
        public int ValueDay { get; set; }
    }
}
