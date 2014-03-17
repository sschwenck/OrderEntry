using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderEntry.Controllers
{
    public class BaseController : Controller
    {
       public const string loginScreen = "/Account/Login";

       //public RedirectResult IsUserAuthenticated(string authRedirect)
       //{
       //   if (Request.IsAuthenticated)
       //   {
       //      return Redirect(authRedirect);
       //   }
       //   else
       //   {
       //      return Redirect(loginScreen);
       //   }
       //}
	}
}