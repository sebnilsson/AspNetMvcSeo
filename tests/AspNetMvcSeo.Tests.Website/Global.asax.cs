using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AspNetMvcSeo.Tests.Website
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            SeoHelper.DefaultSiteTitle = "ASP.NET MVC SEO Test-Website";
        }
    }
}