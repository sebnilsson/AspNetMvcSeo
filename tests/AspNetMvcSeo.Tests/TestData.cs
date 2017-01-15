namespace AspNetMvcSeo.Tests
{
    internal static class TestData
    {
        public static readonly string TestLinkCanonical = $"/Test/{nameof(SeoHelper.LinkCanonical)}.html";

        public static readonly string TestMetaDescription = $"Test{nameof(SeoHelper.MetaDescription)}";

        public static readonly string TestMetaKeywords = $"Test{nameof(SeoHelper.MetaKeywords)}";

        public static readonly string TestPageTitle = $"Test{nameof(SeoHelper.PageTitle)}";

        public static readonly string TestSectionTitle = $"Test{nameof(SeoHelper.SectionTitle)}";

        public static readonly string TestTitleFormat = "{1} > {0}";
    }
}