using Xunit;

namespace AspNetMvcSeo.Tests
{
    public class SeoHelperTest
    {
        [Fact]
        public void PageTitle_SetWithSiteTitle_TitleContainsSiteTitleAndPageTitle()
        {
            // Arrange
            var seoHelper = SeoHelperTestUtility.Get(TestData.TestSiteTitle);

            // Act
            seoHelper.PageTitle = TestData.TestPageTitle;

            // Assert
            bool titleStartsWithPageTitle = seoHelper.Title.StartsWith(TestData.TestPageTitle);
            bool titleEndsWithSiteTitle = seoHelper.Title.EndsWith(TestData.TestSiteTitle);

            Assert.True(titleStartsWithPageTitle);
            Assert.True(titleEndsWithSiteTitle);
        }

        [Fact]
        public void PageTitle_Set_TitleEqualsPageTitle()
        {
            // Arrange
            var seoHelper = SeoHelperTestUtility.Get();

            // Act
            seoHelper.PageTitle = TestData.TestPageTitle;

            // Assert
            Assert.Equal(TestData.TestPageTitle, seoHelper.Title);
        }

        [Fact]
        public void PageTitle_SetNullWithSiteTitle_TitleEqualsSiteTitle()
        {
            // Arrange
            var seoHelper = SeoHelperTestUtility.Get(TestData.TestSiteTitle);

            // Act
            seoHelper.PageTitle = null;

            // Assert
            Assert.Equal(TestData.TestSiteTitle, seoHelper.Title);
        }

        [Fact]
        public void PageTitle_SetWithDefaultSiteTitleAndSiteTitle_TitleContainsSiteTitleAndNotDefaultSiteTitle()
        {
            lock (SeoHelper.DefaultSiteTitleLock)
            {
                try
                {
                    // Arrange
                    SeoHelper.DefaultSiteTitle = TestData.TestDefaultSiteTitle;
                    var seoHelper = SeoHelperTestUtility.Get(TestData.TestSiteTitle);

                    // Act
                    seoHelper.PageTitle = TestData.TestPageTitle;

                    // Assert
                    bool titleContainsSiteTitle = seoHelper.Title.Contains(TestData.TestSiteTitle);
                    bool titleContainsDefaultSiteTitle = seoHelper.Title.Contains(TestData.TestDefaultSiteTitle);

                    Assert.True(titleContainsSiteTitle);
                    Assert.False(titleContainsDefaultSiteTitle);
                }
                finally
                {
                    SeoHelper.DefaultSiteTitle = null;
                }
            }
        }

        [Fact]
        public void PageTitle_SetWithDefaultSiteTitleAndWithoutSiteTitle_TitleContainsDefaultSiteTitle()
        {
            lock (SeoHelper.DefaultSiteTitleLock)
            {
                try
                {
                    // Arrange
                    SeoHelper.DefaultSiteTitle = TestData.TestDefaultSiteTitle;
                    var seoHelper = SeoHelperTestUtility.Get();

                    // Act
                    seoHelper.PageTitle = TestData.TestPageTitle;

                    // Assert
                    bool titleContainsDefaultSiteTitle = seoHelper.Title.Contains(TestData.TestDefaultSiteTitle);

                    Assert.True(titleContainsDefaultSiteTitle);
                }
                finally
                {
                    SeoHelper.DefaultSiteTitle = null;
                }
            }
        }
    }
}