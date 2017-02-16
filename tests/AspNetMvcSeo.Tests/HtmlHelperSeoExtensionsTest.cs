using Xunit;

namespace AspNetMvcSeo.Tests
{
    public class HtmlHelperSeoExtensionsTest
    {
        [Fact]
        public void SeoLinkCanonical_EmptyArgument_ReturnsNull()
        {
            // Arrange
            var htmlHelper = HtmlHelperTestFactory.Create();

            // Act
            var html = htmlHelper.SeoLinkCanonical();

            // Assert
            Assert.Null(html);
        }

        [Fact]
        public void SeoLinkCanonical_EmptyArgumentWithValueInSeoHelper_ReturnsHtmlContainingValue()
        {
            // Arrange
            var viewContext = ViewContextTestFactory.Create();
            var htmlHelper = HtmlHelperTestFactory.Create(viewContext);
            var seoHelper = SeoHelperTestFactory.Create(viewContext);

            seoHelper.LinkCanonical = $"{TestData.TestLinkCanonical}";

            // Act
            var html = htmlHelper.SeoLinkCanonical();

            // Assert
            bool htmlContainsValue = html.Contains(TestData.TestLinkCanonical);

            Assert.True(htmlContainsValue);
        }

        [Fact]
        public void
            SeoLinkCanonical_EmptyArgumentWithAppRelativeValueInSeoHelper_ReturnsHtmlContainingValueAndIsAbsolute()
        {
            // Arrange
            var viewContext = ViewContextTestFactory.Create();
            var htmlHelper = HtmlHelperTestFactory.Create(viewContext);
            var seoHelper = SeoHelperTestFactory.Create(viewContext);

            seoHelper.LinkCanonical = TestData.TestAppRelativeLinkCanonical;

            // Act
            var html = htmlHelper.SeoLinkCanonical();

            // Assert
            bool htmlContainsValue = html.Contains(TestData.TestLinkCanonical);
            bool htmlContainsDomain = html.Contains(RequestContextTestFactory.Domain);
            bool htmlContainsAppRelativeCharacter = html.Contains("~");

            Assert.True(htmlContainsValue);
            Assert.True(htmlContainsDomain);
            Assert.False(htmlContainsAppRelativeCharacter);
        }

        [Fact]
        public void SeoLinkCanonical_WithArgument_ReturnsHtmlContainingValue()
        {
            // Arrange
            var htmlHelper = HtmlHelperTestFactory.Create();

            // Act
            var html = htmlHelper.SeoLinkCanonical(TestData.TestLinkCanonical);

            // Assert
            bool htmlContainsValue = html.Contains(TestData.TestLinkCanonical);

            Assert.True(htmlContainsValue);
        }

        [Fact]
        public void SeoLinkCanonical_WithArgument_ReturnsHtmlContainingAbsoluteUrl()
        {
            // Arrange
            var htmlHelper = HtmlHelperTestFactory.Create();

            // Act
            var html = htmlHelper.SeoLinkCanonical(TestData.TestLinkCanonical);

            // Assert
            bool htmlContainsAbsoluteUrl = html.Contains(RequestContextTestFactory.Domain);

            Assert.True(htmlContainsAbsoluteUrl);
        }

        [Fact]
        public void SeoLinkCanonical_WithLinkCanonicalBase_ReturnsHtmlContainingLinkCanonicalBase()
        {
            const string LinkCanonicalBase = "https://linkcanonical.co/base/";

            // Arrange
            var htmlHelper = HtmlHelperTestFactory.Create();

            // Act
            var html = htmlHelper.SeoLinkCanonical(TestData.TestLinkCanonical, linkCanonicalBase: LinkCanonicalBase);

            // Assert
            bool htmlContainsLinkCanonicalBase = html.Contains(LinkCanonicalBase);

            Assert.True(htmlContainsLinkCanonicalBase);
        }

        [Fact]
        public void
            SeoLinkCanonical_WithAppRelativeLinkCanonicalAndLinkCanonicalBase_ReturnsHtmlNotContainingAppRelativeChar()
        {
            const string LinkCanonicalBase = "https://linkcanonical.co/base/";

            // Arrange
            var htmlHelper = HtmlHelperTestFactory.Create();

            // Act
            var html = htmlHelper.SeoLinkCanonical(
                TestData.TestAppRelativeLinkCanonical,
                linkCanonicalBase: LinkCanonicalBase);

            // Assert
            bool htmlContainsAppRelativeChar = html.Contains("~");

            Assert.False(htmlContainsAppRelativeChar);
        }

