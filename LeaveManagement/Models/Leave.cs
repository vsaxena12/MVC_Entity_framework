using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Models
{
    public class Leave
    {
        [Key]
        [Required]
        public int LeaveID { get; set; }


        [Required]
        [ForeignKey("")]
        public int UserID { get; set; }
        public virtual User User { get; set; }


        [Required]
        [ForeignKey("")]
        public int LeaveTypeID { get; set; }
        public virtual LeaveTypeClass LeaveTypeClass { get; set; }

        [Required]
        public int Noofdays { get; set; }

        [Required]
        public string LeaveReason { get; set; }

        [Required]
        public string LeaveStatus { get; set; }

    }
}
