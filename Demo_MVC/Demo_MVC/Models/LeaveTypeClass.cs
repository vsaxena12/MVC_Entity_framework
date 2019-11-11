﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_MVC.Models
{
    public class LeaveTypeClass
    {
        [Key]
        [Required]       
        public int LeaveTypeID { get; set; }

        [Required]
        public string LeaveType { get; set; }
    }
}
