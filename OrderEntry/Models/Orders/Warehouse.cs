using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrderEntry.Models
{
   public class Warehouse
   {
      public int WarehouseID { get; set; }

      [Required]
      [Display(Name = "Warehouse Number")]
      public int WarehouseNumber { get; set; }

      [Required]
      [Display(Name = "Warehouse Name")]
      public string WarehouseName { get; set; }

      [Display(Name = "Address")]
      public Address Address { get; set; }
   }
}