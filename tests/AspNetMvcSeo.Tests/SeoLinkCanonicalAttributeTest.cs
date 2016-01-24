using Xunit;

namespace AspNetMvcSeo.Tests
{
    public class SeoLinkCanonicalAttributeTest
    {
        [Fact]
        public void SetSeoValues_TestLinkCanonical_SetsSeoHelperCanonicalLink()
        {
            // Arrange
            var attribute = new SeoLinkCanonicalAttribute(TestData.TestLinkCanonical);

            var seo = SeoHelperTestUtility.Get();

            // Act
            attribute.SetSeoValues(seo);

            // Assert
            Assert.Equal(TestData.TestLinkCanonical, seo.LinkCanonical);
        }

        [Fact]
        public void SetSeoValues_TestLinkCanonical_SetsSeoHelperCanonicalLinkOnly()
        {
            // Arrange
            var attribute = new SeoLinkCanonicalAttribute(TestData.TestPageTitle);

            var seo = SeoHelperTestUtility.Get();

            // Act
            attribute.SetSeoValues(seo);

            // Assert
            Assert.Null(seo.MetaDescription);
            Assert.Null(seo.MetaKeywords);
            Assert.Null(seo.MetaRobotsIndex);
            Assert.Null(seo.PageTitle);
            Assert.Null(seo.SiteTitle);
        }
    }
}