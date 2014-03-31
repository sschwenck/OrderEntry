using OrderEntry.Models.Tendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace OrderEntry.Models
{
   public class Tender
   {
      public int TenderID { get; set; }

      [Required]
      [Display(Name = "Order")]
      public Order Order { get; set; }

      [Required]
      [Display(Name = "Tender Type")]
      public string TenderType { get; set; }
      
      [Required]
      [Display(Name = "Tender Amount")]
      public decimal TenderAmount { get; set; }

      [Display(Name = "CreditCard")]
      public CreditCard CreditCard { get; set; }

      [Display(Name = "Check")]
      public Check Check { get; set; }
   }
}