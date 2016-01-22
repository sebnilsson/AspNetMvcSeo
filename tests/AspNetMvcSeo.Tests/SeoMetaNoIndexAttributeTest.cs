using Xunit;

namespace AspNetMvcSeo.Tests
{
    public class SeoMetaNoIndexAttributeTest
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void SetSeoValues_NoIndexValue_MetaNoIndex(bool noIndex)
        {
            // Arrange
            var attribute = new SeoMetaNoIndexAttribute(noIndex);

            var seo = SeoHelperTestUtility.Get();

            // Act
            attribute.SetSeoValues(seo);

            // Assert
            Assert.Equal(noIndex, seo.MetaNoIndex);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void SetSeoValues_NoIndexValue_MetaNoIndexOnly(bool noIndex)
        {
            // Arrange
            var attribute = new SeoMetaNoIndexAttribute(noIndex);

            var seo = SeoHelperTestUtility.Get();

            // Act
            attribute.SetSeoValues(seo);

            // Assert
            Assert.Null(seo.CanonicalLink);
            Assert.Null(seo.MetaDescription);
            Assert.Null(seo.MetaKeywords);
            Assert.Null(seo.PageTitle);
            Assert.Null(seo.SiteTitle);
        }
    }
}