using System.Web.Routing;

namespace AspNetMvcSeo.Tests
{
    internal static class SeoHelperTestFactory
    {
        public static SeoHelper Create(RequestContext requestContext = null)
        {
            requestContext = requestContext ?? RequestContextTestFactory.Create();

            var seo = new SeoHelper(requestContext);
            return seo;
        }
    }
}