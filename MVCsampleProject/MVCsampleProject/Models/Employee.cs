using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCsampleProject.Models
{
    public class Employee
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Designation { get; set; }


       
        [Required]
        public int Department_ID { get; set; }

        [ForeignKey("Department_ID")]
        public virtual Department Department { get; set; }
    }
}
