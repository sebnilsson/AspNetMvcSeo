using System.Collections.Generic;

using Xunit;

namespace AspNetMvcSeo.Tests
{
    public class HtmlHelperSeoExtensionsTest
    {
        [Fact]
        public void CanonicalLink_Empty_ReturnsNull()
        {
            // Arrange
            var htmlHelper = HtmlHelperTestUtility.Get();

            // Act
            var html = htmlHelper.CanonicalLink();

            // Assert
            Assert.Null(html);
        }

        [Fact]
        public void CanonicalLink_EmptyWithValueInSeoHelper_ReturnsHtmlContainingValue()
        {
            // Arrange
            var seoData = new Dictionary<object, object>();
            var seoHelper = new SeoHelper(seoData) { CanonicalLink = TestData.TestCanonicalLink };
            var htmlHelper = HtmlHelperTestUtility.Get(seoData);

            // Act
            var html = htmlHelper.CanonicalLink();

            // Assert
            bool htmlContainsValue = html.Contains(TestData.TestCanonicalLink);

            Assert.True(htmlContainsValue);
        }

        [Fact]
        public void CanonicalLink_WithValue_ReturnsHtmlContainingValue()
        {
            // Arrange
            var htmlHelper = HtmlHelperTestUtility.Get();

            // Act
            var html = htmlHelper.CanonicalLink(TestData.TestCanonicalLink);

            // Assert
            bool htmlContainsValue = html.Contains(TestData.TestCanonicalLink);

            Assert.True(htmlContainsValue);
        }

        [Fact]
        public void MetaDescription_Empty_ReturnsNull()
        {
            // Arrange
            var htmlHelper = HtmlHelperTestUtility.Get();

            // Act
            var html = htmlHelper.MetaDescription();

            // Assert
            Assert.Null(html);
        }

        [Fact]
        public void MetaDescription_EmptyWithValueInSeoHelper_ReturnsHtmlContainingValue()
        {
            // Arrange
            var seoData = new Dictionary<object, object>();
            var seoHelper = new SeoHelper(seoData) { MetaDescription = TestData.TestMetaDescription };
            var htmlHelper = HtmlHelperTestUtility.Get(seoData);

            // Act
            var html = htmlHelper.MetaDescription();

            // Assert
            bool htmlContainsValue = html.Contains(TestData.TestMetaDescription);

            Assert.True(htmlContainsValue);
        }

        [Fact]
        public void MetaDescription_WithValue_ReturnsHtmlContainingValue()
        {
            // Arrange
            var htmlHelper = HtmlHelperTestUtility.Get();

            // Act
            var html = htmlHelper.MetaDescription(TestData.TestMetaDescription);

            // Assert
            bool htmlContainsValue = html.Contains(TestData.TestMetaDescription);

            Assert.True(htmlContainsValue);
        }

        [Fact]
        public void MetaKeywords_Empty_ReturnsNull()
        {
            // Arrange
            var htmlHelper = HtmlHelperTestUtility.Get();

            // Act
            var html = htmlHelper.MetaKeywords();

            // Assert
            Assert.Null(html);
        }

        [Fact]
        public void MetaKeywords_EmptyWithValueInSeoHelper_ReturnsHtmlContainingValue()
        {
            // Arrange
            var seoData = new Dictionary<object, object>();
            var seoHelper = new SeoHelper(seoData) { MetaKeywords = TestData.TestMetaKeywords };
            var htmlHelper = HtmlHelperTestUtility.Get(seoData);

            // Act
            var html = htmlHelper.MetaKeywords();

            // Assert
            bool htmlContainsValue = html.Contains(TestData.TestMetaKeywords);

            Assert.True(htmlContainsValue);
        }

        [Fact]
        public void MetaKeywords_WithValue_ReturnsHtmlContainingValue()
        {
            // Arrange
            var htmlHelper = HtmlHelperTestUtility.Get();

            // Act
            var html = htmlHelper.MetaKeywords(TestData.TestMetaKeywords);

            // Assert
            bool htmlContainsValue = html.Contains(TestData.TestMetaKeywords);

            Assert.True(htmlContainsValue);
        }

        [Fact]
        public void MetaNoIndex_Empty_ReturnsNull()
        {
            // Arrange
            var htmlHelper = HtmlHelperTestUtility.Get();

            // Act
            var html = htmlHelper.MetaNoIndex();

            // Assert
            Assert.Null(html);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void MetaNoIndex_EmptyWithValueInSeoHelper_ReturnsHtmlContainingValue(bool noIndex)
        {
            // Arrange
            var seoData = new Dictionary<object, object>();
            var seoHelper = new SeoHelper(seoData) { MetaNoIndex = noIndex };
            var htmlHelper = HtmlHelperTestUtility.Get(seoData);

            // Act
            var html = htmlHelper.MetaNoIndex();

            // Assert
            bool htmlContainsGoogleBot = html.Contains(HtmlHelperSeoExtensions.GoogleBotMetaName);
            bool htmlContainsRobots = html.Contains(HtmlHelperSeoExtensions.RobotsMetaName);

            Assert.True(htmlContainsGoogleBot);
            Assert.True(htmlContainsRobots);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void MetaNoIndex_WithValue_ReturnsHtmlContainingValue(bool noIndex)
        {
            // Arrange
            var htmlHelper = HtmlHelperTestUtility.Get();

            // Act
            var html = htmlHelper.MetaNoIndex(noIndex: noIndex);

            // Assert
            bool htmlContainsGoogleBot = html.Contains(HtmlHelperSeoExtensions.GoogleBotMetaName);
            bool htmlContainsRobots = html.Contains(HtmlHelperSeoExtensions.RobotsMetaName);

            Assert.True(htmlContainsGoogleBot);
            Assert.True(htmlContainsRobots);
        }

        [Fact]
        public void Title_Empty_ReturnsNull()
        {
            // Arrange
            var htmlHelper = HtmlHelperTestUtility.Get();

            // Act
            var html = htmlHelper.Title();

            // Assert
            Assert.Null(html);
        }

        [Fact]
        public void Title_EmptyWithPageTitleInSeoHelper_ReturnsNotNull()
        {
            // Arrange
            var seoData = new Dictionary<object, object>();
            var seoHelper = new SeoHelper(seoData) { PageTitle = TestData.TestPageTitle };
            var htmlHelper = HtmlHelperTestUtility.Get(seoData);

            // Act
            var html = htmlHelper.Title();

            // Assert
            bool htmlContainsValue = html.Contains(TestData.TestPageTitle);

            Assert.True(htmlContainsValue);
        }

        [Fact]
        public void Title_EmptyWithSiteTitleInSeoHelper_ReturnsHtmlContainingValue()
        {
            // Arrange
            var seoData = new Dictionary<object, object>();
            var seoHelper = new SeoHelper(seoData) { SiteTitle = TestData.TestSiteTitle };
            var htmlHelper = HtmlHelperTestUtility.Get(seoData);

            // Act
            var html = htmlHelper.Title();

            // Assert
            bool htmlContainsValue = html.Contains(TestData.TestSiteTitle);
            
            Assert.True(htmlContainsValue);
        }

        [Fact]
        public void Title_WithValue_ReturnsHtmlContainingValue()
        {
            // Arrange
            var htmlHelper = HtmlHelperTestUtility.Get();

            // Act
            var html = htmlHelper.Title(TestData.TestPageTitle);

            // Assert
            bool htmlContainsValue = html.Contains(TestData.TestPageTitle);

            Assert.True(htmlContainsValue);
        }
    }
}