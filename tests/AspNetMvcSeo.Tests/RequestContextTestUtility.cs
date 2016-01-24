using System.Collections.Generic;
using System.Web;
using System.Web.Routing;

using Moq;

namespace AspNetMvcSeo.Tests
{
    public static class RequestContextTestUtility
    {
        public static RequestContext Get()
        {
            var items = new Dictionary<object, object>();

            var httpContext = new Mock<HttpContextBase>();
            httpContext.Setup(x => x.Items).Returns(items);

            var routeData = new RouteData();

            var requestContext = new RequestContext(httpContext.Object, routeData);
            return requestContext;
        }
    }
}