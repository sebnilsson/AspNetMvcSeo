using Xunit;

namespace AspNetMvcSeo.Tests
{
    public class SeoTitleAttributeTest
    {
        [Fact]
        public void SetSeoValues_TestPageTitle_SetsPageTitle()
        {
            // Arrange
            var attribute = new SeoTitleAttribute(TestData.TestPageTitle);

            var seo = SeoHelperTestUtility.Get();

            // Act
            attribute.SetSeoValues(seo);

            // Assert
            Assert.Equal(TestData.TestPageTitle, seo.PageTitle);
        }

        [Fact]
        public void SetSeoValues_TestPageTitle_SetsPageTitleOnly()
        {
            // Arrange
            var attribute = new SeoTitleAttribute(TestData.TestPageTitle);

            var seo = SeoHelperTestUtility.Get();

            // Act
            attribute.SetSeoValues(seo);

            // Assert
            Assert.Null(seo.CanonicalLink);
            Assert.Null(seo.MetaDescription);
            Assert.Null(seo.MetaKeywords);
            Assert.Null(seo.MetaNoIndex);
            Assert.Null(seo.SiteTitle);
        }
    }
}