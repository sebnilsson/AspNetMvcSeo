using Xunit;

namespace AspNetMvcSeo.Tests
{
    public class SeoBaseTitleAttributeTest
    {
        [Fact]
        public void OnHandleSeoValues_TestBaseTitle_SetsBaseTitle()
        {
            // Arrange
            var attribute = new SeoBaseTitleAttribute(TestData.TestBaseTitle);

            var seo = SeoHelperTestFactory.Create();

            // Act
            attribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Equal(TestData.TestBaseTitle, seo.BaseTitle);
        }

        [Fact]
        public void OnHandleSeoValues_TestBaseTitle_SetsBaseTitleOnly()
        {
            // Arrange
            var attribute = new SeoBaseTitleAttribute(TestData.TestBaseTitle);

            var seo = SeoHelperTestFactory.Create();

            // Act
            attribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Equal(TestData.TestBaseTitle, seo.BaseTitle);
            Assert.Null(seo.LinkCanonical);
            Assert.Null(seo.BaseLinkCanonical);
            Assert.Null(seo.MetaDescription);
            Assert.Null(seo.MetaKeywords);
            Assert.Null(seo.MetaRobotsIndex);
            Assert.Null(seo.Title);
        }

        [Fact]
        public void OnHandleSeoValues_TestBaseTitleTwice_SetsBaseTitle()
        {
            const string FirstBaseTitle = "FIRST_BASE_TITLE";
            const string SecondBaseTitle = "SECOND_BASE_TITLE";

            // Arrange
            var firstAttribute = new SeoBaseTitleAttribute(FirstBaseTitle);
            var secondAttribute = new SeoBaseTitleAttribute(SecondBaseTitle);

            var seo = SeoHelperTestFactory.Create();

            // Act
            firstAttribute.OnHandleSeoValues(seo);
            secondAttribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Equal(SecondBaseTitle, seo.BaseTitle);
        }

        [Fact]
        public void OnHandleSeoValues_Format_SetsTitleFormat()
        {
            // Arrange
            var attribute = new SeoBaseTitleAttribute(TestData.TestBaseTitle)
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