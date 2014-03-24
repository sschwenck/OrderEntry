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
      [Display(Name = "Order Type")]
      public string OrderType { get; set; }

      [Required]
      [Display(Name = "Warehouse")]
      public WarehouseModel Warehouse { get; set; }

      [Required]
      [Display(Name = "Customer")]
      public CustomerModel Customer { get; set; }

      [Display(Name = "Customer PO")]
      public string CustomerPO { get; set; }

      [Display(Name = "Taken By")]
      public string TakenBy { get; set; }

      [Display(Name = "Ship To")]
      public ShipToModel ShipTo { get; set; }

      [Display(Name = "Taxable")]
      public bool Taxable { get; set; }

      [Display(Name = "Number of Lines")]
      public int Lines { get; set; }

      [Display(Name = "Order Total")]
      public decimal OrderTotal { get; set; }

      [Display(Name = "Tendered Amount")]
      public decimal TenderedAmount { get; set; }
   }

   public class CustomerModel
   {
      [Required]
      [Display(Name = "Customer")]
      public int Customer { get; set; }

      [Display(Name = "Address")]
      public AddressModel Address { get; set; }
   }

   public class WarehouseModel
   {
      [Required]
      [Display(Name = "Warehouse")]
      public int Warehouse { get; set; }

      [Display(Name = "Address")]
      public AddressModel Address { get; set; }
   }

   public class ShipToModel
   {
      [Required]
      [Display(Name = "Ship To Number")]
      public int ShipToNo { get; set; }

      [Display(Name = "Address")]
      public AddressModel Address { get; set; }
   }

   public class AddressModel
   {
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