using System.Collections.Generic;

namespace AspNetMvcSeo.Tests
{
    internal static class SeoHelperTestUtility
    {
        public static SeoHelper Get(string baseTitle = null)
        {
            var seoData = new Dictionary<object, object>();

            var seo = new SeoHelper(seoData, baseTitle);
            return seo;
        }
    }
}