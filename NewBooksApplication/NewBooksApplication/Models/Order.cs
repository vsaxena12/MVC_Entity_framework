using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewBooksApplication.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string Address { get; set; }

        [Required]
        
        public string PhoneNumber { get; set; }

        [ForeignKey("ProductID")]
        public int ProductID { get; set; }

        [Required]
        public int OrderQuantity { get; set; }

        public virtual int FinalPrice { get; set; }

       
        public virtual Product Product { get; set; }
    }
}
