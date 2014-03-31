using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderEntry.Models.Orders
{
   public class DetailsViewModel
   {
      public Line LineForDisplay { get; set; }

      public Order CurrentOrder { get; set; }
   }
}