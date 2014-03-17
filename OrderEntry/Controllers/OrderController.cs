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
       public const string loginScreen = "/Account/Login";

        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
               return View();
            }
            else
            {
               return Redirect(loginScreen);
            }
        }

       [AllowAnonymous]
        public ActionResult Create(string returnUrl)
        {
           ViewBag.ReturnUrl = returnUrl;
          if (Request.IsAuthenticated)
          {
             return View();
          }
          else
          {
             return Redirect(loginScreen);
          }
        }

       [HttpPost]
       [AllowAnonymous]
       [ValidateAntiForgeryToken]
       public async Task<ActionResult> Create(OrderViewModel model, string returnUrl)
       {
          if (Request.IsAuthenticated)
          {
             if (ModelState.IsValid)
             {
                return Redirect("/Order/AddLine");
             }
             // If we got this far, something failed, redisplay form
             return View(model);
          }
          else
          {
             return Redirect(loginScreen);
          }
       }

       [AllowAnonymous]
       public ActionResult AddLine(string returnUrl)
       {
          ViewBag.ReturnUrl = returnUrl;
          if (Request.IsAuthenticated)
          {
             return View();
          }
          else
          {
             return Redirect(loginScreen);
          }
       }

       [HttpPost]
       [AllowAnonymous]
       [ValidateAntiForgeryToken]
       public async Task<ActionResult> AddLine(LineViewModel model, string returnUrl)
       {
          if (Request.IsAuthenticated)
          {
             if (ModelState.IsValid)
             {
                return View();
             }
             // If we got this far, something failed, redisplay form
             return View(model);
          }
          else
          {
             return Redirect(loginScreen);
          }
       }

       [AllowAnonymous]
       public ActionResult Tender(string returnUrl)
       {
          ViewBag.ReturnUrl = returnUrl;
          if (Request.IsAuthenticated)
          {
             return View();
          }
          else
          {
             return Redirect(loginScreen);
          }
       }

       [HttpPost]
       [AllowAnonymous]
       [ValidateAntiForgeryToken]
       public async Task<ActionResult> Tender(LineViewModel model, string returnUrl)
       {
          if (Request.IsAuthenticated)
          {
             if (ModelState.IsValid)
             {
                return View();
             }
             // If we got this far, something failed, redisplay form
             return View(model);
          }
          else
          {
             return Redirect(loginScreen);
          }
       }
	}
}