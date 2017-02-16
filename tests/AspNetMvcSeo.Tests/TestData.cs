namespace AspNetMvcSeo.Tests
{
    internal static class TestData
    {
        public static readonly string TestBaseTitle = $"Test{nameof(SeoHelper.BaseTitle)}";

        public static readonly string TestAppRelativeLinkCanonical = $"~/Test/{nameof(SeoHelper.LinkCanonical)}.html";

        public static readonly string TestLinkCanonical = $"/Test/{nameof(SeoHelper.LinkCanonical)}.html";

        public static readonly string TestMetaDescription = $"Test{nameof(SeoHelper.MetaDescription)}";

        public static readonly string TestMetaKeywords = $"Test{nameof(SeoHelper.MetaKeywords)}";

        public static readonly string TestTitle = $"Test{nameof(SeoHelper.Title)}";

        public static readonly string TestTitleFormat = "{1} > {0}";
    }
}