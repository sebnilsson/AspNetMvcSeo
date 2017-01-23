using System;
using System.Web.Routing;

namespace AspNetMvcSeo
{
    public static class RequestContextExtensions
    {
        public static SeoHelper GetSeoHelper(this RequestContext requestContext)
        {
            if (requestContext == null)
            {
                throw new ArgumentNullException(nameof(requestContext));
            }
            if (requestContext.HttpContext == null)
            {
                string message = $"{nameof(requestContext.HttpContext)} in {nameof(RequestContext)} cannot be null.";
                throw new ArgumentOutOfRangeException(nameof(requestContext), message);
            }

            var seoHelper = new SeoHelper(requestContext.HttpContext);
            return seoHelper;
        }
    }
}