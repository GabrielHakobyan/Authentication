using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Utils
{
    public class AuthorizationFilter : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            bool exist_auth = false;
            if (context.HttpContext.Session.GetString("testycooki") != null)
            {
                exist_auth = true;
            }
            else
            {
                if (context.HttpContext.Request.Cookies.ContainsKey("testycooki"))
                {
                    var cookie = context.HttpContext.Request.Cookies["testycooki"] ?? string.Empty;
                    context.HttpContext.Session.SetString("testycooki", cookie);
                    exist_auth = true;
                }
            }
            if (!exist_auth)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "Home", action = "Login" }));
            }
            else
                await next();
        }

    }
}
