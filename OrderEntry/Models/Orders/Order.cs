using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace OrderEntry.Models
{
   public class Order
   {
      public int OrderID { get; set; }

      [Required]
      [Display(Name = "Order Number")]
      public int OrderNumber { get; set; }

      [Required]
      [Display(Name = "Order Suffix")]
      public int OrderSuffix { get; set; }

      [Required]
      [Display(Name = "Order Type")]
      public string OrderType { get; set; }

      public IEnumerable<SelectListItem> OrderTypes 
      {
         get 
         {
            var orderTypes = new List<SelectListItem>();
            orderTypes.Add(new SelectListItem { Text = "Stock Order", Value = "so", Selected = true });
            orderTypes.Add(new SelectListItem { Text = "Quote", Value = "qu" });
            orderTypes.Add(new SelectListItem { Text = "Back Order", Value = "bo" });
            return orderTypes;
         } 
         set
         {
            OrderTypes = value;
         }
      }

      [Required]
      [Display(Name = "Warehouse")]
      public int WarehouseNumber { get; set; }

      [Required]
      [Display(Name = "Customer")]
      public int CustomerNumber { get; set; }

      [Display(Name = "Customer PO")]
      public string CustomerPO { get; set; }

      [Display(Name = "Taken By")]
      public string TakenBy { get; set; }

      [Display(Name = "Ship To")]
      public int ShipToNumber { get; set; }

      [Display(Name = "Taxable")]
      public bool Taxable { get; set; }

      [Display(Name = "Number of Lines")]
      public int NumberOfLines { get; set; }

      [Display(Name = "Lines")]
      public IEnumerable<Line> Lines { get; set; }

      [Display(Name = "Order Total")]
      public decimal OrderTotal { get; set; }

      [Display(Name = "Tendered Amount")]
      public decimal TenderedAmount { get; set; }
   }
}