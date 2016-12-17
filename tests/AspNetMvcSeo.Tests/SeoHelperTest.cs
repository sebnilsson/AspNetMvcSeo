using Xunit;

namespace AspNetMvcSeo.Tests
{
    public class SeoHelperTest
    {
        [Fact]
        public void Title_Set_TitleEqualsPageTitle()
        {
            // Arrange
            var seoHelper = SeoHelperTestFactory.Create();

            // Act
            seoHelper.Title = TestData.TestPageTitle;

            // Assert
            Assert.Equal(TestData.TestPageTitle, seoHelper.Title);
        }

        [Fact]
        public void Title_SetTwiceWithSiteTitleAndPageTitle_SetsSiteTitleAndPageTitle()
        {
            // Arrange
            var seoHelper = SeoHelperTestFactory.Create();

            // Act
            seoHelper.Title = TestData.TestSiteTitle;
            seoHelper.Title = TestData.TestPageTitle;

            // Assert
            bool seoTitleEndsWithSiteTitle = seoHelper.Title.EndsWith(TestData.TestSiteTitle);
            bool seoTitleStartsWithPageTitle = seoHelper.Title.StartsWith(TestData.TestPageTitle);

            Assert.True(seoTitleEndsWithSiteTitle);
            Assert.True(seoTitleStartsWithPageTitle);
        }

        [Fact]
        public void MetaRobotsNoIndex_SetTrue_MetaRobotsIndexEqualsDefaultRobotsNoIndex()
        {
            // Arrange
            var seoHelper = SeoHelperTestFactory.Create();

            // Act
            seoHelper.MetaRobotsNoIndex = true;

            // Assert
            Assert.Equal(RobotsIndexManager.DefaultRobotsNoIndex, seoHelper.MetaRobotsIndex);
        }

        [Fact]
        public void MetaRobotsNoIndex_SetFalse_MetaRobotsIndexIsNull()
        {
            // Arrange
            var seoHelper = SeoHelperTestFactory.Create();

            // Act
            seoHelper.MetaRobotsNoIndex = false;

            // Assert
            Assert.Null(seoHelper.MetaRobotsIndex);
        }

        [Fact]
        public void SetTitle_TwiceWithSiteTitleAndPageTitle_SetsSiteTitleAndPageTitle()
        {
            // Arrange
            var seoHelper = SeoHelperTestFactory.Create();

            // Act
            seoHelper.SetTitle(TestData.TestSiteTitle);
            seoHelper.SetTitle(TestData.TestPageTitle);

            // Assert
            bool seoTitleContainsSiteTitle = seoHelper.Title.Contains(TestData.TestSiteTitle);
            bool seoTitleContainsPageTitle = seoHelper.Title.Contains(TestData.TestPageTitle);

            Assert.True(seoTitleContainsSiteTitle);
            Assert.True(seoTitleContainsPageTitle);
        }
        
        [Fact]
        public void SetTitle_TwiceWithSiteTitleAndPageTitleAndOverride_SetsPageTitle()
        {
            // Arrange
            var seoHelper = SeoHelperTestFactory.Create();

            // Act
            seoHelper.SetTitle(TestData.TestSiteTitle);
            seoHelper.SetTitle(TestData.TestPageTitle, overrideTitle: true);

            // Assert
            bool seoTitleContainsSiteTitle = seoHelper.Title.Contains(TestData.TestSiteTitle);
            bool seoTitleContainsPageTitle = seoHelper.Title.Contains(TestData.TestPageTitle);

            Assert.False(seoTitleContainsSiteTitle);
            Assert.True(seoTitleContainsPageTitle);
        }
    }
}