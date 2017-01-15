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
            seoHelper.PageTitle = TestData.TestPageTitle;

            // Assert
            Assert.Equal(TestData.TestPageTitle, seoHelper.Title);
        }

        public void Title_ChangedTitleFormat_SetsTitle()
        {
            const string SectionTitle = "SECTION_TITLE";
            const string PageTitle = "PAGE_TITLE";
            
            // Arrange
            var seo = SeoHelperTestFactory.Create();

            // Act
            seo.SectionTitle = SectionTitle;
            seo.PageTitle = PageTitle;
            seo.TitleFormat = TestData.TestTitleFormat;

            // Assert
            string expectedTitle = string.Format(TestData.TestTitleFormat, PageTitle, SectionTitle);

            Assert.Equal(expectedTitle, seo.Title);
        }

        [Fact]
        public void PageTitle_PageTitleAndSectionTitleNotEmpty_SetsTitleWithPageTitleAndSectionTitle()
        {
            // Arrange
            var seoHelper = SeoHelperTestFactory.Create();

            // Act
            seoHelper.SectionTitle = TestData.TestSectionTitle;
            seoHelper.PageTitle = TestData.TestPageTitle;

            // Assert
            bool seoTitleEndsWithSiteTitle = seoHelper.Title.EndsWith(TestData.TestSectionTitle);
            bool seoTitleStartsWithPageTitle = seoHelper.Title.StartsWith(TestData.TestPageTitle);

            Assert.True(seoTitleEndsWithSiteTitle);
            Assert.True(seoTitleStartsWithPageTitle);
        }

        [Fact]
        public void PageTitle_SectionTitleEmpty_SetsTitleToPageTitleOnly()
        {
            // Arrange
            var seoHelper = SeoHelperTestFactory.Create();

            // Act
            seoHelper.PageTitle = TestData.TestPageTitle;

            // Assert
            Assert.Equal(TestData.TestPageTitle, seoHelper.Title);
        }

        [Fact]
        public void SectionTitle_PageTitleEmpty_SetsTitleToSectionTitleOnly()
        {
            // Arrange
            var seoHelper = SeoHelperTestFactory.Create();

            // Act
            seoHelper.SectionTitle = TestData.TestSectionTitle;

            // Assert
            Assert.Equal(TestData.TestSectionTitle, seoHelper.Title);
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
            Assert.True(seoHelper.MetaRobotsNoIndex);
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
            Assert.False(seoHelper.MetaRobotsNoIndex);
        }
    }
}