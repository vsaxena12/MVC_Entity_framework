using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveBased_RoleBased.Models
{
    public class LeaveTypes
    {
        [Key]
        [Required]
        public int LeaveTypeID { get; set; }

        [Required]
        public string LeaveType { get; set; }
    }
}
