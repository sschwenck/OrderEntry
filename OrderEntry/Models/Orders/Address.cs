using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrderEntry.Models
{
   public class Address
   {
      public int AddressID { get; set; }

      [Required]
      [Display(Name = "Address Line 1")]
      public string AddressLine1 { get; set; }

      [Display(Name = "Address Line 2")]
      public string AddressLine2 { get; set; }

      [Required]
      [Display(Name = "City")]
      public string City { get; set; }

      [Required]
      [Display(Name = "State")]
      public string State { get; set; }

      [Required]
      [Display(Name = "Zip Code")]
      public int ZipCode { get; set; }

      [Required]
      [Display(Name = "Country")]
      public string Country { get; set; }
   }
}