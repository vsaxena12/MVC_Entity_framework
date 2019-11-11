using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Models
{
    public class LeaveTypeClass
    {
        [Key]
        [Required]
        [ForeignKey("Leave")]
        public int LeaveTypeID { get; set; }
        public virtual Leave Leave { get; set; }


        [Required]
        public string LeaveType { get; set; }
    }
}
