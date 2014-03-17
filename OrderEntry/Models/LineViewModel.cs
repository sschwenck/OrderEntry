using System.ComponentModel.DataAnnotations;

namespace OrderEntry.Models
{
   public class LineViewModel
   {
      [Display(Name = "Order")]
      public OrderViewModel Order { get; set; }

      [Required]
      [Display(Name = "Product")]
      public string Product { get; set; }

      [Required]
      [Display(Name = "Quantity")]
      public int Quantity { get; set; }

      [Display(Name = "Price")]
      public decimal Price { get; set; }

   }
}