using Xunit;

namespace AspNetMvcSeo.Tests
{
    public class HtmlHelperSeoExtensionsTest
    {
        [Fact]
        public void LinkCanonical_EmptyArgument_ReturnsNull()
        {
            // Arrange
            var htmlHelper = HtmlHelperTestUtility.Get();

            // Act
            var html = htmlHelper.LinkCanonical();

            // Assert
            Assert.Null(html);
        }

        [Fact]
        public void LinkCanonical_EmptyArgumentWithValueInSeoHelper_ReturnsHtmlContainingValue()
        {
            // Arrange
            var requestContext = RequestContextTestUtility.Get();
            var seoHelper = new SeoHelper(requestContext) { LinkCanonical = $"{TestData.TestLinkCanonical}" };
            var htmlHelper = HtmlHelperTestUtility.Get(requestContext);

            // Act
            var html = htmlHelper.LinkCanonical();

            // Assert
            bool htmlContainsValue = html.Contains(TestData.TestLinkCanonical);

            Assert.True(htmlContainsValue);
        }

        [Fact]
        public void LinkCanonical_EmptyArgumentWithAppRelativeValueInSeoHelper_ReturnsHtmlContainingValueAndIsAbsolute()
        {
            // Arrange
            var requestContext = RequestContextTestUtility.Get();
            var seoHelper = new SeoHelper(requestContext) { LinkCanonical = $"~{TestData.TestLinkCanonical}" };
            var htmlHelper = HtmlHelperTestUtility.Get(requestContext);

            // Act
            var html = htmlHelper.LinkCanonical();

            // Assert
            bool htmlContainsValue = html.Contains(TestData.TestLinkCanonical);
            bool htmlContainsDomain = html.Contains(RequestContextTestUtility.Domain);
            bool htmlContainsAppRelativeCharacter = html.Contains(UriUtility.AppRelativeUrlCharacter);

            Assert.True(htmlContainsValue);
            Assert.True(htmlContainsDomain);
            Assert.False(htmlContainsAppRelativeCharacter);
        }

        [Fact]
        public void LinkCanonical_WithArgument_ReturnsHtmlContainingValue()
        {
            // Arrange
            var htmlHelper = HtmlHelperTestUtility.Get();

            // Act
            var html = htmlHelper.LinkCanonical(TestData.TestLinkCanonical);

            // Assert
            bool htmlContainsValue = html.Contains(TestData.TestLinkCanonical);

            Assert.True(htmlContainsValue);
        }

        [Fact]
        public void MetaDescription_EmptyArgument_ReturnsNull()
        {
            // Arrange
            var htmlHelper = HtmlHelperTestUtility.Get();

            // Act
            var html = htmlHelper.MetaDescription();

            // Assert
            Assert.Null(html);
        }

        [Fact]
        public void MetaDescription_EmptyArgumentWithValueInSeoHelper_ReturnsHtmlContainingValue()
        {
            // Arrange
            var requestContext = RequestContextTestUtility.Get();
            var seoHelper = new SeoHelper(requestContext) { MetaDescription = TestData.TestMetaDescription };
            var htmlHelper = HtmlHelperTestUtility.Get(requestContext);

            // Act
            var html = htmlHelper.MetaDescription();

            // Assert
            bool htmlContainsValue = html.Contains(TestData.TestMetaDescription);

            Assert.True(htmlContainsValue);
        }

        [Fact]
        public void MetaDescription_WithArgument_ReturnsHtmlContainingValue()
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
        public void MetaKeywords_EmptyArgument_ReturnsNull()
        {
            // Arrange
            var htmlHelper = HtmlHelperTestUtility.Get();

            // Act
            var html = htmlHelper.MetaKeywords();

            // Assert
            Assert.Null(html);
        }

        [Fact]
        public void MetaKeywords_EmptyArgumentWithValueInSeoHelper_ReturnsHtmlContainingValue()
        {
            // Arrange
            var requestContext = RequestContextTestUtility.Get();
            var seoHelper = new SeoHelper(requestContext) { MetaKeywords = TestData.TestMetaKeywords };
            var htmlHelper = HtmlHelperTestUtility.Get(requestContext);

            // Act
            var html = htmlHelper.MetaKeywords();

            // Assert
            bool htmlContainsValue = html.Contains(TestData.TestMetaKeywords);

            Assert.True(htmlContainsValue);
        }

        [Fact]
        public void MetaKeywords_WithArgument_ReturnsHtmlContainingValue()
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
        public void MetaRobotsIndex_EmptyArgument_ReturnsNull()
        {
            // Arrange
            var htmlHelper = HtmlHelperTestUtility.Get();

            // Act
            var html = htmlHelper.MetaRobotsIndex();

            // Assert
            Assert.Null(html);
        }

