namespace AspNetMvcSeo.Tests
{
    internal static class SeoHelperTestUtility
    {
        public static SeoHelper Get(string baseTitle = null)
        {
            var requestContext = RequestContextTestUtility.Get();

            var seo = new SeoHelper(requestContext, baseTitle);
            return seo;
        }
    }
}