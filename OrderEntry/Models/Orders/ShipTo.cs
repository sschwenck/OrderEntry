using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrderEntry.Models
{
   public class ShipTo
   {
      public int ShipToID { get; set; }

      [Required]
      [Display(Name = "Ship To Number")]
      public int ShipToNo { get; set; }

      [Required]
      [Display(Name = "Ship To Name")]
      public string ShipToName { get; set; }

      [Display(Name = "Address")]
      public Address Address { get; set; }
   }
}