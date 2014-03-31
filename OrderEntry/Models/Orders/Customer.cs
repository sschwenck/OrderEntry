using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrderEntry.Models
{
   public class Customer
   {
      public int CustomerID { get; set; }

      [Required]
      [Display(Name = "Customer Number")]
      public int CustomerNumber { get; set; }

      [Required]
      [Display(Name = "Customer Name")]
      public string CustomerName { get; set; }

      [Display(Name = "Address")]
      public Address Address { get; set; }
   }
}