using Xunit;

namespace AspNetMvcSeo.Tests
{
    public class SeoSectionTitleAttributeTest
    {
        [Fact]
        public void OnHandleSeoValues_TestSectionTitle_SetsSectionTitle()
        {
            // Arrange
            var attribute = new SeoSectionTitleAttribute(TestData.TestSectionTitle);

            var seo = SeoHelperTestFactory.Create();

            // Act
            attribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Equal(TestData.TestSectionTitle, seo.SectionTitle);
        }

        [Fact]
        public void OnHandleSeoValues_TestSectionTitle_SetsSectionTitleOnly()
        {
            // Arrange
            var attribute = new SeoSectionTitleAttribute(TestData.TestSectionTitle);

            var seo = SeoHelperTestFactory.Create();

            // Act
            attribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Null(seo.LinkCanonical);
            Assert.Null(seo.MetaDescription);
            Assert.Null(seo.MetaKeywords);
            Assert.Null(seo.MetaRobotsIndex);
            Assert.Null(seo.PageTitle);
            Assert.NotNull(seo.SectionTitle);
            Assert.NotNull(seo.Title);
        }

        [Fact]
        public void OnHandleSeoValues_TestSectionTitleOnly_SetsTitle()
        {
            // Arrange
            var attribute = new SeoSectionTitleAttribute(TestData.TestSectionTitle);

            var seo = SeoHelperTestFactory.Create();

            // Act
            attribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Equal(TestData.TestSectionTitle, seo.Title);
        }

        [Fact]
        public void OnHandleSeoValues_TestSectionTitleTwice_SetsSectionTitle()
        {
            const string FirstSectionTitle = "FIRST_SECTION_TITLE";
            const string SecondSectionTitle = "SECOND_SECTION_TITLE";

            // Arrange
            var firstAttribute = new SeoSectionTitleAttribute(FirstSectionTitle);
            var secondAttribute = new SeoSectionTitleAttribute(SecondSectionTitle);

            var seo = SeoHelperTestFactory.Create();

            // Act
            firstAttribute.OnHandleSeoValues(seo);
            secondAttribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Equal(SecondSectionTitle, seo.SectionTitle);
        }

        [Fact]
        public void OnHandleSeoValues_Format_SetsTitleFormat()
        {
            // Arrange
            var attribute = new SeoSectionTitleAttribute(TestData.TestSectionTitle)
                                {
                                    Format = TestData.TestTitleFormat
                                };

            var seo = SeoHelperTestFactory.Create();

            // Act
            attribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Equal(TestData.TestTitleFormat, seo.TitleFormat);
        }
    }
}