using System.ComponentModel.DataAnnotations;

namespace OrderEntry.Models
{
   public class TenderViewModel
   {
      [Display(Name = "Order")]
      public OrderViewModel Order { get; set; }

      [Required]
      [Display(Name = "TenderAmount")]
      public decimal TenderAmount { get; set; }
   }
}