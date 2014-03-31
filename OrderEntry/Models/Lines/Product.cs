using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrderEntry.Models
{
   public class Product
   {
      public int ProductID { get; set; }

      [Required]
      [Display(Name = "Product")]
      public string ProductNumber { get; set; }

      [Display(Name = "Description")]
      public string Description { get; set; }

      [Display(Name = "Price")]
      public decimal Price { get; set; }

      [Display(Name = "Unit")]
      public string Unit { get; set; }

      [Display(Name = "Net Available")]
      public string NetAvailable { get; set; }
   }
}