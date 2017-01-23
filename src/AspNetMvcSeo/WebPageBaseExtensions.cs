using System;
using System.Web.WebPages;

namespace AspNetMvcSeo
{
    public static class WebPageBaseExtensions
    {
        public static SeoHelper GetSeoHelper(this WebPageBase webPage)
        {
            if (webPage == null)
            {
                throw new ArgumentNullException(nameof(webPage));
            }

            var seoHelper = new SeoHelper(webPage.Context);
            return seoHelper;
        }
    }
}