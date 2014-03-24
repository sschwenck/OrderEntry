using System;
using System.ComponentModel.DataAnnotations;

namespace OrderEntry.Models
{
   public class TenderViewModel
   {
      [Display(Name = "Order")]
      public OrderViewModel Order { get; set; }

      [Required]
      [Display(Name = "Tender Type")]
      public string TenderType { get; set; }
      
      [Required]
      [Display(Name = "Tender Amount")]
      public decimal TenderAmount { get; set; }

      [Display(Name = "CreditCard")]
      public CreditCardModel CreditCard { get; set; }

      [Display(Name = "Check")]
      public CheckModel Check { get; set; }
   }

   public class CreditCardModel
   {
      [Display(Name = "Name On Card")]
      public string Name { get; set; }

      [Display(Name = "Card Type")]
      public string CardType { get; set; }

      [Display(Name = "Card Number")]
      public int CardNo { get; set; }

      [Display(Name = "Experation Date")]
      public DateTime ExpDate { get; set; }

      [Display(Name = "Security Code")]
      public int CvcCode { get; set; }
   }

   public class CheckModel
   {
      [Display(Name = "BankNo")]
      public int BankNo { get; set; }

      [Display(Name = "AccountNo")]
      public int AccountNo { get; set; }

      [Display(Name = "CheckNo")]
      public int CheckNo { get; set; }
   }
}