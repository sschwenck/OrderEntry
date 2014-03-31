using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrderEntry.Models.Tendering
{
   public class CreditCard
   {
      public int CreditCardID { get; set; }

      [Required]
      [Display(Name = "Name On Card")]
      public string Name { get; set; }

      [Required]
      [Display(Name = "Card Type")]
      public string CardType { get; set; }

      [Required]
      [Display(Name = "Card Number")]
      public int CardNo { get; set; }

      [Required]
      [Display(Name = "Experation Date")]
      public DateTime ExpDate { get; set; }

      [Required]
      [Display(Name = "Security Code")]
      public int CvcCode { get; set; }
   }
}