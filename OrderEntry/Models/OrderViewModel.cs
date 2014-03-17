using System.ComponentModel.DataAnnotations;

namespace OrderEntry.Models
{
   public class OrderViewModel
   {
      [Required]
      [Display(Name = "OrderNumber")]
      public int OrderNumber { get; set; }

      [Required]
      [Display(Name = "OrderSuffix")]
      public int OrderSuffix { get; set; }

      [Required]
      //TODO: make this be in xxx-xx format
      //[RegularExpression()]
      [Display(Name = "Order Type")]
      public string OrderType { get; set; }

      [Required]
      [Display(Name = "Warehouse")]
      public int Warehouse { get; set; }

      [Required]
      [Display(Name = "Customer")]
      public int Customer { get; set; }

      [Display(Name = "Customer PO")]
      public string CustomerPO { get; set; }

      [Display(Name = "Taken By")]
      public string TakenBy { get; set; }

      [Display(Name = "Ship To")]
      public int ShipTo { get; set; }
   }
}