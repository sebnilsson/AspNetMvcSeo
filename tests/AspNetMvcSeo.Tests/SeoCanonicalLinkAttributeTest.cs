using Xunit;

namespace AspNetMvcSeo.Tests
{
    public class SeoCanonicalLinkAttributeTest
    {
        [Fact]
        public void SetSeoValues_TestCanonicalLink_SetsSeoHelperCanonicalLink()
        {
            // Arrange
            var attribute = new SeoCanonicalLinkAttribute(TestData.TestCanonicalLink);

            var seo = SeoHelperTestUtility.Get();

            // Act
            attribute.SetSeoValues(seo);

            // Assert
            Assert.Equal(TestData.TestCanonicalLink, seo.CanonicalLink);
        }

        [Fact]
        public void SetSeoValues_TestCanonicalLink_SetsSeoHelperCanonicalLinkOnly()
        {
            // Arrange
            var attribute = new SeoCanonicalLinkAttribute(TestData.TestPageTitle);

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