        [Fact]
        public void SeoMetaDescription_EmptyArgument_ReturnsNull()
        {
            // Arrange
            var htmlHelper = HtmlHelperTestFactory.Create();

            // Act
            var html = htmlHelper.SeoMetaDescription();

            // Assert
            Assert.Null(html);
        }

        [Fact]
        public void SeoMetaDescription_EmptyArgumentWithValueInSeoHelper_ReturnsHtmlContainingValue()
        {
            // Arrange
            var viewContext = ViewContextTestFactory.Create();
            var htmlHelper = HtmlHelperTestFactory.Create(viewContext);
            var seoHelper = SeoHelperTestFactory.Create(viewContext);

            seoHelper.MetaDescription = TestData.TestMetaDescription;

            // Act
            var html = htmlHelper.SeoMetaDescription();

            // Assert
            bool htmlContainsValue = html.Contains(TestData.TestMetaDescription);

            Assert.True(htmlContainsValue);
        }

        [Fact]
        public void SeoMetaDescription_WithArgument_ReturnsHtmlContainingValue()
        {
            // Arrange
            var htmlHelper = HtmlHelperTestFactory.Create();

            // Act
            var html = htmlHelper.SeoMetaDescription(TestData.TestMetaDescription);

            // Assert
            bool htmlContainsValue = html.Contains(TestData.TestMetaDescription);

            Assert.True(htmlContainsValue);
        }

        [Fact]
        public void SeoMetaKeywords_EmptyArgument_ReturnsNull()
        {
            // Arrange
            var htmlHelper = HtmlHelperTestFactory.Create();

            // Act
            var html = htmlHelper.SeoMetaKeywords();

            // Assert
            Assert.Null(html);
        }

        [Fact]
        public void SeoMetaKeywords_EmptyArgumentWithValueInSeoHelper_ReturnsHtmlContainingValue()
        {
            // Arrange
            var viewContext = ViewContextTestFactory.Create();
            var htmlHelper = HtmlHelperTestFactory.Create(viewContext);
            var seoHelper = SeoHelperTestFactory.Create(viewContext);

            seoHelper.MetaKeywords = TestData.TestMetaKeywords;

            // Act
            var html = htmlHelper.SeoMetaKeywords();

            // Assert
            bool htmlContainsValue = html.Contains(TestData.TestMetaKeywords);

            Assert.True(htmlContainsValue);
        }

        [Fact]
        public void SeoMetaKeywords_WithArgument_ReturnsHtmlContainingValue()
        {
            // Arrange
            var htmlHelper = HtmlHelperTestFactory.Create();

            // Act
            var html = htmlHelper.SeoMetaKeywords(TestData.TestMetaKeywords);

            // Assert
            bool htmlContainsValue = html.Contains(TestData.TestMetaKeywords);

            Assert.True(htmlContainsValue);
        }

        [Fact]
        public void SeoMetaRobotsIndex_EmptyArgument_ReturnsNull()
        {
            // Arrange
            var htmlHelper = HtmlHelperTestFactory.Create();

            // Act
            var html = htmlHelper.SeoMetaRobotsIndex();

            // Assert
            Assert.Null(html);
        }

        [Fact]
        public void SeoMetaRobotsIndex_EmptyArgumentWithMetaRobotsNoIndexInSeoHelper_ReturnsHtmlContainingValue()
        {
            // Arrange
            var viewContext = ViewContextTestFactory.Create();
            var htmlHelper = HtmlHelperTestFactory.Create(viewContext);
            var seoHelper = SeoHelperTestFactory.Create(viewContext);

            seoHelper.MetaRobotsNoIndex = true;

            // Act
            var html = htmlHelper.SeoMetaRobotsIndex();

            // Assert
            bool htmlContainsRobots = html.Contains("robots");
            var defaultRobotsNoIndex = RobotsIndexManager.GetMetaContent(RobotsIndexManager.DefaultRobotsNoIndex);
            bool htmlContainsMetaContent = html.Contains(defaultRobotsNoIndex);

            Assert.True(htmlContainsRobots);
            Assert.True(htmlContainsMetaContent);
        }

