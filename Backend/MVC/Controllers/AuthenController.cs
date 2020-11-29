using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.CommonModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace MVC.Controllers
{
    public class AuthenController : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                context.ExceptionHandled = true;
                context.Result = new RedirectToRouteResult
                   (
                   new RouteValueDictionary(new
                   {
                       action = "Error",
                       controller = "Cadidate"
                   }));
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string user = Convert.ToString(context.HttpContext.Session.GetString(Common.CommonSession.USER_SESSION));

            if (!string.IsNullOrEmpty(user))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    action = "Error",
                    controller = "Cadidate"
                }));
            }
        }
    }
}
