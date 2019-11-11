using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_MVC.Models
{
    public class Leaves
    {
        [Key]
        [Required]
        public int LeaveID { get; set; }


        [Required]
        public int UserID { get; set; }

        [Required]
        public int LeaveTypeID { get; set; }
   

        [Required]
        public int Noofdays { get; set; }

        [Required]
        public string LeaveReason { get; set; }

        [Required]
        public string LeaveStatus { get; set; }

        [ForeignKey("UserID")]
        public virtual Users Users { get; set; }

        [ForeignKey("LeaveTypeID")]
        public virtual LeaveTypeClass LeaveTypeClass { get; set; }
    }
}
