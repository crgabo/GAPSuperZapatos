using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;

namespace GAPSZ.WebAPI.Helpers
{

    public class WebAPIErrorsHandlerAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Response.StatusCode != HttpStatusCode.OK)
            {
                WebAPIErrorResult error = new WebAPIErrorResult(actionExecutedContext.Response.StatusCode, actionExecutedContext.Response.ReasonPhrase, actionExecutedContext.Request);
                actionExecutedContext.Response = error.ExecuteSync();
            }
            else
            {
                base.OnActionExecuted(actionExecutedContext);
            }
        }
    }

}