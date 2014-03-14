using OrderEntry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OrderEntry.Controllers
{
    public class OrderController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

       [AllowAnonymous]
        public ActionResult Create(string returnUrl)
        {
           ViewBag.ReturnUrl = returnUrl;
           return View();
        }

       [HttpPost]
       [AllowAnonymous]
       [ValidateAntiForgeryToken]
       public async Task<ActionResult> Create(OrderViewModel model, string returnUrl)
       {
          if (ModelState.IsValid)
          {
             return Redirect("/Order/Index");
          }

          // If we got this far, something failed, redisplay form
          return View(model);
       }
	}
}