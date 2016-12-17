using Xunit;

namespace AspNetMvcSeo.Tests
{
    public class SeoMetaDescriptionAttributeTest
    {
        [Fact]
        public void OnHandleSeoValues_TestMetaDescription_SetsMetaDescription()
        {
            // Arrange
            var attribute = new SeoMetaDescriptionAttribute(TestData.TestMetaDescription);

            var seo = SeoHelperTestFactory.Create();

            // Act
            attribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Equal(TestData.TestMetaDescription, seo.MetaDescription);
        }

        [Fact]
        public void OnHandleSeoValues_TestMetaDescription_SetsMetaDescriptionOnly()
        {
            // Arrange
            var attribute = new SeoMetaDescriptionAttribute(TestData.TestMetaDescription);

            var seo = SeoHelperTestFactory.Create();

            // Act
            attribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Null(seo.LinkCanonical);
            Assert.Null(seo.MetaKeywords);
            Assert.Null(seo.MetaRobotsIndex);
            Assert.Null(seo.Title);
        }
    }
}