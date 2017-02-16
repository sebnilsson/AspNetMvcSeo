using Xunit;

namespace AspNetMvcSeo.Tests
{
    public class SeoHelperTitleHelperTest
    {
        [Fact]
        public void GetTitle_TitleEmptyAndBaseTitleNotEmpty_ReturnsBaseTitle()
        {
            // Arrange
            var seoHelper = SeoHelperTestFactory.Create();
            seoHelper.BaseTitle = TestData.TestBaseTitle;

            // Act
            var title = SeoHelperTitleHelper.GetTitle(seoHelper);

            // Assert
            Assert.Equal(TestData.TestBaseTitle, title);
        }

        [Fact]
        public void GetTitle_TitleNotEmptyAndBaseTitleEmpty_ReturnsTitle()
        {
            // Arrange
            var seoHelper = SeoHelperTestFactory.Create();
            seoHelper.Title = TestData.TestTitle;

            // Act
            var title = SeoHelperTitleHelper.GetTitle(seoHelper);

            // Assert
            Assert.Equal(TestData.TestTitle, title);
        }

        [Fact]
        public void GetTitle_TitleAndBaseTitleNotEmpty_ReturnsTitleWithTitleAndBaseTitle()
        {
            // Arrange
            var seoHelper = SeoHelperTestFactory.Create();
            seoHelper.BaseTitle = TestData.TestBaseTitle;
            seoHelper.Title = TestData.TestTitle;

            // Act
            var title = SeoHelperTitleHelper.GetTitle(seoHelper);

            // Assert
            bool titleEndsWithSiteTitle = title.EndsWith(TestData.TestBaseTitle);
            bool titleStartsWithPageTitle = title.StartsWith(TestData.TestTitle);

            Assert.True(titleEndsWithSiteTitle);
            Assert.True(titleStartsWithPageTitle);
        }
    }
}