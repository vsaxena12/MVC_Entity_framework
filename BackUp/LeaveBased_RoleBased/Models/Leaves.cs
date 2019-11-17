using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveBased_RoleBased.Models
{
    public class Leaves
    {
        [Key]
        [Required]
        public int LeaveID { get; set; }


        [Required]
        [ForeignKey("Id")]
        public string Id { get; set; }

        [Required]
        public int LeaveTypeID { get; set; }


        [Required]
        public int Noofdays { get; set; }

        [Required]
        public string LeaveReason { get; set; }

        [Required]
        public string LeaveStatus { get; set; }

        
        //public virtual Users Users { get; set; }

        [ForeignKey("LeaveTypeID")]
        public virtual LeaveTypes LeaveTypeClass { get; set; }
    }
}
