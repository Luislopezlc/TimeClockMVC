﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeClockMVC.Domain.Models
{
    public class AreaDto
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required, StringLength(10)]
        public string Code { get; set; }
        [Required]
        public string EmployeeCode { get; set; }
        public string FullName { get; set; }
        public int DeparmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
