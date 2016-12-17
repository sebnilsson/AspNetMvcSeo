using Xunit;

namespace AspNetMvcSeo.Tests
{
    public class SeoLinkCanonicalAttributeTest
    {
        [Fact]
        public void OnHandleSeoValues_TestLinkCanonical_SetsSeoHelperCanonicalLink()
        {
            // Arrange
            var attribute = new SeoLinkCanonicalAttribute(TestData.TestLinkCanonical);

            var seo = SeoHelperTestFactory.Create();

            // Act
            attribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Equal(TestData.TestLinkCanonical, seo.LinkCanonical);
        }

        [Fact]
        public void OnHandleSeoValues_TestLinkCanonical_SetsSeoHelperCanonicalLinkOnly()
        {
            // Arrange
            var attribute = new SeoLinkCanonicalAttribute(TestData.TestPageTitle);

            var seo = SeoHelperTestFactory.Create();

            // Act
            attribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Null(seo.MetaDescription);
            Assert.Null(seo.MetaKeywords);
            Assert.Null(seo.MetaRobotsIndex);
            Assert.Null(seo.Title);
        }
    }
}