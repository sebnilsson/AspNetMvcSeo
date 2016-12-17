using Xunit;

namespace AspNetMvcSeo.Tests
{
    public class SeoTitleAttributeTest
    {
        [Fact]
        public void OnHandleSeoValues_TestPageTitle_SetsPageTitle()
        {
            // Arrange
            var attribute = new SeoTitleAttribute(TestData.TestPageTitle);

            var seo = SeoHelperTestFactory.Create();

            // Act
            attribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Equal(TestData.TestPageTitle, seo.Title);
        }

        [Fact]
        public void OnHandleSeoValues_TestPageTitle_SetsPageTitleOnly()
        {
            // Arrange
            var attribute = new SeoTitleAttribute(TestData.TestPageTitle);

            var seo = SeoHelperTestFactory.Create();

            // Act
            attribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Null(seo.LinkCanonical);
            Assert.Null(seo.MetaDescription);
            Assert.Null(seo.MetaKeywords);
            Assert.Null(seo.MetaRobotsIndex);
            Assert.NotNull(seo.Title);
        }

        [Fact]
        public void OnHandleSeoValues_TwiceWithSiteTitleAndPageTitle_SetsSiteTitleAndPageTitle()
        {
            // Arrange
            var siteTitleAttribute = new SeoTitleAttribute(TestData.TestSiteTitle);
            var pageTitleAttribute = new SeoTitleAttribute(TestData.TestPageTitle);

            var seo = SeoHelperTestFactory.Create();

            // Act
            siteTitleAttribute.OnHandleSeoValues(seo);
            pageTitleAttribute.OnHandleSeoValues(seo);

            // Assert
            bool seoTitleEndsWithSiteTitle = seo.Title.EndsWith(TestData.TestSiteTitle);
            bool seoTitleStartsWithPageTitle = seo.Title.StartsWith(TestData.TestPageTitle);

            Assert.True(seoTitleEndsWithSiteTitle);
            Assert.True(seoTitleStartsWithPageTitle);
        }


        [Fact]
        public void OnHandleSeoValues_TwiceWithSiteTitleAndPageTitleAndOverride_SetsPageTitle()
        {
            // Arrange
            var siteTitleAttribute = new SeoTitleAttribute(TestData.TestSiteTitle);
            var pageTitleAttribute = new SeoTitleAttribute(TestData.TestPageTitle) { Override = true };

            var seo = SeoHelperTestFactory.Create();

            // Act
            siteTitleAttribute.OnHandleSeoValues(seo);
            pageTitleAttribute.OnHandleSeoValues(seo);

            // Assert
            bool seoTitleContainsSiteTitle = seo.Title.Contains(TestData.TestSiteTitle);
            bool seoTitleContainsPageTitle = seo.Title.Contains(TestData.TestPageTitle);

            Assert.False(seoTitleContainsSiteTitle);
            Assert.True(seoTitleContainsPageTitle);
        }
    }
}