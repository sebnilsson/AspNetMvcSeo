using Xunit;

namespace AspNetMvcSeo.Tests
{
    public class SeoMetaRobotsIndexAttributeTest
    {
        [Theory]
        [InlineData(RobotsIndex.IndexNoFollow)]
        [InlineData(RobotsIndex.NoIndexFollow)]
        [InlineData(RobotsIndex.NoIndexNoFollow)]
        public void SetSeoValues_NoIndexValue_SetsMetaRobotsIndex(RobotsIndex robotsIndex)
        {
            // Arrange
            var attribute = new SeoMetaRobotsIndexAttribute(robotsIndex);

            var seo = SeoHelperTestUtility.Get();

            // Act
            attribute.SetSeoValues(seo);

            // Assert
            Assert.Equal(robotsIndex, seo.MetaRobotsIndex);
        }

        [Theory]
        [InlineData(RobotsIndex.IndexNoFollow)]
        [InlineData(RobotsIndex.NoIndexFollow)]
        [InlineData(RobotsIndex.NoIndexNoFollow)]
        public void SetSeoValues_NoIndexValue_MetaNoIndexOnly(RobotsIndex robotsIndex)
        {
            // Arrange
            var attribute = new SeoMetaRobotsIndexAttribute(robotsIndex);

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

        [Fact]
        public void SetSeoValues_Empty_SetsMetaRobotsIndexToNull()
        {
            // Arrange
            var attribute = new SeoMetaRobotsIndexAttribute();

            var seo = SeoHelperTestUtility.Get();

            // Act
            attribute.SetSeoValues(seo);

            // Assert
            Assert.Null(seo.MetaRobotsIndex);
        }
    }
}