using Xunit;

namespace AspNetMvcSeo.Tests
{
    public class SeoMetaKeywordsAttributeTest
    {
        [Fact]
        public void SetSeoValues_TestMetaKeywords_SetsMetaKeywords()
        {
            // Arrange
            var attribute = new SeoMetaKeywordsAttribute(TestData.TestMetaKeywords);

            var seo = SeoHelperTestUtility.Get();

            // Act
            attribute.SetSeoValues(seo);

            // Assert
            Assert.Equal(TestData.TestMetaKeywords, seo.MetaKeywords);
        }

        [Fact]
        public void SetSeoValues_TestMetaKeywords_SetsMetaKeywordsOnly()
        {
            // Arrange
            var attribute = new SeoMetaKeywordsAttribute(TestData.TestMetaKeywords);

            var seo = SeoHelperTestUtility.Get();

            // Act
            attribute.SetSeoValues(seo);

            // Assert
            Assert.Null(seo.CanonicalLink);
            Assert.Null(seo.MetaDescription);
            Assert.Null(seo.MetaNoIndex);
            Assert.Null(seo.PageTitle);
            Assert.Null(seo.SiteTitle);
        }
    }
}