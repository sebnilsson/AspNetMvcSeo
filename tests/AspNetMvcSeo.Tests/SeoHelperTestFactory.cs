using System.Web.Mvc;

namespace AspNetMvcSeo.Tests
{
    internal static class SeoHelperTestFactory
    {
        public static SeoHelper Create(ViewContext viewContext = null)
        {
            viewContext = viewContext ?? ViewContextTestFactory.Create();

            var seo = viewContext.ViewData.GetSeoHelper();
            return seo;
        }
    }
}