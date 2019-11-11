using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Models
{
    public class User
    {
        [Key]
        [Required]
        [ForeignKey("Leave")]
        public int UserID { get; set; }
        public virtual Leave Leave { get; set; }

        [Required]
        public string UserName { get; set; }
        
        [Required]
        public string Password { get; set; }
        
        [Required]
        public string Role { get; set; }       

    }
}
