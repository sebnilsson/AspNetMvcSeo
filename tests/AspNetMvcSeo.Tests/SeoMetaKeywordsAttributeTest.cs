﻿using Xunit;

namespace AspNetMvcSeo.Tests
{
    public class SeoMetaKeywordsAttributeTest
    {
        [Fact]
        public void OnHandleSeoValues_TestMetaKeywords_SetsMetaKeywords()
        {
            // Arrange
            var attribute = new SeoMetaKeywordsAttribute(TestData.TestMetaKeywords);

            var seo = SeoHelperTestFactory.Create();

            // Act
            attribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Equal(TestData.TestMetaKeywords, seo.MetaKeywords);
        }

        [Fact]
        public void OnHandleSeoValues_TestMetaKeywords_SetsMetaKeywordsOnly()
        {
            // Arrange
            var attribute = new SeoMetaKeywordsAttribute(TestData.TestMetaKeywords);

            var seo = SeoHelperTestFactory.Create();

            // Act
            attribute.OnHandleSeoValues(seo);

            // Assert
            Assert.Null(seo.LinkCanonical);
            Assert.Null(seo.MetaDescription);
            Assert.Null(seo.MetaRobotsIndex);
            Assert.Null(seo.Title);
        }
    }
}