        [Theory]
        [InlineData(RobotsIndex.IndexNoFollow, RobotsIndexManager.IndexNoFollowMetaContent)]
        [InlineData(RobotsIndex.NoIndexFollow, RobotsIndexManager.NoIndexFollowMetaContent)]
        [InlineData(RobotsIndex.NoIndexNoFollow, RobotsIndexManager.NoIndexNoFollowMetaContent)]
        public void SeoMetaRobotsIndex_WithArgument_ReturnsHtmlContainingValue(
            RobotsIndex robotsIndex,
            string expectedContent)
        {
            // Arrange
            var htmlHelper = HtmlHelperTestFactory.Create();

            // Act
            var html = htmlHelper.SeoMetaRobotsIndex(robotsIndex);

            // Assert
            bool htmlContainsRobots = html.Contains("robots");
            var metaContent = RobotsIndexManager.GetMetaContent(robotsIndex);
            bool htmlContainsMetaContent = html.Contains(metaContent);
            bool htmlContainsExpectedContent = html.Contains(expectedContent);

            Assert.True(htmlContainsRobots);
            Assert.True(htmlContainsMetaContent);
            Assert.True(htmlContainsExpectedContent);
        }

        [Theory]
        [InlineData(RobotsIndex.IndexNoFollow, RobotsIndexManager.IndexNoFollowMetaContent)]
        [InlineData(RobotsIndex.NoIndexFollow, RobotsIndexManager.NoIndexFollowMetaContent)]
        [InlineData(RobotsIndex.NoIndexNoFollow, RobotsIndexManager.NoIndexNoFollowMetaContent)]
        public void SeoMetaRobotsIndex_EmptyArgumentWithValuesInSeoHelper_ReturnsHtmlContainingValue(
            RobotsIndex robotsIndex,
            string expectedContent)
        {
            // Arrange
            var viewContext = ViewContextTestFactory.Create();
            var htmlHelper = HtmlHelperTestFactory.Create(viewContext);
            var seoHelper = SeoHelperTestFactory.Create(viewContext);

            seoHelper.MetaRobotsIndex = robotsIndex;

            // Act
            var html = htmlHelper.SeoMetaRobotsIndex();

            // Assert
            bool htmlContainsRobots = html.Contains("robots");
            var metaContent = RobotsIndexManager.GetMetaContent(robotsIndex);
            bool htmlContainsMetaContent = html.Contains(metaContent);
            bool htmlContainsExpectedContent = html.Contains(expectedContent);

            Assert.True(htmlContainsRobots);
            Assert.True(htmlContainsMetaContent);
            Assert.True(htmlContainsExpectedContent);
        }

        [Fact]
        public void SeoTitle_EmptyArgument_ReturnsNull()
        {
            // Arrange
            var htmlHelper = HtmlHelperTestFactory.Create();

            // Act
            var html = htmlHelper.SeoTitle();

            // Assert
            Assert.Null(html);
        }

        [Fact]
        public void SeoTitle_EmptyArgumentWithPageTitleInSeoHelper_ReturnsNotNull()
        {
            // Arrange
            var viewContext = ViewContextTestFactory.Create();
            var htmlHelper = HtmlHelperTestFactory.Create(viewContext);
            var seoHelper = SeoHelperTestFactory.Create(viewContext);

            seoHelper.Title = TestData.TestTitle;

            // Act
            var html = htmlHelper.SeoTitle();

            // Assert
            bool htmlContainsValue = html.Contains(TestData.TestTitle);

            Assert.True(htmlContainsValue);
        }

        [Fact]
        public void SeoTitle_EmptyArgumentWithBaseTitleInSeoHelper_ReturnsHtmlContainingValue()
        {
            // Arrange
            var viewContext = ViewContextTestFactory.Create();
            var htmlHelper = HtmlHelperTestFactory.Create(viewContext);
            var seoHelper = SeoHelperTestFactory.Create(viewContext);

            seoHelper.BaseTitle = TestData.TestBaseTitle;

            // Act
            var html = htmlHelper.SeoTitle();

            // Assert
            bool htmlContainsValue = html.Contains(TestData.TestBaseTitle);

            Assert.True(htmlContainsValue);
        }

        [Fact]
        public void SeoTitle_WithArgument_ReturnsHtmlContainingValue()
        {
            // Arrange
            var htmlHelper = HtmlHelperTestFactory.Create();

            // Act
            var html = htmlHelper.SeoTitle(TestData.TestTitle);

            // Assert
            bool htmlContainsValue = html.Contains(TestData.TestTitle);

            Assert.True(htmlContainsValue);
        }
    }
}