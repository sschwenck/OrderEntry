using System.ComponentModel.DataAnnotations;

namespace OrderEntry.Models
{
   public class LineViewModel
   {
      [Display(Name = "Order")]
      public OrderViewModel Order { get; set; }

      [Required]
      [Display(Name = "Line Number")]
      public int LineNo { get; set; }

      [Required]
      [Display(Name = "Product")]
      public string Product { get; set; }

      [Required]
      [Display(Name = "Description")]
      public string Description { get; set; }

      [Required]
      [Display(Name = "Quantity Ordered")]
      public int QtyOrd { get; set; }

      [Display(Name = "Quantity Shipped")]
      public int QtyShip { get; set; }

      [Display(Name = "Price")]
      public decimal Price { get; set; }

      [Display(Name = "Discount")]
      public decimal Discount { get; set; }

      [Display(Name = "Net Amount")]
      public decimal NetAmt { get; set; }

      [Display(Name = "Margin Amount")]
      public decimal MarginAmt { get; set; }

      [Display(Name = "Margin Percent")]
      public decimal MarginPct { get; set; }

      [Display(Name = "Net Available")]
      public int NetAvail { get; set; }

      [Display(Name = "Unit")]
      public string Unit { get; set; }
   }
}