using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AspNetMvcSeo.Tests
{
    public static class ControllerFactoryUtility
    {
        private const string ControllerSuffix = "Controller";

        public static IController CreateController(string controllerName, string action, string url = "http://test.com")
        {
            controllerName = GetTrimmedControllerName(controllerName);

            var controllerBuilder = new ControllerBuilder();
            var controllerFactory = controllerBuilder.GetControllerFactory();

            var routeData = new RouteData();
            routeData.Values["controller"] = controllerName;
            routeData.Values["action"] = action;

            var requestContext = GetRequestContext(routeData, url);

            var controller = controllerFactory.CreateController(requestContext, controllerName);
            return controller;
        }

        public static HttpContextWrapper GetHttpContext(string url = "http://test.com")
        {
            var request = new HttpRequest(string.Empty, url, null);
            var response = new HttpResponse(System.IO.TextWriter.Null);

            var httpContext = new HttpContext(request, response);
            var httpContextBase = new HttpContextWrapper(httpContext);

            return httpContextBase;
        }

        private static RequestContext GetRequestContext(RouteData routeData, string url)
        {
            var httpContext = GetHttpContext(url);

            var requestContext = new RequestContext(httpContext, routeData);
            return requestContext;
        }

        private static string GetTrimmedControllerName(string controllerName)
        {
            if (!controllerName.EndsWith(ControllerSuffix, StringComparison.InvariantCultureIgnoreCase))
            {
                return controllerName;
            }

            string trimmedControllerName = controllerName.Substring(0, controllerName.Length - ControllerSuffix.Length);
            return trimmedControllerName;
        }
    }
}