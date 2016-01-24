using Xunit;

namespace AspNetMvcSeo.Tests
{
    public class SeoMetaDescriptionAttributeTest
    {
        [Fact]
        public void SetSeoValues_TestMetaDescription_SetsMetaDescription()
        {
            // Arrange
            var attribute = new SeoMetaDescriptionAttribute(TestData.TestMetaDescription);

            var seo = SeoHelperTestUtility.Get();

            // Act
            attribute.SetSeoValues(seo);

            // Assert
            Assert.Equal(TestData.TestMetaDescription, seo.MetaDescription);
        }

        [Fact]
        public void SetSeoValues_TestMetaDescription_SetsMetaDescriptionOnly()
        {
            // Arrange
            var attribute = new SeoMetaDescriptionAttribute(TestData.TestPageTitle);

            var seo = SeoHelperTestUtility.Get();

            // Act
            attribute.SetSeoValues(seo);

            // Assert
            Assert.Null(seo.LinkCanonical);
            Assert.Null(seo.MetaKeywords);
            Assert.Null(seo.MetaRobotsIndex);
            Assert.Null(seo.PageTitle);
            Assert.Null(seo.SiteTitle);
        }
    }
}