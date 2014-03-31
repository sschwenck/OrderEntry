using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderEntry.Models.Orders
{
   public class MaintainViewModel
   {
      public IEnumerable<Order> Orders { get; set; }

      public Order SearchOrderCriteria { get; set; }
   }
}