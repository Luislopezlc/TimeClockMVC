﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeClockMVC.Domain.Models
{
    public class PaginationDto
    {
        public int Page { get; set; } = 1;
        private int recordsForPage { get; set; } = 11;
        private readonly int MaximumAmountPerPage = 50;
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
        public PaginationDto() { }
        public int RecordsForPage
        {
            get
            {
                return recordsForPage;
            }

            set
            {
                recordsForPage = (value > MaximumAmountPerPage) ? MaximumAmountPerPage : value;
            }
        }

    }
}
