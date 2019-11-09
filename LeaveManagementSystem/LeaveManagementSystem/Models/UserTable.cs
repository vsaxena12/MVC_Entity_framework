using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Models
{
    public class UserTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int USERID { set; get; }

        [Required]
        public string USERNAME { get; set; }

        [Required]
        public string PASSWORD { get; set; }

        [Required]
        public string ROLE { get; set; }
    }
}
