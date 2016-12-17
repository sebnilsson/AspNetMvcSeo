namespace AspNetMvcSeo.Tests
{
    internal static class TestData
    {
        public static readonly string TestSiteTitle = $"TestSite{nameof(SeoHelper.Title)}";

        public static readonly string TestLinkCanonical = $"/Test/{nameof(SeoHelper.LinkCanonical)}.html";

        public static readonly string TestMetaDescription = $"Test{nameof(SeoHelper.MetaDescription)}";

        public static readonly string TestMetaKeywords = $"Test{nameof(SeoHelper.MetaKeywords)}";

        public static readonly string TestPageTitle = $"TestPage{nameof(SeoHelper.Title)}";
    }
}