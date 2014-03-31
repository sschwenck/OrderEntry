using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrderEntry.Models.Tendering
{
   public class Check
   {
      public int CheckID { get; set; }

      [Required]
      [Display(Name = "BankNo")]
      public int BankNo { get; set; }

      [Required]
      [Display(Name = "AccountNo")]
      public int AccountNo { get; set; }

      [Required]
      [Display(Name = "CheckNo")]
      public int CheckNo { get; set; }
   }
}