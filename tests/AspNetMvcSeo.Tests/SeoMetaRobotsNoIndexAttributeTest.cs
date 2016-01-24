using Xunit;

namespace AspNetMvcSeo.Tests
{
    public class SeoMetaRobotsNoIndexAttributeTest
    {
        [Fact]
        public void SetSeoValues_NoIndexValue_MetaNoIndex()
        {
            // Arrange
            var attribute = new SeoMetaRobotsNoIndexAttribute();

            var seo = SeoHelperTestUtility.Get();

            // Act
            attribute.SetSeoValues(seo);

            // Assert
            Assert.True(seo.MetaRobotsNoIndex);
            Assert.Equal(RobotsIndexManager.DefaultRobotsNoIndex, seo.MetaRobotsIndex);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void SetSeoValues_NoIndexValue_MetaNoIndexOnly(bool noIndex)
        {
            // Arrange
            var attribute = new SeoMetaRobotsNoIndexAttribute();

            var seo = SeoHelperTestUtility.Get();

            // Act
            attribute.SetSeoValues(seo);

            // Assert
            Assert.Null(seo.LinkCanonical);
            Assert.Null(seo.MetaDescription);
            Assert.Null(seo.MetaKeywords);
            Assert.Null(seo.PageTitle);
            Assert.Null(seo.SiteTitle);
        }
    }
}