using Xunit;

namespace AspNetMvcSeo.Tests
{
    public class SeoPageTitleAttributeTest
    {
        [Fact]
        public void OnHandleSeoValues_TestPageTitle_SetsPageTitle()
        {
            // Arrange
            var attribute = new SeoPageTitleAttribute(TestData.TestPageTitle);

            var seo = SeoHelperTestFactory.Create();

            // Act
            attribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Equal(TestData.TestPageTitle, seo.PageTitle);
        }

        [Fact]
        public void OnHandleSeoValues_TestPageTitle_SetsPageTitleOnly()
        {
            // Arrange
            var attribute = new SeoPageTitleAttribute(TestData.TestPageTitle);

            var seo = SeoHelperTestFactory.Create();

            // Act
            attribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Null(seo.LinkCanonical);
            Assert.Null(seo.MetaDescription);
            Assert.Null(seo.MetaKeywords);
            Assert.Null(seo.MetaRobotsIndex);
            Assert.Null(seo.SectionTitle);
            Assert.NotNull(seo.PageTitle);
            Assert.NotNull(seo.Title);
        }

        [Fact]
        public void OnHandleSeoValues_TestPageTitleOnly_SetsTitle()
        {
            // Arrange
            var attribute = new SeoPageTitleAttribute(TestData.TestPageTitle);

            var seo = SeoHelperTestFactory.Create();

            // Act
            attribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Equal(TestData.TestPageTitle, seo.Title);
        }

        [Fact]
        public void OnHandleSeoValues_TestPageTitleTwice_SetsPageTitle()
        {
            const string FirstPageTitle = "FIRST_PAGE_TITLE";
            const string SecondPageTitle = "SECOND_PAGE_TITLE";

            // Arrange
            var firstAttribute = new SeoPageTitleAttribute(FirstPageTitle);
            var secondAttribute = new SeoPageTitleAttribute(SecondPageTitle);

            var seo = SeoHelperTestFactory.Create();

            // Act
            firstAttribute.OnHandleSeoValues(seo);
            secondAttribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Equal(SecondPageTitle, seo.PageTitle);
        }

        [Fact]
        public void OnHandleSeoValues_Format_SetsTitleFormat()
        {
            // Arrange
            var attribute = new SeoPageTitleAttribute(TestData.TestPageTitle) { Format = TestData.TestTitleFormat };

            var seo = SeoHelperTestFactory.Create();

            // Act
            attribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Equal(TestData.TestTitleFormat, seo.TitleFormat);
        }

        [Fact]
        public void OnHandleSeoValues_TestPageTitleAndOverrideSectionTitle_ResetsSectionTitle()
        {
            // Arrange
            var attribute = new SeoPageTitleAttribute(TestData.TestPageTitle) { OverrideSectionTitle = true };

            var seo = SeoHelperTestFactory.Create();

            // Act
            attribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Equal(TestData.TestPageTitle, seo.PageTitle);
            Assert.Null(seo.SectionTitle);
        }
    }
}