namespace AspNetMvcSeo.Tests
{
    internal static class TestData
    {
        public static readonly string TestDefaultSiteTitle = $"Test{nameof(SeoHelper.DefaultSiteTitle)}";

        public static readonly string TestLinkCanonical = $"/Test/{nameof(SeoHelper.LinkCanonical)}.html";

        public static readonly string TestMetaDescription = $"Test{nameof(SeoHelper.MetaDescription)}";

        public static readonly string TestMetaKeywords = $"Test{nameof(SeoHelper.MetaKeywords)}";

        public static readonly string TestPageTitle = $"Test{nameof(SeoHelper.PageTitle)}";

        public static readonly string TestSiteTitle = $"Test{nameof(SeoHelper.SiteTitle)}";
    }
}