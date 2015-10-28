using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;

namespace ScribemaniaAPI.Filters
{
    /// <summary>
    /// Converts <c>null</c> return values into an HTTP 404 return code.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class NullNotFound : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var response = actionExecutedContext.Response;

            if (response != null && response.IsSuccessStatusCode && response.StatusCode != HttpStatusCode.NoContent)
            {
                var objectContent = response.Content as ObjectContent;
                if (objectContent == null || objectContent.Value == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
            }
        }
    }
}