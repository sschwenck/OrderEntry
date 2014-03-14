using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderEntry.Controllers
{
   public class HomeController : Controller
   {
      public ActionResult Index()
      {
         if (Request.IsAuthenticated)
         {
            return Redirect("/Order/Index");     
         }
         else
         {

            return Redirect("/Account/Login");
         }
      }

      public ActionResult About()
      {
         ViewBag.Message = "About Order Entry";

         return View();
      }
   }
}