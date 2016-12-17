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

        // TODO: Change tests to reflect new structure
        //[Fact]
        //public void PageTitle_SetWithDefaultSiteTitleAndSiteTitle_TitleContainsSiteTitleAndNotDefaultSiteTitle()
        //{
        //    lock (SeoHelper.DefaultSiteTitleLock)
        //    {
        //        try
        //        {
        //            // Arrange
        //            SeoHelper.DefaultSiteTitle = TestData.TestDefaultSiteTitle;
        //            var seoHelper = SeoHelperTestFactory.Create();

        //            // Act
        //            seoHelper.Title = TestData.TestTitle;

        //            // Assert
        //            bool titleContainsSiteTitle = seoHelper.Title.Contains(TestData.TestTitle);
        //            bool titleContainsDefaultSiteTitle = seoHelper.Title.Contains(TestData.TestDefaultSiteTitle);

        //            Assert.True(titleContainsSiteTitle);
        //            Assert.False(titleContainsDefaultSiteTitle);
        //        }
        //        finally
        //        {
        //            SeoHelper.DefaultSiteTitle = null;
        //        }
        //    }
        //}

        //[Fact]
        //public void PageTitle_SetWithDefaultSiteTitleAndWithoutSiteTitle_TitleContainsDefaultSiteTitle()
        //{
        //    lock (SeoHelper.DefaultSiteTitleLock)
        //    {
        //        try
        //        {
        //            // Arrange
        //            SeoHelper.DefaultSiteTitle = TestData.TestDefaultSiteTitle;
        //            var seoHelper = SeoHelperTestFactory.Create();

        //            // Act
        //            seoHelper.PageTitle = TestData.TestPageTitle;

        //            // Assert
        //            bool titleContainsDefaultSiteTitle = seoHelper.Title.Contains(TestData.TestDefaultSiteTitle);

        //            Assert.True(titleContainsDefaultSiteTitle);
        //        }
        //        finally
        //        {
        //            SeoHelper.DefaultSiteTitle = null;
        //        }
        //    }
        //}
    }
}