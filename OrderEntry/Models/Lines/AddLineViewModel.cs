using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderEntry.Models.Lines
{
   public class AddLineViewModel
   {
      public Order CurrentOrder { get; set; }

      public Line CurrentLine { get; set; }
   }
}