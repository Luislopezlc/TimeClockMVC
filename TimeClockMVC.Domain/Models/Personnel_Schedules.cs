﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeClockMVC.Domain.Models
{
    public class Personnel_Schedules
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string EmployeeCode { get; set; }
        [Required]
        public string CheckInTime { get; set; }
        [Required]
        public string CheckOutTime { get; set; }
        public int DayId { get; set; }
        [ForeignKey("DayId")]
        public Att_Days Day { get; set; }

    }
}
