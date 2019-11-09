using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCsampleProject.Models
{
    public class Department
    {
        [Key]
        [Required]
        public int Department_ID { get; set; }
        [Required]
        public string DepartmentName { get; set; }
    }
}
