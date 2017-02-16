﻿using Xunit;

namespace AspNetMvcSeo.Tests
{
    public class SeoTitleAttributeTest
    {
        [Fact]
        public void OnHandleSeoValues_TestPageTitle_SetsPageTitle()
        {
            // Arrange
            var attribute = new SeoTitleAttribute(TestData.TestTitle);

            var seo = SeoHelperTestFactory.Create();

            // Act
            attribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Equal(TestData.TestTitle, seo.Title);
        }

        [Fact]
        public void OnHandleSeoValues_TestPageTitle_SetsPageTitleOnly()
        {
            // Arrange
            var attribute = new SeoTitleAttribute(TestData.TestTitle);

            var seo = SeoHelperTestFactory.Create();

            // Act
            attribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Null(seo.BaseLinkCanonical);
            Assert.Null(seo.BaseTitle);
            Assert.Null(seo.LinkCanonical);
            Assert.Null(seo.MetaDescription);
            Assert.Null(seo.MetaKeywords);
            Assert.Null(seo.MetaRobotsIndex);
            Assert.NotNull(seo.Title);
            Assert.NotNull(seo.Title);
        }

        [Fact]
        public void OnHandleSeoValues_TestPageTitleOnly_SetsTitle()
        {
            // Arrange
            var attribute = new SeoTitleAttribute(TestData.TestTitle);

            var seo = SeoHelperTestFactory.Create();

            // Act
            attribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Equal(TestData.TestTitle, seo.Title);
        }

        [Fact]
        public void OnHandleSeoValues_TestPageTitleTwice_SetsPageTitle()
        {
            const string FirstPageTitle = "FIRST_PAGE_TITLE";
            const string SecondPageTitle = "SECOND_PAGE_TITLE";

            // Arrange
            var firstAttribute = new SeoTitleAttribute(FirstPageTitle);
            var secondAttribute = new SeoTitleAttribute(SecondPageTitle);

            var seo = SeoHelperTestFactory.Create();

            // Act
            firstAttribute.OnHandleSeoValues(seo);
            secondAttribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Equal(SecondPageTitle, seo.Title);
        }

        [Fact]
        public void OnHandleSeoValues_Format_SetsTitleFormat()
        {
            // Arrange
            var attribute = new SeoTitleAttribute(TestData.TestTitle) { Format = TestData.TestTitleFormat };

            var seo = SeoHelperTestFactory.Create();

            // Act
            attribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Equal(TestData.TestTitleFormat, seo.TitleFormat);
        }

        [Fact]
        public void OnHandleSeoValues_TestPageTitleAndOverrideBaseTitle_ResetsBaseTitle()
        {
            // Arrange
            var attribute = new SeoTitleAttribute(TestData.TestTitle) { OverrideBaseTitle = true };

            var seo = SeoHelperTestFactory.Create();

            // Act
            attribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Equal(TestData.TestTitle, seo.Title);
            Assert.Null(seo.BaseTitle);
        }
    }
}