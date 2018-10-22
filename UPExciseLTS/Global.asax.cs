using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using UPExciseLTS.Controllers;

namespace UPExciseLTS
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            Application["Title"] = "Up Excise";

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Application_Error(object sender, EventArgs e)
        {
            try
            {
                //Code that runs when an unhandled error occurs
                //Exception ex = default(Exception);

                //ex = Server.GetLastError().InnerException;
                //if (ex != null)
                //{ 
                //    ex = Server.GetLastError().InnerException;
                //    CMODataEntryBLL.InsertErrLog(Request.Url.ToString(), ex.ToString());
                //    //HttpContext.Current.Response.Redirect("~/ErrorPageS.aspx",false);
                //    //HttpContext.Current.Response.Redirect("~/ErrorPageS.aspx", false);
                //}
                //Server.ClearError();
                HttpContext httpContext = HttpContext.Current;
                if (httpContext != null)
                {
                    RequestContext requestContext = ((MvcHandler)httpContext.CurrentHandler).RequestContext;
                    /* When the request is ajax the system can automatically handle a mistake with a JSON response. 
                       Then overwrites the default response */
                    if (requestContext.HttpContext.Request.IsAjaxRequest())
                    {
                        httpContext.Response.Clear();
                        string controllerName = requestContext.RouteData.GetRequiredString("controller");
                        IControllerFactory factory = ControllerBuilder.Current.GetControllerFactory();
                        IController controller = factory.CreateController(requestContext, controllerName);
                        ControllerContext controllerContext = new ControllerContext(requestContext, (ControllerBase)controller);

                        JsonResult jsonResult = new JsonResult
                        {
                            Data = new { success = false, serverError = "500" },
                            JsonRequestBehavior = JsonRequestBehavior.AllowGet
                        };
                        jsonResult.ExecuteResult(controllerContext);
                        httpContext.Response.End();
                    }
                    else
                    {
                        //Code that runs when an unhandled error occurs
                        //Exception ex = default(Exception);

                        //ex = Server.GetLastError().InnerException;
                        //if (ex != null)
                        //{
                        string ex = httpContext.Error.Message;
                        CMODataEntryBLL.InsertErrLog(Request.Url.ToString(), ex);
                        //}
                        Response.Clear();
                        Server.ClearError();

                        var routeData = new RouteData();
                        routeData.Values["controller"] = "Login";
                        routeData.Values["action"] = "Error";
                        Response.StatusCode = 500;

                        IController controller = new LoginController();
                        var rc = new RequestContext(new HttpContextWrapper(Context), routeData);
                        controller.Execute(rc);
                    }
                }
            }
            catch { }
        }

        protected void Session_Start(Object sender, EventArgs e)
        {
            Session["startValue"] = 0;
        }
    }
}