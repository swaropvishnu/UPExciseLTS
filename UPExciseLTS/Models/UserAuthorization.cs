using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace UPExciseLTS.Models
{
    public class MyActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string str1 = "0";
            if (UserSession.LoggedInName=="ocpupaur")
            {
                string str = "0";
            }
            else
            { 
                HttpContext.Current.Response.Redirect("/Default/Entry", false);
            }

            // TODO: do something with the foo cookie
        }
    }
    
}