        [Fact]
        public void MetaRobotsIndex_EmptyArgumentWithMetaRobotsNoIndexInSeoHelper_ReturnsHtmlContainingValue()
        {
            // Arrange
            var requestContext = RequestContextTestUtility.Get();
            var seoHelper = new SeoHelper(requestContext) { MetaRobotsNoIndex = true };
            var htmlHelper = HtmlHelperTestUtility.Get(requestContext);

            // Act
            var html = htmlHelper.MetaRobotsIndex();

            // Assert
            bool htmlContainsGoogleBot = html.Contains(HtmlHelperSeoExtensions.GoogleBotMetaName);
            bool htmlContainsRobots = html.Contains(HtmlHelperSeoExtensions.RobotsMetaName);
            var defaultRobotsNoIndex = RobotsIndexManager.GetMetaContent(RobotsIndexManager.DefaultRobotsNoIndex);
            bool htmlContainsMetaContent = html.Contains(defaultRobotsNoIndex);

            Assert.True(htmlContainsGoogleBot);
            Assert.True(htmlContainsRobots);
            Assert.True(htmlContainsMetaContent);
        }

        [Theory]
        [InlineData(RobotsIndex.IndexNoFollow, RobotsIndexManager.IndexNoFollow)]
        [InlineData(RobotsIndex.NoIndexFollow, RobotsIndexManager.NoIndexFollow)]
        [InlineData(RobotsIndex.NoIndexNoFollow, RobotsIndexManager.NoIndexNoFollow)]
        public void MetaRobotsIndex_WithArgument_ReturnsHtmlContainingValue(RobotsIndex robotsIndex, string expectedContent)
        {
            // Arrange
            var htmlHelper = HtmlHelperTestUtility.Get();

            // Act
            var html = htmlHelper.MetaRobotsIndex(robotsIndex);

            // Assert
            bool htmlContainsGoogleBot = html.Contains(HtmlHelperSeoExtensions.GoogleBotMetaName);
            bool htmlContainsRobots = html.Contains(HtmlHelperSeoExtensions.RobotsMetaName);
            var metaContent = RobotsIndexManager.GetMetaContent(robotsIndex);
            bool htmlContainsMetaContent = html.Contains(metaContent);
            bool htmlContainsExpectedContent = html.Contains(expectedContent);

            Assert.True(htmlContainsGoogleBot);
            Assert.True(htmlContainsRobots);
            Assert.True(htmlContainsMetaContent);
            Assert.True(htmlContainsExpectedContent);
        }

