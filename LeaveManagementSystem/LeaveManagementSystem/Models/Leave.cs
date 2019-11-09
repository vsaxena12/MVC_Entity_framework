using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Models
{
    public class Leave
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LEAVEID { get; set; }

        [ForeignKey("UserTable")]
        public int USERID { set; get; }

        [ForeignKey("LeaveType")]
        public int LEAVETYPEID { get; set; }

        [Required]
        public string NOOFDAYS { get; set; }

        [Required]
        public string LEAVEREASON { get; set; }

        [Required]
        public string LEAVESTATUS { get; set; }

        public virtual UserTable UserTable { get; set; }

        public virtual LeaveType LeaveType { get; set; }

    }
}
