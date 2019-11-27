using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PharmaApp.Web.Controllers
{
    public class BaseController : ActionFilterAttribute
    {
        // GET: Admin/Base
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = filterContext.HttpContext.Session["EmployeeEmail"];
            if (user == null)
                filterContext.Result = new RedirectResult(string.Format("/Home/Login"));
        }
    }

    
}