        [Theory]
        [InlineData(RobotsIndex.IndexNoFollow)]
        [InlineData(RobotsIndex.NoIndexFollow)]
        [InlineData(RobotsIndex.NoIndexNoFollow)]
        public void MetaRobotsIndex_EmptyArgumentWithValuesInSeoHelper_ReturnsHtmlContainingValue(
            RobotsIndex robotsIndex)
        {
            // Arrange
            var requestContext = RequestContextTestUtility.Get();
            var seoHelper = new SeoHelper(requestContext) { MetaRobotsIndex = robotsIndex };
            var htmlHelper = HtmlHelperTestUtility.Get(requestContext);

            // Act
            var html = htmlHelper.MetaRobotsNoIndex();

            // Assert
            bool htmlContainsGoogleBot = html.Contains(HtmlHelperSeoExtensions.GoogleBotMetaName);
            bool htmlContainsRobots = html.Contains(HtmlHelperSeoExtensions.RobotsMetaName);
            var defaultRobotsNoIndex = RobotsIndexManager.GetMetaContent(RobotsIndexManager.DefaultRobotsNoIndex);
            bool htmlContainsDefaultRobotsNoIndex = html.Contains(defaultRobotsNoIndex);

            Assert.True(htmlContainsGoogleBot);
            Assert.True(htmlContainsRobots);
            Assert.True(htmlContainsDefaultRobotsNoIndex);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void MetaRobotsNoIndex_EmptyArgumentWithMetaRobotsNoIndexInSeoHelper_ReturnsHtmlContainingValue(
            bool metaRobotsNoIndex)
        {
            // Arrange
            var requestContext = RequestContextTestUtility.Get();
            var seoHelper = new SeoHelper(requestContext) { MetaRobotsNoIndex = metaRobotsNoIndex };
            var htmlHelper = HtmlHelperTestUtility.Get(requestContext);

            // Act
            var html = htmlHelper.MetaRobotsNoIndex();

            // Assert
            bool htmlContainsGoogleBot = html.Contains(HtmlHelperSeoExtensions.GoogleBotMetaName);
            bool htmlContainsRobots = html.Contains(HtmlHelperSeoExtensions.RobotsMetaName);
            var defaultRobotsNoIndex = RobotsIndexManager.GetMetaContent(RobotsIndexManager.DefaultRobotsNoIndex);
            bool htmlContainsDefaultRobotsNoIndex = html.Contains(defaultRobotsNoIndex);

            Assert.True(htmlContainsGoogleBot);
            Assert.True(htmlContainsRobots);
            Assert.True(htmlContainsDefaultRobotsNoIndex);
        }

        [Theory]
        [InlineData(RobotsIndex.NoIndexFollow)]
        [InlineData(RobotsIndex.NoIndexNoFollow)]
        [InlineData(RobotsIndex.IndexNoFollow)]
        public void MetaRobotsNoIndex_EmptyArgumentWithMetaRobotsIndexInSeoHelper_ReturnsHtmlContainingValue(
            RobotsIndex robotsIndex)
        {
            // Arrange
            var requestContext = RequestContextTestUtility.Get();
            var seoHelper = new SeoHelper(requestContext) { MetaRobotsIndex = robotsIndex };
            var htmlHelper = HtmlHelperTestUtility.Get(requestContext);

            // Act
            var html = htmlHelper.MetaRobotsNoIndex();

            // Assert
            bool htmlContainsGoogleBot = html.Contains(HtmlHelperSeoExtensions.GoogleBotMetaName);
            bool htmlContainsRobots = html.Contains(HtmlHelperSeoExtensions.RobotsMetaName);
            var defaultRobotsNoIndex = RobotsIndexManager.GetMetaContent(RobotsIndexManager.DefaultRobotsNoIndex);
            bool htmlContainsDefaultRobotsNoIndex = html.Contains(defaultRobotsNoIndex);

            Assert.True(htmlContainsGoogleBot);
            Assert.True(htmlContainsRobots);
            Assert.True(htmlContainsDefaultRobotsNoIndex);
        }

        [Fact]
        public void MetaRobotsNoIndex_WithArgument_ReturnsHtmlContainingValue()
        {
            // Arrange
            var htmlHelper = HtmlHelperTestUtility.Get();

            // Act
            var html = htmlHelper.MetaRobotsNoIndex();

            // Assert
            bool htmlContainsGoogleBot = html.Contains(HtmlHelperSeoExtensions.GoogleBotMetaName);
            bool htmlContainsRobots = html.Contains(HtmlHelperSeoExtensions.RobotsMetaName);
            var defaultRobotsNoIndex = RobotsIndexManager.GetMetaContent(RobotsIndexManager.DefaultRobotsNoIndex);
            bool htmlContainsDefaultRobotsNoIndex = html.Contains(defaultRobotsNoIndex);

            Assert.True(htmlContainsGoogleBot);
            Assert.True(htmlContainsRobots);
            Assert.True(htmlContainsDefaultRobotsNoIndex);
        }

        [Fact]
        public void Title_EmptyArgument_ReturnsNull()
        {
            // Arrange
            var htmlHelper = HtmlHelperTestUtility.Get();

            // Act
            var html = htmlHelper.Title();

            // Assert
            Assert.Null(html);
        }

        [Fact]
        public void Title_EmptyArgumentWithPageTitleInSeoHelper_ReturnsNotNull()
        {
            // Arrange
            var requestContext = RequestContextTestUtility.Get();
            var seoHelper = new SeoHelper(requestContext) { PageTitle = TestData.TestPageTitle };
            var htmlHelper = HtmlHelperTestUtility.Get(requestContext);

            // Act
            var html = htmlHelper.Title();

            // Assert
            bool htmlContainsValue = html.Contains(TestData.TestPageTitle);

            Assert.True(htmlContainsValue);
        }

        [Fact]
        public void Title_EmptyArgumentWithSiteTitleInSeoHelper_ReturnsHtmlContainingValue()
        {
            // Arrange
            var requestContext = RequestContextTestUtility.Get();
            var seoHelper = new SeoHelper(requestContext) { SiteTitle = TestData.TestSiteTitle };
            var htmlHelper = HtmlHelperTestUtility.Get(requestContext);

            // Act
            var html = htmlHelper.Title();

            // Assert
            bool htmlContainsValue = html.Contains(TestData.TestSiteTitle);

            Assert.True(htmlContainsValue);
        }

        [Fact]
        public void Title_WithArgument_ReturnsHtmlContainingValue()
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