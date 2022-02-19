using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductMvc.Models
{
    public class Product
    {
        internal int ProductId;
        internal object ProductName;
        internal object Category;

        public int Id { get; set; }
         [Required(ErrorMessage ="Enter your name")]
         [DataType(DataType.Text)]
         [MaxLength(50, ErrorMessage = "Name not greater than 50 character")]
         public String name { get; set; }
         public String Description { get; set; }
        public String CategoryName { get; set; }
        [Required(ErrorMessage = "this canot empty")]
         [DataType(DataType.Text)]
         public Decimal Rate { get; set; }
    }
}