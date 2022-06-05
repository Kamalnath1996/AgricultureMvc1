using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BoutoCustomer.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string defaultpage = Request.Url.AbsolutePath;
            if (defaultpage != "/" && defaultpage != "/Home/Index")
            {
                if (filterContext.HttpContext.Session["UserId"] == null)
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(
                        new
                        {
                            controller = "Home",
                            action = "Login"
                        })
                    );
                }
            }
        }       
    }
}