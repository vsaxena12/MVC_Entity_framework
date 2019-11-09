using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AssessmentSample.Models
{
    public class Employee
    {
        [Key]
        public int EmpID { get; set; }
        [Required]
        public string EmpName { get; set; }
        [Required]
        public string Designation { get; set; }
        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }
    }
}
